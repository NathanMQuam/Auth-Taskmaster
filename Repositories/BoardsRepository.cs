using System.Collections.Generic;
using System.Data;
using Dapper;
using Auth_TaskMaster.Models;

namespace Auth_TaskMaster.Repositories
{
   public class BoardsRepository
   {
      private readonly IDbConnection _db;

      public BoardsRepository(IDbConnection db)
      {
         _db = db;
      }

      internal IEnumerable<Board> GetAll()
      {
         string sql = "SELECT * FROM boards;";
         return _db.Query<Board>(sql);
      }

      internal Board GetById(int id)
      {
         string sql = "SELECT * FROM boards WHERE id = @id;";
         return _db.QueryFirstOrDefault<Board>(sql, new { id });
      }

      internal Board Create(Board newBoard)
      {
         string sql = @"
         INSERT INTO boards
         (name, description, creatorId, openToPublicView)
         VALUES
         (@name, @description, @creatorId, @openToPublicView);";
         int id = _db.ExecuteScalar<int>(sql, newBoard);
         newBoard.Id = id;
         return newBoard;
      }

      internal Board Edit(Board data)
      {
         string sql = @"
         UPDATE boards
         SET
            name = @name,
            description = @description,
            openToPublicView = @openToPublicView
         WHERE id = @id;
         SELECT * FROM boards WHERE id = @id;";
         Board returnBoard = _db.QueryFirstOrDefault<Board>(sql, data);
         return returnBoard;
      }

      internal void Delete(int id)
      {
         string sql = "DELETE FROM boards WHERE Id = @id LIMIT 1";
         _db.Execute(sql, new { id });
      }
   }
}