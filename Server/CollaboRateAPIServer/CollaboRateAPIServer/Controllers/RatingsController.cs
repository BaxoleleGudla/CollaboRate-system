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


        // Add average calculation, search functionality
        // Method to get ratings done by a specific member
        [HttpGet("group/{groupId}/rater/{raterId}/rated-members")]
        public async Task<ActionResult<IEnumerable<RatedMemberDto>>> GetRatedMemberByRaterAsync(int groupId, int raterId)
        {
            try
            {
                var ratedMembers = await _context.tblRating
                    .Where(r => r.Group_ID == groupId && r.Rater_ID == raterId)
                    .Join(_context.tblUser,
                        rating => rating.Ratee_ID,
                        user => user.User_ID,
                        (rating, user) => new RatedMemberDto
                        {
                            User_ID = user.User_ID,
                            Username = user.Username,
                            Score = (byte)rating.Score
                        })
                    .OrderBy(rm => rm.Username)
                    .ToListAsync();

                if (!ratedMembers.Any())
                {
                    // Return an empty list
                    return Ok(new List<RatedMemberDto>());
                }

                return Ok(ratedMembers);
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
    }
}
