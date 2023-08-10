using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicaComic.Datas
{
    /// <summary>
    /// ComicRandomData
    /// </summary>
    public class ComicRandomData
    {
        /// <summary>
        /// $.comics
        /// </summary>
        [JsonPropertyName("comics")]
        public List<CategoryComic> Comics { get; set; }
    }
}
