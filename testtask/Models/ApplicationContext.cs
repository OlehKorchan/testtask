﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace testtask.Models
{
	public class ApplicationContext : DbContext
	{
		public ApplicationContext(DbContextOptions<ApplicationContext> options) 
			: base(options)
		{ 
			Database.EnsureCreated();
		}
 
		public DbSet<User> Users { get; set; }
	}
}
