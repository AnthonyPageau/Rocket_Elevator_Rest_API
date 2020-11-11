using System;
using System.Collections.Generic;

namespace RestApi.Models
{
    public partial class Employe
    {
        // public Employe () {
        //     Battery = new HashSet<Battery> ();
        // }

        public long Id {get; set;}
        public long? user_id {get; set;}

        public string first_name {get; set;}
        public string last_name {get; set;}
        public string function {get; set;}
        public string phone {get; set;}
        public string email {get; set;}

        public DateTime? created_at {get; set;}
        public DateTime? updated_at {get; set;}

        // public User User { get; set; }
        // public ICollection<Battery> Battery { get; set; }
    }
}