using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Connections;

namespace testtask.Models
{
    public class User
    {
        public int Id { get; set; }
        [StringLength(150)]
        public string Name { get; set; }
        public bool Active { get; set; }

        public User(string name)
        {
	        Name = name;
	        Active = false;
        }
    }
}
