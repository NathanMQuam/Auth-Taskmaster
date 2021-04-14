namespace Auth_TaskMaster.Models
{
    public class Todo
    {
         public Todo()
      {
      }

      public int Id { get; set; }
      public string Name { get; set; }
      public string Description {get;set;}

      public string boardId {get;set;}

      public string creatorId{get;set;}
    }
}