using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApi.Models;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private readonly app_developmentContext _context;

        public BuildingController(app_developmentContext context)
        {
            _context = context;
        }

        // GET: api/Building
        [HttpGet]
        public ActionResult<List<Building>> GetAll ()
        {
            var list_el = _context.elevators.ToList();
            var list_co = _context.columns.ToList();
            var list_ba = _context.batteries.ToList();
            var list_bu = _context.buildings.ToList();
            List<Elevator> intervention_elevator = new List<Elevator>();
            List<Column> intervention_column = new List<Column>();
            List<Battery> intervention_battery = new List<Battery>();
            List<Building> intervention_building = new List<Building>();

            foreach (var elevator in list_el){
                if (elevator.elevator_status == "Intervention"){
                    intervention_elevator.Add(elevator);
                }
            }
            foreach (var elevator in intervention_elevator){
                foreach (var column in list_co){
                    if (column.Id == elevator.column_id){
                        intervention_column.Add(column);
                    }
                }
            }
            foreach (var column in list_co){
                if (column.column_status == "Intervention"){
                    intervention_column.Add(column);
                }
            }
            foreach (var column in intervention_column){
                foreach (var battery in list_ba){
                    if (battery.Id == column.battery_id){
                        intervention_battery.Add(battery);
                    }
                }
            }
            foreach (var battery in list_ba){
                if (battery.battery_status == "Intervention"){
                    intervention_battery.Add(battery);
                }
            }
            foreach (var battery in intervention_battery){
                foreach (var building in list_bu){
                    if (building.Id == battery.building_id){
                       intervention_building.Add(building); 
                    }
                }
            }
            List<Building> all_building = intervention_building.Distinct().ToList();
            return all_building;
            //return intervention_building;
        }

        // GET: api/Building/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Building>> GetBuilding(long id)
        {
            var building = await _context.buildings.FindAsync(id);

            if (building == null)
            {
                return NotFound();
            }

            return building;
        }

        // PUT: api/Building/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBuilding(long id, Building building)
        {
            if (id != building.Id)
            {
                return BadRequest();
            }

            _context.Entry(building).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuildingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Building
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Building>> PostBuilding(Building building)
        {
            _context.buildings.Add(building);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBuilding", new { id = building.Id }, building);
        }

        // DELETE: api/Building/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Building>> DeleteBuilding(long id)
        {
            var building = await _context.buildings.FindAsync(id);
            if (building == null)
            {
                return NotFound();
            }

            _context.buildings.Remove(building);
            await _context.SaveChangesAsync();

            return building;
        }

        private bool BuildingExists(long id)
        {
            return _context.buildings.Any(e => e.Id == id);
        }
    }
}
