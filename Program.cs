using System;
using System.Linq;

namespace creditcard1rec // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        public static int counter=0;
        static void Main(string[] args)
        {
            int missing = 0;
            Console.WriteLine("enter numbers");
            string number = Console.ReadLine();
            char[] ch = number.ToCharArray();
            for (int i = 0; i < ch.Length; i++)
            {
                if (ch[i]=='x')
                {
                    missing++;
                }
            }           
            char[] missar=new char[missing];//[0,0,0]
            for (int i = 0; i <missar.Length; i++)
            {
                missar[i]= '0';
            }            
            gothrough(ch, missar,Math.Pow(10,missing));            
        }
        public static void done()
        {
            Console.WriteLine(counter);
            Console.WriteLine("done");//end program
            Environment.Exit(1);
        }
        public static void gothrough(char[] frs,char[]run,double top1)
        {
            char[] c = new char[frs.Length];
            for (int i = 0; i < frs.Length; i++)
            {
                c[i] = frs[i];
            }
            //copy
            if (Luhn(converts(frs,run)))
            {
                Console.WriteLine(converts(frs, run));
                counter++;
                //add to list 
            }
            gothrough(c, add(run,top1),top1);
        }
        public static char[] add(char [] ent,double top)
        {            
            string num = string.Join("", ent.Select(i => i.ToString()).ToArray());
            int num1= int.Parse(num);            
            num1++;
            if (num1>=top-1)
            {
               done();
            }
            string num1s = num1.ToString();
            while (num1s.Length!=ent.Length)
            {

                num1s = '0' + num1s;
            }
            return num1s.ToCharArray();            
        }
        public static bool Luhn(string digits)
        {
            return digits.All(char.IsDigit) && digits.Reverse()
                .Select(c => c - 48)
                .Select((thisNum, i) => i % 2 == 0
                    ? thisNum
                    : ((thisNum *= 2) > 9 ? thisNum - 9 : thisNum)
                ).Sum() % 10 == 0;
        }
        public static string converts(char[] org, char[] fill)//fills in 
        {            
            int j = 0;
            for (int i = 0; i < org.Length; i++)
            {
                
                if (org[i]=='x')
                {
                    org[i] = fill[j];
                    j++;                           
                }
            }
            string results = string.Join("", org.Select(i => i.ToString()).ToArray());
            return results;
        }

    }
}