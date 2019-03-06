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
    public class SupplierController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        public SupplierController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET ../GetSuppliers
        [HttpGet]
        [Route("GetSuppliers")]
        public async Task<ActionResult<IEnumerable<Supplier>>> GetSuppliers()
        {
            Task<List<Supplier>> Res;
            try
            {
                Res = _context.Suppliers.Where(o => o.Is_Actv == true).ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return await Res;
        }

        // GET api/Items/5
        [HttpGet]
        [Route("GetSupplier/{id}")]
        public async Task<ActionResult<Supplier>> GetSupplier(long id)
        {
            Supplier supplier;
            try
            {
                supplier = await _context.Suppliers.FindAsync(id);
                if (supplier == null)
                {
                    return NotFound();
                }

            }
            catch (Exception)
            {

                throw;
            }

            return supplier;
        }


        // POST ../AddSupplier
        [Route("AddSupplier")]
        [HttpPost]
        public async Task<ActionResult<Supplier>> PostItem(Supplier supplier)
        {
            try
            {
                supplier.Is_Actv = true;
                supplier.Is_Del = false;
                _context.Suppliers.Add(supplier);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return CreatedAtAction(nameof(GetSupplier), new { id = supplier.Supplier_id }, supplier);
        }


        // PUT ../UpdateSupplier/5
        [Route("UpdateSupplier/{id}")]
        [HttpPut]
        public async Task<ActionResult<Supplier>> PutSupplier(long id, Supplier supplier)
        {
            try
            {

                if (id != supplier.Supplier_id)
                {
                    return BadRequest();
                }

                _context.Entry(supplier).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            //return NoContent();
            return supplier;
        }



        // DELETE ../DeleteSupplier/5        
        [Route("DeleteSupplier/{id}")]
        [HttpPost]
        public async Task<ActionResult<Supplier>> DeleteSupplier(long id)
        {
            Supplier supplier;
            try
            {
                supplier = await _context.Suppliers.FindAsync(id);
                if (supplier == null)
                {
                    return NotFound();
                }

                supplier.Is_Actv = false;
                supplier.Is_Del = true;

                _context.Entry(supplier).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return supplier;
        }
    }
}
