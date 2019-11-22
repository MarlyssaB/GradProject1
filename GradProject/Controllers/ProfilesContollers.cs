using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GradProject.Core;
using GradProject.Models;
using GradProject.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GradProject.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ProfilesController : Controller
    {
        private readonly IProfileService _profileService;

        // TODO: inject BlogService
        public ProfilesController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        // GET: api/blogs
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // TODO: replace the code below with the correct implementation
                // to return all blogs
                return Ok(_profileService.GetAll().ToApiModels());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GetProfile", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // GET api/blogs/{id}
        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                // TODO: replace the code below with the correct implementation
                // to return a blog by id
                return Ok(_profileService.Get(id).ToApiModel());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GetProfiles", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // POST api/blogs
        [HttpPost]
        public IActionResult Post([FromBody]Profile profile)
        {
            try
            {
                return Ok(_profileService.Add(profile).ToApiModel());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("AddProfile", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // PUT api/blogs/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Profile profile)
        {
            try
            {
                return Ok(_profileService.Update(profile).ToApiModel());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("UpdateProfile", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // DELETE api/blogs/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _profileService.Remove(id);
                return Ok();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("DeleteProfile", ex.Message);
                return BadRequest(ModelState);
            }
        }
    }
}
