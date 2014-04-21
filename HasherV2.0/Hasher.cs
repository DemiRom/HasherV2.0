using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HasherV2._0
{
    class Hasher
    {
        long h;

        String letters = "acdegilmnoprstuw";

        Dialog dialog = new Dialog();

        public Hasher()
        {

        }
        public long Hash(String s)
        {
            h = 7;
            for (int i = 0; i < s.Length; i++ )
            {   
                h = h * 37 + s.IndexOf(letters[i]);   
            }
            return h;
        }
    }
}
