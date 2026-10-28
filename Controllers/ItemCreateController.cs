
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/items")]
    public class ItemCreateController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ItemCreateController(AppDbContext context)
        {
            _context = context;
        }

        // POST: /api/items
        [HttpPost]
        public async Task<IActionResult> CreateItem(
            [FromBody] CreateItemModel model)
        {
            var item = new Item
            {
                ItemName = model.ItemName,
                Description = model.Description,
                Category = model.Category,
                Location = model.Location,
                Status = model.Status
            };

            _context.Items.Add(item);
            await _context.SaveChangesAsync();

            return Created($"/api/items/{item.Id}", item);
        }
    }
}
