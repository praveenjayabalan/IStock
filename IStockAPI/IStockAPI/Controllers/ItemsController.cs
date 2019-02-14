using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IStockAPI.Data;
using IStockAPI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IStockAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        public ItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET api/Items
        [HttpGet]
        [Route("GetItems")]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems()
        {
            return await _context.Items.ToListAsync();
        }

        // GET api/Items/5
        [HttpGet]
        [Route("GetItem")]
        public async Task<ActionResult<Item>> GetItem(long id)
        {
            var Item = await _context.Items.FindAsync(id);
            if (Item == null)
            {
                return NotFound();
            }

            return Item;
        }


        // POST api/Items
        [Route("AddItem")]
        [HttpPost]
        public async Task<ActionResult<Item>> PostItem(Item item)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item);
        }


        // PUT api/Items/5
        [Route("UpdateItem")]
        [HttpPost]
        public async Task<IActionResult> PutItem(long id, Item item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }



        // DELETE api/Items/5        
        [Route("DeleteItem")]
        [HttpPost]
        public async Task<IActionResult> DeleteItem(long id,Item item)
        {
            var todoItem = await _context.Items.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
