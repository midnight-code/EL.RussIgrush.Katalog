using EL.RussIgrush.Katalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL.RussIgrush.Katalog.Repository
{
    public interface IOtdelRepository
    {
        Task<IEnumerable<OtdelModel>> GetAllOtdel();
        Task<OtdelModel> GetOtdelById(int id);
    }
}
