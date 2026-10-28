
using API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/items")]
    public class ItemDeleteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ItemDeleteController(AppDbContext context)
        {
            _context = context;
        }

        // DELETE: /api/items/1
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var item = await _context.Items
                .FirstOrDefaultAsync(x => x.Id == id);

            if (item == null)
            {
                return NotFound(new { message = "Item not found." });
            }

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Item deleted successfully." });
        }
    }
}
