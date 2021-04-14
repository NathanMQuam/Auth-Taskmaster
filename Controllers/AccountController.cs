using System;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using System.Collections;
using System.Collections.Generic;

namespace Controllers
{
   [ApiController]
   [Route("[controller]")]

   // REVIEW this tag enforces the user must be logged in
   [Authorize]
   public class AccountController : ControllerBase
   {
      private readonly ProfilesService _pservice;

      public AccountController(ProfilesService pservice)
      {
         _pservice = pservice;
      }

      [HttpGet]
      // REVIEW async calls must return a System.Threading.Tasks, this is equivalent to a promise in JS
      public async Task<ActionResult<Profile>> GetAsync()
      {
         try
         {
            // REVIEW how to get the user info from the request token
            // same as to req.userInfo
            //MAKE SURE TO BRING IN codeworks.auth0provider
            Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
            return Ok(_pservice.GetOrCreateProfile(userInfo));
         }
         catch (Exception e)
         {
            return BadRequest(e.Message);
         }
      }

      // [HttpGet("blogs")]
      // public async Task<ActionResult<IEnumerator<Blog>>> GetBlogs()
      // {
      //    try
      //    {
      //       Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
      //       return Ok(_bs.GetBlogsByProfileId(userInfo.Id));
      //    }
      //    catch (Exception e)
      //    {
      //       return BadRequest(e.Message);
      //    }
      // }

      [HttpPut]
      [Authorize]
      public async Task<ActionResult<Profile>> EditAsync([FromBody] Profile editData)
      {
         try
         {
            Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
            editData.Id = userInfo.Id;
            Profile editedProfile = _pservice.Edit(editData);
            return Ok(editedProfile);
         }
         catch (Exception e)
         {
            return BadRequest(e.Message);
         }
      }
   }
}