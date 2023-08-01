using BussinessLayer.Repository;
using Data.Model.Common;
using DataAcessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.RepositoryManager
{
    public class Common : ICommon
    {
        private readonly ICommonData _CommonData;
        public Common(ICommonData commonData)
        {
            _CommonData= commonData;
        }

        public IEnumerable<CountryDto> GetListOfCountry()
        {
            var countryData = _CommonData.GetListOfCountry();
            var countryList = new List<CountryDto>();
            if(countryData!=null && countryData.Count()>0)
            {
                foreach(var linetiem in countryData)
                {
                    countryList.Add(new CountryDto
                    {
                        Id = linetiem.Id,
                        Iso=linetiem.Iso,
                        Iso3 = linetiem.Iso3,
                        Name = linetiem.Name,
                        NiceName = linetiem.NiceName,
                        NumCode = linetiem.NumCode,
                        PhoneCode= linetiem.PhoneCode,
                    });
                }
                return countryList;
            }
            return new List<CountryDto>();
        }
    }
}
