using System;
using System.Collections.Generic;
using Auth_TaskMaster.Models;
using Auth_TaskMaster.Repositories;

namespace Auth_TaskMaster.Services
{
   public class BoardsService
   {
      private readonly BoardsRepository _repo;

      public BoardsService(BoardsRepository repo)
      {
         _repo = repo;
      }

      internal IEnumerable<Board> GetAll()
      {
         return _repo.GetAll();
      }

      internal Board GetById(int id)
      {
         Board data = _repo.GetById(id);
         if (data == null)
         {
            throw new Exception("Invalid Id");
         }
         return data;
      }

      internal Board Create(Board newBoard)
      {
         return _repo.Create(newBoard);
      }

      internal Board Edit(Board updated)
      {
         Board data = GetById(updated.Id);

         data.Name = updated.Name != null ? updated.Name : data.Name;
         data.Description = updated.Description != null ? updated.Description : data.Description;
         data.OpenToPublicView = updated.OpenToPublicView;

         return _repo.Edit(data);
      }

      internal String Delete(int id)
      {
         // NOTE: Why do we declare data? We don't use it...
         Board data = GetById(id);
         _repo.Delete(id);
         return "delorted";
      }
   }
}