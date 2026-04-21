using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;

namespace KruzhokDemkaV2
{
    internal static class Core
    {
        public static user50Entities Context = new user50Entities();

        public static User AuthUser = null;
    }

    public partial class Product
    {
        public bool IsGreatThen10K => MinCost > 10000;
        public string Materials => 
            string.Join(", ", ProductMaterial.Select(pm => pm.Material.Name));
    }
}
