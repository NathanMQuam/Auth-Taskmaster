using System;
using System.Collections.Generic;
using Auth_TaskMaster.Models;
using Auth_TaskMaster.Repositories;

namespace Auth_TaskMaster.Services
{
   public class TodosService
   {
      private readonly TodosRepository _repo;

      public TodosService(TodosRepository repo)
      {
         _repo = repo;
      }

      internal IEnumerable<Todo> GetAll()
      {
         return _repo.GetAll();
      }

      internal Todo GetById(int id)
      {
         Todo data = _repo.GetById(id);
         if (data == null)
         {
            throw new Exception("Invalid Id");
         }
         return data;
      }

      internal Todo Create(Todo newTodo)
      {
         return _repo.Create(newTodo);
      }

      internal Todo Edit(Todo updated)
      {
         Todo data = GetById(updated.Id);

         data.Name = updated.Name != null ? updated.Name : data.Name;
         data.Description = updated.Description != null ? updated.Description : data.Description;

         return _repo.Edit(data);
      }

      internal String Delete(int id)
      {
         // NOTE: Why do we declare data? We don't use it...
         Todo data = GetById(id);
         _repo.Delete(id);
         return "delorted";
      }
   }
}