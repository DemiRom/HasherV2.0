using System;
using System.Globalization;
using System.Linq;

namespace HasherV2._0
{
    class DeHasher
    {
        String _answer;
        private const String Letters = "acdegilmnoprstuw";

        public String DeHash(long key, long length, String guess)
        {
            var phish = new int[length];
            if(guess != null){
                for (var i = 0; i < length; i++)
                {
                    phish[i] = Letters.IndexOf(guess[i]);
                }
            }
            while(phish.Sum(i => i) != phish.Length * Letters.Length){
                var test = String.Join("", phish.Select(i => Letters[i].ToString(CultureInfo.InvariantCulture)).ToArray());
                if(Hash(test) == key){
                    _answer = test;
                    break;
                }
                phish[phish.Length - 1]++;
                for (var i = test.Length; i >= 0; i++ )
                {
                    if(test[i] >= Letters.Length){
                        phish[i] = 0;
                        phish[i - 1]++;
                    }
                    else
                    {
                        break;
                    }
                }
                return null;
            }
            return _answer;
        }
        public int Hash(String s)
        {
            return s.Aggregate(7, (current, t) => current*37 + Letters.IndexOf(t));
        }
    }
}
