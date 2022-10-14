using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL.RussIgrush.Katalog.Models
{
    public class TipOtdelaModel : SchemaModel
    {
        [Column("id_otdel")]
        public int OtdelID { get; set; }
    }
}
