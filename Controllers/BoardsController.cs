using System;
using Microsoft.AspNetCore.Mvc;
using Auth_TaskMaster.Models;
using Auth_TaskMaster.Services;

namespace Auth_TaskMaster.Controller
{
   [ApiController]
   [Route("api/[controller]")]
   public class BoardsController : ControllerBase
   {
      private readonly BoardsService _service;
      public BoardsController(BoardsService service)
      {
         _service = service;
      }

      [HttpGet]
      public ActionResult<Board> Get()
      {
         try
         {
            return Ok(_service.GetAll());
         }
         catch (Exception e)
         {
            return BadRequest(e.Message);
         }
      }

      [HttpGet("{id}")]
      public ActionResult<Board> GetAll(int id)
      {
         try
         {
            return Ok(_service.GetById(id));
         }
         catch (Exception e)
         {
            return BadRequest(e.Message);
         }
      }

      [HttpPost]
      public ActionResult<Board> Create([FromBody] Board newBoard)
      {
         try
         {
            return Ok(_service.Create(newBoard));
         }
         catch (Exception e)
         {
            return BadRequest(e.Message);
         }
      }

      [HttpPut("{id}")]
      public ActionResult<Board> EditBoard([FromBody] Board updated, int id)
      {
         try
         {
            updated.Id = id;
            return Ok(_service.Edit(updated));
         }
         catch (Exception e)
         {
            return BadRequest(e.Message);
         }
      }

      [HttpDelete("{id}")]
      public ActionResult<Board> Delete(int id)
      {
         try
         {
            return Ok(_service.Delete(id));
         }
         catch (Exception e)
         {
            return BadRequest(e.Message);
         }
      }
   }
}