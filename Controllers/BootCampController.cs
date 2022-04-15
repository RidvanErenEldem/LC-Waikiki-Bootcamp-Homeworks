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
            try
            {
                var updatedBootcamp = context.BootCamp.Update(bootcamp);
                await context.SaveChangesAsync();
                return bootcamp;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred when updating: {ex.Message}");
                return null;
            }
        }
        [HttpDelete]
        public async Task<BootCamp> Delete(int Id)
        {
            try
            {
                var bootcamp = await context.BootCamp.FindAsync(Id);
                if(bootcamp == null)
                {
                    Console.WriteLine($"The bootcamp with id {Id} does not exist");
                    return null;
                }
                var deletedBootcamp = context.BootCamp.Remove(bootcamp);
                await context.SaveChangesAsync();
                return bootcamp;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"An error occurred when deleting: {ex.Message}");
                return null;
            }
        }
        [HttpGet("{Id}/searchById")]
        public async Task<BootCamp> SearchById(int Id)
        {
            var bootcamp = await context.BootCamp.FindAsync(Id);
            if(bootcamp == null)
            {
                var bootCampResponse = new BootCamp();
                bootCampResponse.Name = "thank you mario but bootcamp is in another castle";
                bootCampResponse.Id = Id;
                bootCampResponse.Description = null;
                return bootCampResponse;
            }
            else
                return bootcamp;
        }
    }
}