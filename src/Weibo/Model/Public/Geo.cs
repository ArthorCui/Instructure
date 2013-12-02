using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Weibo.Model
{
    /// <summary>
    /// 地理信息
    /// </summary>
    [Serializable]
    public class Geo
    {
        /// <summary>
        /// 经度坐标
        /// </summary>
        [JsonProperty(PropertyName = "longitude")]
        public string Longitude { get; set; }

        /// <summary>
        /// 纬度坐标
        /// </summary>
        [JsonProperty(PropertyName = "latitude")]
        public string Latitude { get; set; }

        /// <summary>
        /// 所在城市的城市代码
        /// </summary>
        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }

        /// <summary>
        /// 所在省份的省份代码
        /// </summary>
        [JsonProperty(PropertyName = "province")]
        public string Province { get; set; }

        /// <summary>
        /// 所在城市的城市名称
        /// </summary>
        [JsonProperty(PropertyName = "city_name")]
        public string CityName { get; set; }

        /// <summary>
        /// 所在省份的省份名称
        /// </summary>
        [JsonProperty(PropertyName = "province_name")]
        public string ProvinceName { get; set; }

        /// <summary>
        /// 所在的实际地址，可以为空
        /// </summary>
        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }

        /// <summary>
        /// 地址的汉语拼音，不是所有情况都会返回该字段
        /// </summary>
        [JsonProperty(PropertyName = "pinyin")]
        public string Pinyin { get; set; }

        /// <summary>
        /// 更多信息，不是所有情况都会返回该字段
        /// </summary>
        [JsonProperty(PropertyName = "more")]
        public string More { get; set; }
    }
}
