using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApi.Models;
using Newtonsoft.Json.Linq;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElevatorController : ControllerBase
    {
        private readonly app_developmentContext _context;

        public ElevatorController(app_developmentContext context)
        {
            _context = context;
        }

        // GET: api/Elevator
        [HttpGet]
        public ActionResult<List<Elevator>> GetAll ()
            {
            var list = _context.elevators.ToList();

            if (list == null)
            {
                return NotFound();
            }
            List<Elevator> inactive_elevator_list = new List<Elevator>();
            foreach (var elevator in list)
            {
                if (elevator.elevator_status != "ACTIVE") {
                    inactive_elevator_list.Add (elevator);
                }
            }
            return inactive_elevator_list;
        }

        // GET: api/Elevator/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Elevator>> GetElevator(long id)
        {
            var elevator = await _context.elevators.FindAsync(id);

            if (elevator == null)
            {
                return NotFound();
            }

            var status = new JObject ();
            status["status"] = elevator.elevator_status;
            return Content (status.ToString (), "application/json");
        }

        // PUT: api/Elevator/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutElevator(long id, Elevator elevator)
        {
           var e = await _context.elevators.FindAsync (id);
           if (e == null) {
               return NotFound ();
           }

            e.elevator_status = elevator.elevator_status;

            _context.elevators.Update (e);
            _context.SaveChanges ();
            var status = new JObject ();
            status["message"] = "The status has been change";
            return Content (status.ToString (), "application/json");
        }
    }
}
