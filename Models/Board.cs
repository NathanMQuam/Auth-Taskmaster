namespace Auth_TaskMaster.Models
{
    public class Board
    {
         public Board()
      {
      }

      public int Id { get; set; }
      public string Name { get; set; }
      public string Description {get;set;}
      public string creatorId{get;set;}
      public bool openToPublicView {get;set;}
    }
}