using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HasherV2._0
{
    class DeHasher
    {
        String answer;
        String letters = "acdegilmnoprstuw";

        public String deHash(long key, long length, String guess)
        {
            int[] phish = new int[length];
            if(guess != null){
                for (int i = 0; i < length; i++)
                {
                    phish[i] = letters.IndexOf(guess[i]);
                }
            }
            while(phish.Sum(i => i) != phish.Length * letters.Length){
                var test = String.Join("", phish.Select(i => letters[i].ToString()).ToArray());
                if(hash(test) == key){
                    answer = test;
                    break;
                }
                phish[phish.Length - 1]++;
                for (int i = test.Length; i >= 0; i++ )
                {
                    if(test[i] >= letters.Length){
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
            return answer;
        }
        public int hash(String s)
        {
            int h = 7;
            for (int i = 0; i < s.Length; i++)
            {
                h = h * 37 + letters.IndexOf(s[i]);
            }
            return h;
        }
    }
}
