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
        public async Task<List<BootCamp>> GetAllAsync()
        {
            var bootcamps = await context.BootCamp.ToListAsync();
            return bootcamps;
        }

        [HttpPost]
        public async Task<BootCamp> Add([FromBody] BootCampResponse resource)
        {
            var bootcamp = new BootCamp();
            bootcamp.Name = resource.Name;
            bootcamp.Description = resource.Description;
            var newBootCamp = await context.BootCamp.AddAsync(bootcamp);
            await context.SaveChangesAsync();
            return bootcamp;
        }
        [HttpPut]
        public async Task<BootCamp> Update(int Id, [FromBody] BootCampResponse resource)
        {
            var bootcamp = new BootCamp();
            bootcamp.Name = resource.Name;
            bootcamp.Description = resource.Description;
            bootcamp.Id = Id;
            var updatedBootcamp = context.BootCamp.Update(bootcamp);
            await context.SaveChangesAsync();
            return bootcamp;
        }
    }
}