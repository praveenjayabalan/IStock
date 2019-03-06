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
    public class CountryController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        public CountryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET ../GetCountries
        [HttpGet]
        [Route("GetCountries")]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountries()
        {
            Task<List<Country>> Res;
            try
            {
                Res = _context.Countries.Where(o => o.Is_Actv == true).ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return await Res;
        }

        // GET api/Items/5
        [HttpGet]
        [Route("GetCountry/{id}")]
        public async Task<ActionResult<Country>> GetCountry(long id)
        {
            Country country;
            try
            {
                country = await _context.Countries.FindAsync(id);
                if (country == null)
                {
                    return NotFound();
                }

            }
            catch (Exception)
            {

                throw;
            }

            return country;
        }


        // POST ../AddCountry
        [Route("AddCountry")]
        [HttpPost]
        public async Task<ActionResult<Country>> PostItem(Country country)
        {
            try
            {
                country.Is_Actv = true;
                country.Is_Del = false;
                _context.Countries.Add(country);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
            return CreatedAtAction(nameof(GetCountry), new { id = country.Country_Id }, country);
        }


        // PUT ../UpdateCountry/5
        [Route("UpdateCountry/{id}")]
        [HttpPut]
        public async Task<ActionResult<Country>> PutCountry(long id, Country country)
        {
            try
            {

                if (id != country.Country_Id)
                {
                    return BadRequest();
                }

                _context.Entry(country).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            //return NoContent();
            return country;
        }



        // DELETE ../DeleteCountry/5        
        [Route("DeleteCountry/{id}")]
        [HttpPost]
        public async Task<ActionResult<Country>> DeleteCountry(long id)
        {
            Country country;
            try
            {
                country = await _context.Countries.FindAsync(id);
                if (country == null)
                {
                    return NotFound();
                }

                country.Is_Actv = false;
                country.Is_Del = true;

                _context.Entry(country).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return country;
        }
    }
}
