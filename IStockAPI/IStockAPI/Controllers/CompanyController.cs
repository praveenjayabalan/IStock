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
    public class CompanyController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        public CompanyController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET ../GetCompanies
        [HttpGet]
        [Route("GetCompanies")]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompanies()
        {
            Task<List<Company>> Res;
            try
            {
                Res = _context.Companies.Where(o => o.Is_Actv == true).ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return await Res;
        }

        // GET api/Items/5
        [HttpGet]
        [Route("GetCompany/{id}")]
        public async Task<ActionResult<Company>> GetCompany(long id)
        {
            Company company;
            try
            {
                company = await _context.Companies.FindAsync(id);
                if (company == null)
                {
                    return NotFound();
                }

            }
            catch (Exception)
            {

                throw;
            }

            return company;
        }


        // POST ../AddCompany
        [Route("AddCompany")]
        [HttpPost]
        public async Task<ActionResult<Company>> PostItem(Company company)
        {
            try
            {
                company.Is_Actv = true;
                company.Is_Del = false;
                _context.Companies.Add(company);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return CreatedAtAction(nameof(GetCompany), new { id = company.Company_Id }, company);
        }


        // PUT ../UpdateCompany/5
        [Route("UpdateCompany/{id}")]
        [HttpPut]
        public async Task<ActionResult<Company>> PutCompany(long id, Company company)
        {
            try
            {

                if (id != company.Company_Id)
                {
                    return BadRequest();
                }

                _context.Entry(company).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            //return NoContent();
            return company;
        }



        // DELETE ../DeleteCompany/5        
        [Route("DeleteCompany/{id}")]
        [HttpPost]
        public async Task<ActionResult<Company>> DeleteCompany(long id)
        {
            Company company;
            try
            {
                company = await _context.Companies.FindAsync(id);
                if (company == null)
                {
                    return NotFound();
                }

                company.Is_Actv = false;
                company.Is_Del = true;

                _context.Entry(company).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return company;
        }
    }
}
