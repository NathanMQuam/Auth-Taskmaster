namespace Auth_TaskMaster.Models
{
   public class Board
   {
      public Board()
      {
      }

      public int Id { get; set; }
      public string Name { get; set; }
      public string Description { get; set; }
      public string CreatorId { get; set; }
      public bool OpenToPublicView { get; set; }
   }
}