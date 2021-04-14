using System;
using Microsoft.AspNetCore.Mvc;
using Auth_TaskMaster.Models;
using Auth_TaskMaster.Services;

namespace Auth_TaskMaster.Controller
{
   [ApiController]
   [Route("api/[controller]")]
   public class TodosController : ControllerBase
   {
      private readonly TodosService _service;
      public TodosController(TodosService service)
      {
         _service = service;
      }

      [HttpGet]
      public ActionResult<Todo> Get()
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
      public ActionResult<Todo> GetAll(int id)
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
      public ActionResult<Todo> Create([FromBody] Todo newTodo)
      {
         try
         {
            return Ok(_service.Create(newTodo));
         }
         catch (Exception e)
         {
            return BadRequest(e.Message);
         }
      }

      [HttpPut("{id}")]
      public ActionResult<Todo> EditTodo([FromBody] Todo updated, int id)
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
      public ActionResult<Todo> Delete(int id)
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