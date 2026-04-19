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
        [HttpGet("group/{groupId}/status-for/{raterId}")]
        public async Task<ActionResult<IEnumerable<RatedMemberDto>>> GetEvaluations(int groupId, int raterId)
        {
            var totalInGroup = await _context.tblGroupMember.CountAsync(gm => gm.Group_ID == groupId && gm.Join_Status == "Accepted");

            var members = await _context.tblGroupMember
                .Where(gm => gm.Group_ID == groupId && gm.User_ID != raterId && gm.Join_Status == "Accepted")
                .Join(_context.tblUser, gm => gm.User_ID, u => u.User_ID, (gm, u) => new { u.User_ID, u.Username })
                .ToListAsync();

            var ratings = await _context.tblRating.Where(r => r.Group_ID == groupId).ToListAsync();

            return Ok(members.Select(m => new RatedMemberDto
            {
                User_ID = m.User_ID,
                Username = m.Username,
                MyCurrentScore = ratings.FirstOrDefault(r => r.Rater_ID == raterId && r.Ratee_ID == m.User_ID)?.Score,
                AverageScore = ratings.Where(r => r.Ratee_ID == m.User_ID).Any() ?
                               Math.Round(ratings.Where(r => r.Ratee_ID == m.User_ID).Average(r => (double)r.Score), 2) : 0,
                ReceivedRatingsCount = ratings.Count(r => r.Ratee_ID == m.User_ID),
                PotentialRatingsCount = totalInGroup - 1
            }).OrderBy(x => x.Username));
        }

        [HttpPost("batch-upsert")]
        public async Task<IActionResult> BatchUpsert([FromBody] List<RatingUpdateDto> updates)
        {
            foreach (var dto in updates)
            {
                var existing = await _context.tblRating.FirstOrDefaultAsync(r => r.Group_ID == dto.Group_ID && r.Rater_ID == dto.Rater_ID && r.Ratee_ID == dto.Ratee_ID);
                if (existing != null) { existing.Score = dto.Score; existing.Rated_At = DateTime.UtcNow; }
                else { _context.tblRating.Add(new Rating { Group_ID = dto.Group_ID, Rater_ID = dto.Rater_ID, Ratee_ID = dto.Ratee_ID, Score = dto.Score }); }
            }
            await _context.SaveChangesAsync();
            return Ok();
        }


        /* Old logic to for user ratings 
        // Method to add ratings
        [HttpPost("ratings")]
        public async Task<ActionResult> AddRatings([FromBody] List<RatingUpdateDto> ratingsDto)
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
        }*/
    }
}
