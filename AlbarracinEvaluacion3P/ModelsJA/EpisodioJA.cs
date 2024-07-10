using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbarracinEvaluacion3P.ModelsJA
{
    [Table("episodio")]
    public class EpisodioJA
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string name { get; set; }
        public string air_date { get; set; }
        public string episode { get; set; }
        public string url { get; set; }
        public string created { get; set; }

    }
}
