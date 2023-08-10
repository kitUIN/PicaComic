using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicaComic.Responses
{
    /// <summary>
    /// 随机本子 返回
    /// </summary>
    public class ComicRandomResponse: PicaResponse
    {
        /// <summary>
        /// $.data
        /// </summary>
        [JsonPropertyName("data")]
        public ComicRandomData Data { get; set; }
    }
    
}
