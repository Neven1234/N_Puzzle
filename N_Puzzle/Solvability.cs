using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Puzzle
{
    internal class Solvability
    {
        public bool Resolvable(List<int> l, int N)
        {
            int counter = 0;
            decimal index = 0;
            for (int i = 0; i < l.Count; i++)
            {
                if (l[i] == 0)
                {
                    index = (i / N) + 1;
                    index = Math.Ceiling(index);
                    continue;
                }
                for (int j = i + 1; j < l.Count; j++)
                {
                    if (l[j] == 0)
                    {

                        continue;
                    }
                    if (l[i] > l[j])
                    {
                        counter++;
                    }
                }

            }
            int c = counter;
            if (N % 2 != 0 && counter % 2 == 0)//odd
            {
                return true;
            }
            else if (N % 2 == 0 && counter % 2 != 0 && index % 2 != 0)//even
            {
                return true;
            }
            else if (N % 2 == 0 && counter % 2 == 0 && index % 2 == 0)//even
            {
                return true;
            }
            else
                return false;

        }
    }
}
