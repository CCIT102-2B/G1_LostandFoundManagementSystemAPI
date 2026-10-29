using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/items")]
    public class ItemUpdateController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ItemUpdateController(AppDbContext context)
        {
            _context = context;
        }

        // PUT: /api/items/1
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateItem(
            int id,
            [FromBody] UpdateItemModel model)
        {
            var item = await _context.Items
                .FirstOrDefaultAsync(x => x.Id == id);

            if (item == null)
            {
                return NotFound(new { message = "Item not found." });
            }
            item.ItemName = model.ItemName;
            item.Description = model.Description;
            item.Category = model.Category;
            item.Location = model.Location;
            item.Status = model.Status;
            await _context.SaveChangesAsync();
            return Ok(item);
        }
    }
}
