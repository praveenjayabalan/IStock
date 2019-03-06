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
    public class BuyerController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        public BuyerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET ../GetBuyers
        [HttpGet]
        [Route("GetBuyers")]
        public async Task<ActionResult<IEnumerable<Buyer>>> GetBuyers()
        {
            Task<List<Buyer>> Res;
            try
            {
                Res = _context.Buyers.Where(o => o.Is_Actv == true).ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return await Res;
        }

        // GET api/Items/5
        [HttpGet]
        [Route("GetBuyer/{id}")]
        public async Task<ActionResult<Buyer>> GetBuyer(long id)
        {
            Buyer buyer;
            try
            {
                buyer = await _context.Buyers.FindAsync(id);
                if (buyer == null)
                {
                    return NotFound();
                }

            }
            catch (Exception)
            {

                throw;
            }

            return buyer;
        }


        // POST ../AddBuyer
        [Route("AddBuyer")]
        [HttpPost]
        public async Task<ActionResult<Buyer>> PostItem(Buyer buyer)
        {
            try
            {
                buyer.Is_Actv = true;
                buyer.Is_Del = false;
                _context.Buyers.Add(buyer);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return CreatedAtAction(nameof(GetBuyer), new { id = buyer.Buyer_id }, buyer);
        }


        // PUT ../UpdateBuyer/5
        [Route("UpdateBuyer/{id}")]
        [HttpPut]
        public async Task<ActionResult<Buyer>> PutBuyer(long id, Buyer buyer)
        {
            try
            {

                if (id != buyer.Buyer_id)
                {
                    return BadRequest();
                }

                _context.Entry(buyer).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            //return NoContent();
            return buyer;
        }



        // DELETE ../DeleteBuyer/5        
        [Route("DeleteBuyer/{id}")]
        [HttpPost]
        public async Task<ActionResult<Buyer>> DeleteBuyer(long id)
        {
            Buyer buyer;
            try
            {
                buyer = await _context.Buyers.FindAsync(id);
                if (buyer == null)
                {
                    return NotFound();
                }

                buyer.Is_Actv = false;
                buyer.Is_Del = true;

                _context.Entry(buyer).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return buyer;
        }
    }
}
