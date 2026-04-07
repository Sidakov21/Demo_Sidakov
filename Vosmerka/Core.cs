using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vosmerka
{
    internal static class Core
    {
        public static user23Entities Context = new user23Entities();

        public static User AuthUser = null;
    }

    public partial class Product
    {
        //public bool IsGreatThen10k => MinCost > 10000;

        //public string Materials => string.Join(", ", ProuctMaterial.Select(pm => pm.Material.Name));
    }
}
