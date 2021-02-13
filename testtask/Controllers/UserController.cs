using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using testtask.Models;

namespace testtask.Controllers
{
	[ApiController]
	[Route("api/users")]
	public class ProductController : Controller
	{
		ApplicationContext db;
		public ProductController(ApplicationContext context)
		{
			db = context;
			if (!db.Users.Any())
			{
				db.Users.Add(new User("Oleh"));
				db.Users.Add(new User("Ivan"));
				db.Users.Add(new User("Andrey"));
				db.Users.Add(new User("Nikita"));
				db.Users.Add(new User("Anya"));
				db.Users.Add(new User("Marina"));
				db.Users.Add(new User("Kate"));
				db.Users.Add(new User("Zhenya"));
				db.Users.Add(new User("Alexander"));
				db.Users.Add(new User("Simon"));
				db.SaveChanges();
			}
		}
		[HttpGet]
		public IEnumerable<User> Get()
		{
			return db.Users.ToList();
		}
	
		[HttpGet("{id}")]
		public User Get(int id)
		{
			User user = db.Users.FirstOrDefault(x => x.Id == id);
			return user;
		}
		[HttpPost]
		public IActionResult Post(User user)
		{
			if (ModelState.IsValid)
			{
				db.Users.Add(user);
				db.SaveChanges();
				return Ok(user);
			}
			return BadRequest(ModelState);
		}
 
		[HttpPut]
		public IActionResult Put(User user)
		{
			if (ModelState.IsValid)
			{
				db.Users.Update(user);
				db.SaveChanges();
				return Ok(user);
			}
			return BadRequest(ModelState);
		}
 
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			User user = db.Users.FirstOrDefault(x => x.Id == id);
			if (user != null)
			{
				db.Users.Remove(user);
				db.SaveChanges();
			}
			return Ok(user);
		}
	}
}
