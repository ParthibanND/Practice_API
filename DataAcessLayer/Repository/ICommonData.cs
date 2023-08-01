using DataBase.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Repository
{
    public interface ICommonData
    {
        IEnumerable<Country> GetListOfCountry();
    }
}
