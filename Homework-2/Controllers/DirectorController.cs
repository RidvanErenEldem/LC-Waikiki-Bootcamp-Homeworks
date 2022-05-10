using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Extensions;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories.Interfaces;
using Resources;
using Services.Interfaces;

namespace Controllers
{
    [Route("api/[controller]")]
    public class DirectorController : Controller
    {
        private readonly IDirectorService directorService;
        private readonly IMapper mapper;
        public DirectorController(IDirectorService directorService, IMapper mapper)
        {
            this.directorService = directorService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<List<Director>> GetAll()
        {
            return await directorService.GetAllAsync();
        }
        
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] SaveDirectorResource resource)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var addedDirector = mapper.Map<SaveDirectorResource, Director>(resource);
            var result = await directorService.SaveAsync(addedDirector);

            if(!result.success)
                return BadRequest(result.message);
            
            var directorResource = mapper.Map<Director, DirectorResource>(result.director);
            return Ok(directorResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] SaveDirectorResource resource)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var updatedDirector = mapper.Map<SaveDirectorResource,Director>(resource);
            var result = await directorService.UpdateAsync(id,updatedDirector);
             
            if(!result.success)
                return BadRequest(result.message);

            var directorResource = mapper.Map<Director, DirectorResource>(result.director);
            return Ok(directorResource);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await directorService.DeleteAsync(id);
            if(!result.success)
                return BadRequest(result.message);
            
            var directorResource = mapper.Map<Director, DirectorResource>(result.director);
            return Ok(directorResource);
        }
        [HttpPut("search")]
        public async Task<ActionResult<List<Director>>> GetBySearch([FromBody] SearchDirectorResource resource)
        {
            var found = await directorService.Search(resource);
            if(found == null)
                return BadRequest("Can not find director");
            return Ok(found);
        } 
    }
}