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
            Task<List<Item>> Res;
            try
            {
                Res = _context.Items.Where(o => o.Is_Actv == true).ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return await Res;// _context.Items.ToListAsync();
        }

        // GET api/Items/5
        [HttpGet]
        [Route("GetItem/{id}")]
        public async Task<ActionResult<Item>> GetItem(long id)
        {
            Item Item;
            try
            {
                Item = await _context.Items.FindAsync(id);
                if (Item == null)
                {
                    return NotFound();
                }

            }
            catch (Exception)
            {

                throw;
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
            return CreatedAtAction(nameof(GetItem), new { id = item.Item_Id }, item);
        }

        
        // PUT api/Items/5
        [Route("UpdateItem/{id}")]
        [HttpPut]
        public async Task<ActionResult<Item>> PutItem(long id, Item item)
        {
            try
            {

                if (id != item.Item_Id)
                {
                    return BadRequest();
                }

                _context.Entry(item).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            //return NoContent();
            return item;
        }



        // DELETE api/Items/5        
        [Route("DeleteItem/{id}")]
        [HttpPost]
        public async Task<ActionResult<Item>> DeleteItem(long id)
        {
            Item item;
            try
            {
                item = await _context.Items.FindAsync(id);
                if (item == null)
                {
                    return NotFound();
                }

                item.Is_Actv = false;
                item.Is_Del = true;

                _context.Entry(item).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return item;
        }
    }
}
