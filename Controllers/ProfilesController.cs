using Models;
using Services;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
   [ApiController]
   [Route("api/[controller]")]
   public class ProfilesController : ControllerBase
   {
      private readonly ProfilesService _pservice;
      // private readonly BlogsService _bs;

      public ProfilesController(ProfilesService pservice /*, BlogsService bs*/)
      {
         _pservice = pservice;
         // _bs = bs
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

      // [HttpGet("{id}/blogs")]
      // public ActionResult<Profile> GetBlogs(string id)
      // {
      //    try
      //    {
      //       return Ok(_bs.GetBlogsByProfileId(id));
      //    }
      //    catch (System.Exception err)
      //    {
      //       return BadRequest(err.Message);
      //    }
      // }
   }
}