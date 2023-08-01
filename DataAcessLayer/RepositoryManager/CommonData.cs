using DataAcessLayer.Repository;
using DataBase.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.RepositoryManager
{
    public class CommonData : ICommonData
    {
        private readonly PrjDashBoardContext _dbContext;
        public CommonData(PrjDashBoardContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Country> GetListOfCountry()
        {
            return _dbContext.Countries.ToList();
        }
    }
}
