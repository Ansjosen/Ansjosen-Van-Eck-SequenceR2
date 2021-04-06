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
            List<int> list = new List<int>();
            int elementAtLastIndex = -1;
            int elementLast = -1;
            list.Add(50); list.Add(0);

            List<string> dinosaurs = new List<string>();

            dinosaurs.Add("Tyrannosaurus");     //0
            dinosaurs.Add("Amargasaurus");      //1
            dinosaurs.Add("Mamenchisaurus");    //2
            dinosaurs.Add("Brachiosaurus");     //3
            dinosaurs.Add("Deinonychus");       //4
            dinosaurs.Add("Tyrannosaurus");     //5
            dinosaurs.Add("Tyrannosaurus");     //6
            //count = 7 (dinosaurer)
            int dino = dinosaurs.LastIndexOf("Tyrannosaurus", dinosaurs.Count - 2); // == 5
                dino = dinosaurs.LastIndexOf("Tyrannosaurus", dinosaurs.Count - 1); // == 6
                dino = dinosaurs.LastIndexOf("Tyrannosaurus", 3);                   // == 0

            //Best of 10 --> 90

            //int nrOfLoops = 1882, countLoops = 0;  // --> 3,0 VINDER + loops nødvendig for alle tal fra 0 - 100
            //int nrOfLoops = 3856, countLoops = 0;  // --> 4,0 VINDER + loops nødvendig for alle tal fra 0 - 100

            //provet fra 10,0 - 30,0
            //int nrOfLoops = 1596, countLoops = 0;  // --> 17,0 VINDER + loops nødvendig for alle tal fra 0 - 100
            //int nrOfLoops = 6978, countLoops = 0;  // --> 12,0 VINDER + loops nødvendig for alle tal fra 0 - 100
            int nrOfLoops = 1596, countLoops = 0;  // --> 12,0 VINDER + loops nødvendig for alle tal fra 0 - 100
            //29 27 22 21 12
            //001020221605...
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
            } while (countLoops <= nrOfLoops);
            //list.Add(0); list.Add(1); list.Add(0); list.Add(2); list.Add(0); list.Add(1); list.Add(6);
            string combindedString = string.Join(",", list.ToArray());
            Console.WriteLine(combindedString);
            Console.WriteLine("Distinct:");  // oldArray.Distinct().ToArray();
            var arr =  list.ToArray().Distinct().ToArray();
            Array.Sort(arr);
            combindedString = string.Join(",", arr);
            Console.WriteLine(combindedString);
            if (IsOk(arr))
            {
                Console.WriteLine("GO!");
            }
            else
            {
                Console.WriteLine("NoGo");
            }
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
                    Console.WriteLine("Element at arr[" + i + "] " + arr[i] );
                    return false;
                }
            }
            return true;
        }
    }
}
