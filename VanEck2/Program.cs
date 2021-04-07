using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanEck2
{
    class Program
    {
        static void Main(string[] args)
        {
            //next challenge: longest pending number in each serie, 00 01 02 03 ... 99
            List<int> list = new List<int>();
            int elementAtLastIndex = -1;
            int elementLast = -1;
            int max = 0, min = 1000000, minValue =-1, maxValue =-1;
            //int[] arr;

            for (int i = 0; i < 101; i++)
            {
                list.Clear();
                list.Add(i); list.Add(0);

                int nrOfLoops = 10000, countLoops = 0;  // --> 17,0 VINDER + loops nødvendig for alle tal fra 0 - 100
                
                do
                {
                    countLoops++;
                    elementLast = -1;
                    elementAtLastIndex = -1;
                                
                    elementLast = list.ElementAt(list.Count - 1);
                    elementAtLastIndex = list.LastIndexOf(elementLast, list.Count - 2);
                    if (elementAtLastIndex == -1)
                    {
                        list.Add(0);
                    }
                    else
                    {
                        elementAtLastIndex = list.Count - 1 - elementAtLastIndex;
                        //Den fundne position trækkes fra listens længde for at finde afstanden bagud
                        list.Add(elementAtLastIndex);
                    }

                    var arr = list.ToArray().Distinct().ToArray();
                    Array.Sort(arr);


                    if (arr.Length >= 100 )
                    {
                        if (IsOk(arr))
                        {
                            //Console.WriteLine("Go!");
                            break; ;
                        }
                        else
                        {
                            //NOP
                        }
                    }
                    



                } while (countLoops <= nrOfLoops);
                
                
                //list.Add(0); list.Add(1); list.Add(0); list.Add(2); list.Add(0); list.Add(1); list.Add(6);
                string combindedString = string.Join(",", list.ToArray());
                //Console.WriteLine(combindedString);
                //Console.WriteLine("Distinct:");  // oldArray.Distinct().ToArray();
                //arr =  list.ToArray().Distinct().ToArray();
                //Array.Sort(arr);
                //combindedString = string.Join(",", arr);
                //Console.WriteLine(combindedString);
                if (countLoops < min)
                {
                    minValue = i;
                    min = countLoops;
                }
                if (countLoops > max)
                {
                    max = countLoops;
                    maxValue = i;

                }

                Console.WriteLine("Value: " + i + ", #loops " + countLoops);
            }
            Console.WriteLine("min: " + minValue + ": " + min);
            Console.WriteLine("max: " + maxValue + ": " + max);
            Console.ReadLine();
        }

        private static bool IsOk(int[] arr)
        {
            //100 elementer
            if (arr.Length < 100)
            {
                Console.WriteLine("Bad length");
                return false;
            }
            for (int i = 0; i < 100; i++)
            {
                if (arr[i] != i)
                {
                    //Console.WriteLine("Element at arr[" + i + "] " + arr[i] );
                    return false;
                }
            }
            
            return true;
        }
    }
}
