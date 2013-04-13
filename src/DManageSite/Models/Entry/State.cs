using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SubSonic.SqlGeneration.Schema;

namespace DManageSite.Models.Entry
{
    [Serializable]
    [SubSonicTableNameOverride("State")]
    public class State
    {
        [SubSonicPrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string IMEI { get; set; }
        public string IMSI { get; set; }
        public string Model { get; set; }
        public DateTime Date { get; set; }
        public string Address { get; set; }
        public int ProvinceId { get; set; }
        public int CityId { get; set; }
        public int BrandId { get; set; }
        public string HttpUrl { get; set; }
        public string PostData { get; set; }
        public string ModelCode { get; set; }
        public DateTime CreateTime { get; set; }
        public int Status { get; set; }
    }
}