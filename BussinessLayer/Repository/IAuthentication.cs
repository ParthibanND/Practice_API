using Data.Model.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Repository
{
    public interface IAuthentication
    {
        string Authenticater(string name, string email);
    }
}
