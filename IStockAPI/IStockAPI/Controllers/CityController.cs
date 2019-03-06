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
    public class CityController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        public CityController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET ../GetCities
        [HttpGet]
        [Route("GetCities")]
        public async Task<ActionResult<IEnumerable<City>>> GetCities()
        {
            Task<List<City>> Res;
            try
            {
                Res = _context.Cities.Where(o => o.Is_Actv == true).ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return await Res;
        }

        // GET api/Items/5
        [HttpGet]
        [Route("GetCity/{id}")]
        public async Task<ActionResult<City>> GetCity(long id)
        {
            City city;
            try
            {
                city = await _context.Cities.FindAsync(id);
                if (city == null)
                {
                    return NotFound();
                }

            }
            catch (Exception)
            {

                throw;
            }

            return city;
        }


        // POST ../AddCity
        [Route("AddCity")]
        [HttpPost]
        public async Task<ActionResult<City>> PostItem(City city)
        {
            try
            {
                city.Is_Actv = true;
                city.Is_Del = false;
                _context.Cities.Add(city);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return CreatedAtAction(nameof(GetCity), new { id = city.City_Id }, city);
        }


        // PUT ../UpdateCity/5
        [Route("UpdateCity/{id}")]
        [HttpPut]
        public async Task<ActionResult<City>> PutCity(long id, City city)
        {
            try
            {

                if (id != city.City_Id)
                {
                    return BadRequest();
                }

                _context.Entry(city).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            //return NoContent();
            return city;
        }



        // DELETE ../DeleteCity/5        
        [Route("DeleteCity/{id}")]
        [HttpPost]
        public async Task<ActionResult<City>> DeleteCity(long id)
        {
            City city;
            try
            {
                city = await _context.Cities.FindAsync(id);
                if (city == null)
                {
                    return NotFound();
                }

                city.Is_Actv = false;
                city.Is_Del = true;

                _context.Entry(city).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return city;
        }
    }
}
