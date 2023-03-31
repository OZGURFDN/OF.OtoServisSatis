using System.Collections.Generic;
using System.Linq;
using OtoServisSatis.DAL;
using OtoServisSatis.Entities;

namespace OtoServisSati.BL
{
    public class MarkaManager
    {
        DatabaseContext context = new DatabaseContext();

        public List<Marka> GetAll()
        {
            return context.Markalar.ToList();
        }
    }
}