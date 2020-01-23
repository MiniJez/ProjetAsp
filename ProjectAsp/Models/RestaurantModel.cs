using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAsp.Models
{

    public class Adresse
    {
        public int ID { get; set; }
        [ForeignKey("restaurant")]
        public int restoID { get; set; }
        public string rue { get; set; }
        public string cp { get; set; }
        public string ville { get; set; }
        public Restaurant restaurant { get; set; }
    }

    public class Restaurant
    {
        public int ID { get; set; }
        public string nom { get; set; }
        public string tel { get; set; }
        public string email { get; set; }
        public Adresse adresse { get; set; }
        public Note note { get; set; } 
    }

    public class Note
    {
        public int ID { get; set; }
        [ForeignKey("restaurant")]
        public int restoID { get; set; }
        public Double note { get; set; }
        public DateTime dateDerniereVisite { get; set; }
        public string commentaire { get; set; }
        public Restaurant restaurant { get; set; }
    }
}
