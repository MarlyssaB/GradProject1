using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GradProject.Core;
using GradProject.Models;
using GradProject.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GradProject.Controllers
{
    // TODO: secure controller actions that change data
    [Authorize]
    [Route("api/[controller]")]
    public class EntriesController : Controller
    {

        private readonly IEntryService _entryService;

        // TODO: inject PostService
        public EntriesController(IEntryService entryService)
        {
            _entryService = entryService;
        }

        // TODO: get posts for blog
        // TODO: allow anyone to get, even if not logged in
        // GET /api/blogs/{blogId}/posts
        [AllowAnonymous]
        [HttpGet("/api/blogs/{blogId}/posts")]
        public IActionResult Get(int profileId)
        {
            try
            {
                return Ok(_entryService.GetProfileEntries(profileId).ToApiModels());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GetProfilePosts", ex.Message);
                return BadRequest(ModelState);
            }


        }

        // TODO: get post by id
        // TODO: allow anyone to get, even if not logged in
        // GET api/blogs/{blogId}/posts/{postId}
        [AllowAnonymous]
        [HttpGet("/api/blogs/{blogId}/posts/{postId}")]
        public IActionResult Get(int profileId, int entryId)
        {
            try
            {
                return Ok(_entryService.Get(entryId).ToApiModel());
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("GetPostById", ex.Message);
                return BadRequest(ModelState);
            }

        }

        // TODO: add a new post to blog
        // POST /api/blogs/{blogId}/post
        [HttpPost("/api/blogs/{blogId}/posts")]
        public IActionResult Entry(int blogId, [FromBody]EntryModel entryModel)
        {
            try
            {
                _entryService.Add(entryModel.ToDomainModel());
                return CreatedAtAction("Get", new { id = entryModel.Id }, entryModel);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("AddEntry", ex.GetBaseException().Message);
                return BadRequest(ModelState);
            }

        }

        // PUT /api/blogs/{blogId}/posts/{postId}
        [HttpPut("/api/blogs/{blogId}/posts/{postId}")]
        public IActionResult Put(int blogId, int postId, [FromBody]EntryModel entryModel)
        {
            try
            {
                var updatedPost = _entryService.Update(entryModel.ToDomainModel());
                return Ok(updatedEntry);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("UpdateEntry", ex.Message);
                return BadRequest(ModelState);
            }
        }

        // TODO: delete post by id
        // DELETE /api/blogs/{blogId}/posts/{postId}
        [HttpDelete("/api/blogs/{blogId}/posts/{postId}")]
        public IActionResult Delete(int profileId, int entryId)
        {
            try
            {
                _entryService.Remove(entryId);
                return NoContent();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("DeleteEntry", ex.Message);
                return BadRequest(ModelState);
            }
        }
    }
}
