using System;
using System.Collections.Generic;
using System.Text;

namespace Heming
{
    class ControlBits
    {
        public List<bool> Bits { get; set; }

        public ControlBits()
        {
            Bits = new List<bool>();
            
        }
         public void CreateNewBits(List<bool> bit)
        {
            int k = 0;
            for(int i = 0; i < 16; i++)
            {
                if (!step(i+1)&& k<bit.Count)
                {
                    Bits.Add(bit[k]);
                    k++;
                }
                else
                {
                    Bits.Add(false);
                }
            }
        }
        public static bool step(int a)
        {
            if (a == 2 || a==1) return true;
            else if (a % 2 == 0) return step(a / 2);
            else return false;
        }

      
        public void UpdateBits()
        {
            for(int i = 1; i <= Bits.Count; i++)
            {
                if (step(i))
                {
                    string sec = Steps(i);
                    for (int j=i+1;j <=Bits.Count; j++)
                    {
                        string det = Steps(j);
                        if (sec[0] == det[det.Length - sec.Length])
                        {
                            RemoveBool(i - 1);
                        }

                    }
                }
            }
        }

        private void RemoveBool(int i)
        {
            if (Bits[i] == true) Bits[i] = false;
            else Bits[i] = true;
        }

        private string Steps(int i)
        {
            if (i != 1)
            {
                var m = i % 2;
                i = i / 2;
                return Steps(i) + m.ToString();
            }
            else
            {
                return "1";
            }
        }

    }
}
