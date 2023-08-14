using DataAcessLayer.Repository;
using DataBase.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.RepositoryManager
{
    public class AuthenticationData : IAuthenticationData
    {
        private readonly PrjDashBoardContext _dbContext;
        public AuthenticationData(PrjDashBoardContext DbContext) 
        {
            _dbContext = DbContext;
        }

        public User Authenticater(string name , string email)
        {
            var result = _dbContext.Users.FirstOrDefault(x=>x.Name==name && x.Email==email);
            return result;
        }
    }
}
