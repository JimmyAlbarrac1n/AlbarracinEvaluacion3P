using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbarracinEvaluacion3P.ModelsJA
{
    public class EpisodioJA
    {
            public int id { get; set; }
            public string name { get; set; }
            public string air_date { get; set; }
            public string episode { get; set; }
            public string[] characters { get; set; }
            public string url { get; set; }
            public DateTime created { get; set; }

    }
}
