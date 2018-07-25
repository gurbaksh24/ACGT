using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp3
{
    class Program
    {
        int MinChanges(int maxPeriod, string[] acgt)
        {
            //Your code goes here
            int l, r;
            string temp = "";
            char[] cacgt;

            for (int i = 0; i < acgt.Length; i++)
            {
                temp += acgt[i];
            }

            cacgt = temp.ToCharArray();
            char []revcacgt=new char[temp.Length];
            l = CountPeriodicity(maxPeriod, cacgt);
            for(int i= cacgt.Length-1; i>=0;i--)
            {
                revcacgt[cacgt.Length - 1 - i] = cacgt[i];
            }
            //r = CountPeriodicity(maxPeriod, revcacgt);
            //return Math.Min(l, r);
            return l;
        }
        static int CountPeriodicity(int maxPeriod,char []cacgt)
        {
            int k = 0, flag = 0, c = 0;
            
            List<int> list = new List<int>();
            List<int> list1 = new List<int>();
            for (int i = 1; i <= maxPeriod; i++)
            {

                for (int j = i; j < cacgt.Length; j++)
                {
                    if (cacgt[k] != cacgt[j])
                    {
                        flag = 1;
                        break;
                    }
                    else
                    {
                        if (k + 1 != j)
                            k++;
                        else
                            k = 0;
                    }
                }
                if (flag == 0)
                    return 0;
            }
            k = 0;

            for (int z = 0; z < cacgt.Length; z++)
            {
                k = z;

                for (int i = z + 1; i <= maxPeriod; i++)
                {
                    for (int j = i; j < cacgt.Length; j++)
                    {
                        if ((cacgt[k] != cacgt[j]))
                        {
                            //Console.WriteLine(cacgt[k]+"\t"+cacgt[j]);
                            c++;

                            //cacgt[j] = cacgt[k];

                        }
                        if (k + 1 != i)
                            k++;
                        else
                            k = z;
                    }
                    k = z;
                    Console.WriteLine(i + ":" + c);
                    list.Add(c);
                    c = 0;

                }
                k = z;

                list1.Add(list.Min());
                maxPeriod = maxPeriod - maxPeriod * 2;

                for (int i = z - 1; i >= maxPeriod; i--)
                {
                    if (maxPeriod + z == 0)
                    {
                        for (int j = i; j >= 0; j--)
                        {
                            if ((cacgt[k] != cacgt[j]))
                            {
                                //Console.WriteLine(cacgt[k]+"\t"+cacgt[j]);
                                c++;

                                //cacgt[j] = cacgt[k];

                            }
                            if (k - 1 != i)
                                k--;
                            else
                                k = z;
                        }
                        k = z;
                        Console.WriteLine(i + ":" + c);
                        list.Add(c);
                        c = 0;
                    }
                }
                list1.Add(list.Min());
            }
            Console.WriteLine("dd");
            foreach(int ll in list1)
            {
                Console.WriteLine(ll);
            }
            //for(int i=)
            /*
            for (int i = 1; i <= maxPeriod; i++)
            {
                for (int j = i; j < cacgt.Length; j++)
                {
                    if (cacgt[k] != cacgt[j])
                    {
                        //Console.WriteLine(cacgt[k]+"\t"+cacgt[j]);
                        c++;

                        //cacgt[j] = cacgt[k];

                    }
                    if (k + 1 != i)
                        k++;
                    else
                        k = 0;
                }
                k = 0;
                Console.WriteLine(i + ":" + c);
                list.Add(c);
                c = 0;

            }
            */
            return list1.Min();

        }
        #region Testing code Do not change
        public static void Main(String[] args)
        {
            Program aCGT = new Program();
            String input = Console.ReadLine();
            do
            {
                var inputParts = input.Split('|');
                int maxPeriod = int.Parse(inputParts[0]);
                string[] acgt = inputParts[1].Split(',');
                Console.WriteLine(aCGT.MinChanges(maxPeriod, acgt));
                input = Console.ReadLine();
            } while (input != "-1");
        }
        #endregion
    }
}
