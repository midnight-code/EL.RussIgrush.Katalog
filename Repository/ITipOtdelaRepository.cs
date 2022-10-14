using EL.RussIgrush.Katalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL.RussIgrush.Katalog.Repository
{
    public interface ITipOtdelaRepository
    {
        Task<TipOtdelaModel> GetTipOtdelaById(int id);
        Task<IEnumerable<TipOtdelaModel>> GetTipOtdelaByOtdelId(int idOtdel);
    }
}
