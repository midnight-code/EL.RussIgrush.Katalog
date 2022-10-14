using EL.RussIgrush.Katalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL.RussIgrush.Katalog.Repository
{
    public interface IKatalogrepository
    {
        Task<IEnumerable<KatalogModel>> GetAllKatalog();
        Task<KatalogModel> GetKatalogById(int id);
        Task<IEnumerable<KatalogModel>> GetKatalogByTipId(int idTip);
    }
}
