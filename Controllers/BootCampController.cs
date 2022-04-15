using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bootcamp_hw1.Contexts;
using bootcamp_hw1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bootcamp_hw1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BootCampController : Controller
    {
        private readonly AppDbContext context;

        public BootCampController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public List<BootCamp> GetAll()
        {
            var bootcamps = context.BootCamp.ToList();
            return bootcamps;
        }

        [HttpPost]
        public BootCamp Add([FromBody] BootCampResponse resource)
        {
            var bootcamp = new BootCamp();
            bootcamp.Name = resource.Name;
            bootcamp.Description = resource.Description;
            var newBootCamp = context.BootCamp.Add(bootcamp);
            context.SaveChanges();
            return bootcamp;
        }
    }
}