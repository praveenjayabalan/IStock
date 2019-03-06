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
    public class StateController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        public StateController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET ../GetStates
        [HttpGet]
        [Route("GetStates")]
        public async Task<ActionResult<IEnumerable<State>>> GetStates()
        {
            Task<List<State>> Res;
            try
            {
                Res = _context.States.Where(o => o.Is_Actv == true).ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return await Res;
        }

        // GET api/Items/5
        [HttpGet]
        [Route("GetState/{id}")]
        public async Task<ActionResult<State>> GetState(long id)
        {
            State state;
            try
            {
                state = await _context.States.FindAsync(id);
                if (state == null)
                {
                    return NotFound();
                }

            }
            catch (Exception)
            {

                throw;
            }

            return state;
        }


        // POST ../AddState
        [Route("AddState")]
        [HttpPost]
        public async Task<ActionResult<State>> PostItem(State state)
        {
            try
            {
                state.Is_Actv = true;
                state.Is_Del = false;
                _context.States.Add(state);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
          
            return CreatedAtAction(nameof(GetState), new { id = state.State_Id }, state);
        }


        // PUT ../UpdateState/5
        [Route("UpdateState/{id}")]
        [HttpPut]
        public async Task<ActionResult<State>> PutState(long id, State state)
        {
            try
            {

                if (id != state.State_Id)
                {
                    return BadRequest();
                }

                _context.Entry(state).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            //return NoContent();
            return state;
        }



        // DELETE ../DeleteState/5        
        [Route("DeleteState/{id}")]
        [HttpPost]
        public async Task<ActionResult<State>> DeleteState(long id)
        {
            State state;
            try
            {
                state = await _context.States.FindAsync(id);
                if (state == null)
                {
                    return NotFound();
                }

                state.Is_Actv = false;
                state.Is_Del = true;

                _context.Entry(state).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return state;
        }
    }
}
