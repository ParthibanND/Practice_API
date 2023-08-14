using DataBase.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessLayer.Repository
{
    public interface IAuthenticationData
    {
        User Authenticater(string name, string email);
    }
}
