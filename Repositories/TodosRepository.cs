using System.Collections.Generic;
using System.Data;
using Dapper;
using Auth_TaskMaster.Models;

namespace Auth_TaskMaster.Repositories
{
   public class TodosRepository
   {
      private readonly IDbConnection _db;

      public TodosRepository(IDbConnection db)
      {
         _db = db;
      }

      internal IEnumerable<Todo> GetAll()
      {
         string sql = "SELECT * FROM todos;";
         return _db.Query<Todo>(sql);
      }

      internal Todo GetById(int id)
      {
         string sql = "SELECT * FROM todos WHERE id = @id;";
         return _db.QueryFirstOrDefault<Todo>(sql, new { id });
      }

      internal Todo Create(Todo newTodo)
      {
         string sql = @"
         INSERT INTO todos
         (name, description, boardId, creatorId, completed)
         VALUES
         (@name, @description, @boardId, @creatorId, @completed);";
         int id = _db.ExecuteScalar<int>(sql, newTodo);
         newTodo.Id = id;
         return newTodo;
      }

      internal Todo Edit(Todo data)
      {
         string sql = @"
         UPDATE todos
         SET
            name = @name,
            description = @description,
            completed = @completed
         WHERE id = @id;
         SELECT * FROM todos WHERE id = @id;";
         Todo returnTodo = _db.QueryFirstOrDefault<Todo>(sql, data);
         return returnTodo;
      }

      internal void Delete(int id)
      {
         string sql = "DELETE FROM todos WHERE Id = @id LIMIT 1";
         _db.Execute(sql, new { id });
      }
   }
}