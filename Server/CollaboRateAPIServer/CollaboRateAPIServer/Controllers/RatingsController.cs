using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using CollaboRateAPIServer.Data;
using System.Runtime.Versioning;
using CollaboRateAPIServer.Dtos;
using CollaboRateAPIServer.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace CollaboRateAPIServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatingsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RatingsController(AppDbContext context)
        {
            _context = context;
        }

        // Method to get ratings done by a specific member
        [HttpGet("group/{groupId}/rater/{raterId}/rated-members")]
        public async Task<ActionResult<IEnumerable<RatedMemberDto>>> GetRatedMemberByRaterAsync(int groupId, int raterId, [FromQuery] string? keyword = null)
        {
            try
            {
                // Get all ratings in the group to cmpute average per Ratee
                // Grouping on Ratee_ID and calculate average score
                var averageRatingsQuery = _context.tblRating
                    .Where(r => r.Group_ID == groupId)
                    .GroupBy(r => r.Ratee_ID)
                    .Select(g => new
                    {
                        Ratee_ID = g.Key,
                        AverageScore = g.Average(r => r.Score)
                    });

                // Get the ratings made by the specified rater in the group
                var query = _context.tblRating
                    .Where(r => r.Group_ID == groupId && r.Rater_ID == raterId)
                    .Join(_context.tblUser,
                        rating => rating.Ratee_ID,
                        user => user.User_ID,
                        (rating, user) => new
                        {
                            user.User_ID,
                            user.Username,
                            Score = rating.Score
                        });

                // Apply keyword filter on Username if keyword supplied
                if (string.IsNullOrWhiteSpace(keyword) == false)
                {
                    string lowerKeyword = keyword.ToLower();
                    query = query.Where(u => u.Username.ToLower().Contains(lowerKeyword));
                }

                // Join the rating-by-rater with average rating per Ratee_ID
                var resultQuery = query
                    .Join(averageRatingsQuery,
                        raterRating => raterRating.User_ID,
                        avg => avg.Ratee_ID,
                        (raterRating, avg) => new RatedMemberDto
                        {
                            User_ID = raterRating.User_ID,
                            Username = raterRating.Username,
                            Score = (byte)raterRating.Score,
                            Average_Score = Math.Round(avg.AverageScore, 2)
                        })
                    .OrderBy(rm => rm.Username);

                var resultList = await resultQuery.ToListAsync();

                return Ok(resultList);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        // Method to add ratings
        [HttpPost("ratings")]
        public async Task<ActionResult> AddRatings([FromBody] List<RatingDto> ratingsDto)
        {
            if (ratingsDto == null || !ratingsDto.Any())
            {
                return BadRequest("No ratings provided.");
            }

            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // Validate Score range before insertion
                if (ratingsDto.Any(r => r.Score < 1 || r.Score > 5))
                {
                    return BadRequest("All scores must be between 1 and 5.");
                }

                var ratings = new List<Rating>();

                foreach (var r in ratingsDto)
                {
                    // Check uniqueness to avoid violatin unique constraint
                    bool exists = await _context.tblRating.AnyAsync(rt =>
                        rt.Group_ID == r.Group_ID &&
                        rt.Rater_ID == r.Rater_ID &&
                        rt.Ratee_ID == r.Ratee_ID);

                    if (exists)
                    {
                        return Conflict($"Duplicate rating from Rater {r.Rater_ID} to Ratee {r.Ratee_ID} in Group {r.Group_ID}.");
                    }

                    ratings.Add(new Rating
                    {
                        Group_ID = r.Group_ID,
                        Rater_ID = r.Rater_ID,
                        Ratee_ID = r.Ratee_ID,
                        Score = r.Score,
                        Rated_At = DateTime.UtcNow
                    });
                }

                await _context.tblRating.AddRangeAsync(ratings);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return Ok(new { message = $"{ratings.Count} ratings(s) added successfully." });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return StatusCode(500, "An error occurred while adding ratings.");
            }
        }

        // Method to update ratings
        [HttpPut("ratings")]
        public async Task<ActionResult> UpdateMemberEvaluationAsync([FromBody] UpdateRatingDto dto)
        {
            if (dto.Score < 1 || dto.Score > 5)
            {
                return BadRequest("Score must be between 1 and 5.");
            }

            var rating = await _context.tblRating.FirstOrDefaultAsync(r =>
                r.Group_ID == dto.Group_ID &&
                r.Rater_ID == dto.Rater_ID &&
                r.Ratee_ID == dto.Ratee_ID);

            if (rating == null)
            {
                return NotFound("Rating record not found.");
            }

            rating.Score = (byte)dto.Score;
            rating.Rated_At = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
