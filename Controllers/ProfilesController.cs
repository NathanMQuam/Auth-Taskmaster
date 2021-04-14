using Models;
using Auth_TaskMaster.Services;
using Microsoft.AspNetCore.Mvc;

namespace Auth_TaskMaster.Controllers
{
   [ApiController]
   [Route("api/[controller]")]
   public class ProfilesController : ControllerBase
   {
      private readonly ProfilesService _pservice;

      public ProfilesController(ProfilesService pservice /*, BlogsService bs*/)
      {
         _pservice = pservice;
      }

      [HttpGet("{id}")]
      public ActionResult<Profile> Get(string id)
      {
         try
         {
            return Ok(_pservice.GetProfileById(id));
         }
         catch (System.Exception err)
         {
            return BadRequest(err.Message);
         }
      }
   }
}