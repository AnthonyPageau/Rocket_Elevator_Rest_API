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
    public class LeadController : ControllerBase
    {
        private readonly app_developmentContext _context;

        public LeadController(app_developmentContext context)
        {
            _context = context;
        }

        // GET: api/Lead
        // public ActionResult<List<Lead>> GetAll () {
        //     var listl = _context.leads.users.Include(cus => cus.customers);

        //     if (listl == null) {
        //         return NotFound ("Not Found");
        //     }

        //     List<Lead> list_lead = new List<Lead> ();
        //     DateTime currentDate = DateTime.Now.AddDays (-30);
        //     foreach (var l in listl) {
        //         if (l.created_at >= currentDate) {
        //             if (l.customers.ToList ().Count == 0) {
        //                 list_lead.Add (l);
        //             }
        //         }
        //     }
        //     return list_lead;
        // }
        public ActionResult<List<Lead>> GetAll () {
            var listl = _context.leads.ToList();
            var UserAll = _context.users.ToList();

            var CustomerAll = _context.customers.ToList();

            if (listl == null) {
                return NotFound ("Not Found");
            }

            List<Lead> list_lead = new List<Lead> ();
            List<Lead> list_l = new List<Lead> ();
            List<Customer> list_customer = new List<Customer> ();

            DateTime currentDate = DateTime.Now.AddDays (-30);
            
            foreach (var l in listl) {

                if (l.created_at >= currentDate) {

                    list_lead.Add (l);
                }
            }

            foreach (var lead in list_lead)
            {
                foreach (var customer in CustomerAll)
                {
                    if (lead.user_id != customer.user_id) 
                    {
                        list_l.Add(lead);
                    }
                }
            }
            
            List<Lead> final_list = list_l.Distinct().ToList();
            
            return final_list;
        }
    }
}
