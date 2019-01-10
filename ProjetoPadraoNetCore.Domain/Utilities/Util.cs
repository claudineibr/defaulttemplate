using System.Collections;

namespace ProjetoPadraoNetCore.Domain.Utilities
{
    public class Util
    {
        public static bool IsNotEmpty(object obj)
        {
            return !(obj is ICollection collection) || collection.Count > 0;
        }
    }
}
