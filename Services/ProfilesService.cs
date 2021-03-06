using System;
using Models;
using Auth_TaskMaster.Repositories;

namespace Auth_TaskMaster.Services
{
   public class ProfilesService
   {
      private readonly ProfilesRepository _repo;
      public ProfilesService(ProfilesRepository repo)
      {
         _repo = repo;
      }
      internal Profile GetOrCreateProfile(Profile userInfo)
      {
         Profile profile = _repo.GetById(userInfo.Id);
         if (profile == null)
         {
            return _repo.Create(userInfo);
         }
         return profile;
      }

      internal Profile GetProfileById(string id)
      {
         Profile profile = _repo.GetById(id);
         if (profile == null)
         {
            throw new Exception("Invalid Id");
         }
         return profile;
      }
   }
}