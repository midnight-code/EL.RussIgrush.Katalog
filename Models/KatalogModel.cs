using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL.RussIgrush.Katalog.Models
{
    public class KatalogModel : SchemaModel
    {
        [Column("id_tip")]
        public int TipOtdelID { get; set; }
        [Column("isbn")]
        public string ISBN { get; set; } = string.Empty;
        [Column("cena")]
        public string Cena { get; set; } = string.Empty;
        [Column("foto_url_full")]
        public string ImageUrl { get; set; } = string.Empty;
    }
}
