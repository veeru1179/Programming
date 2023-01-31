using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Competitive_Programming
{
    class Program
    {
        static void Main(string[] args)
        {
            //Type t = typeof(int);
            //t.GetMethods();
            //double.IsInfinity(1.0d / 0);
            //double a = 1.0d / 0;
            //Console.WriteLine(a);
            //Console.WriteLine(double.IsInfinity(1.0d / 0));
            //Console.WriteLine(t.GetFields());

            //var person = new ExpandoObject();
            //Console.WriteLine();

            //Array array =   Array.CreateInstance( typeof(int) ,3,2);

            ////array.g
            //var obje = Exercise.GetCharacterCount("Veeran janeya");

            ////UpperTOLower upperTOLower = new UpperTOLower();
            ////upperTOLower.ConvertUppertoLower();

            ////FibNumbers febnu = new FibNumbers();
            ////febnu.NfibNumber(Convert.ToInt16(Console.ReadLine()));

            ////binarySearch binarySearch = new binarySearch();
            ////binarySearch.findelement();
            //Console.ReadLine();

            //Console.WriteLine("this is{1},{2} some thing likethis", 1, 2);

            leetcode letcodeobj = new leetcode();
            //int count= letcodeobj.maxsubstringcount("Veeranjaneya");
            // Console.WriteLine(count);

            int re = letcodeobj.RomantoNumber("MCMXCIV");
            Console.WriteLine(re);
            Console.ReadLine();
        }
    }
    public class Exercise
    {
        // TODO: fix this method - remove boxing & unboxing, and return correct result
        public static Dictionary<char,int> GetCharacterCount(string name)
        {
            var result = new Dictionary<Char, int>();
            foreach (char c in name.ToLower())
            {
                if (!Char.IsWhiteSpace(c))
                {
                    if (result.ContainsKey(c))
                    {
                        result[c] += 1;
                    }
                    else
                    {
                        result.Add(c, 1);
                    }
                }
            }
            return result;
        }
    }
    class UpperTOLower
    {
        public void ConvertUppertoLower ( )
        {
            string input= Console.ReadLine();
            string output=string.Empty;
            char[] inputarray = input.ToCharArray();
            for(int i= 0; i < input.Length;i++)
            {
                if (char.IsUpper(inputarray[i]))
                {
                    output += inputarray[i].ToString().ToLower();
                }
                else
                {
                    output += inputarray[i].ToString().ToUpper();
                }

               // if (inputarray[i] >= 'A' && inputarray[i] <='Z')
               // {                   
               //     inputarray[i] = (char)(inputarray[i] + 32);
               // }
               //else if (inputarray[i] >= 'a' && inputarray[i] <= 'z')
               // {
               //     inputarray[i] = (char)(inputarray[i] - 32);
               // }
               // output = output + inputarray[i].ToString();            
            }
            Console.WriteLine(output);
        }
    }

    class FibNumbers
    {
        public void NfibNumber(int n)
        {
            int feb1 = 1; int feb2 = 1;int combine = feb1 + feb2;
            if (n<=2)
            {
                Console.WriteLine( feb2);
            }
            else
            {
                for (int i = 3; i < n; i++)
                {
                    feb1 = feb2;
                    feb2 = combine;
                    combine= feb1 + feb2;
                }
                Console.WriteLine(combine);
            }
        }
    }

    class binarySearch
    {
        public void findelement()
        {
            Console.Write("Please enter count of elements in Array: ");
            int N = Convert.ToInt16(Console.ReadLine());
            Console.Write("Please enter elements in Array with space:");
            int[] array = Array.ConvertAll(Console.ReadLine().Split(' ') , int.Parse) ;

            Console.Write("Please Enter which number to find: ");
            int K = Convert.ToInt16(Console.ReadLine());
            string output = string.Empty;
            if (output!= "The Element didn't find in the array")
            {
                  output = FindElementinRecurrive(array, K, 0, N - 1);
            }
           
            Console.WriteLine(output);
        }

        public string FindElementinRecurrive(int[] array ,int K,int start,int end)
        {
            if (start> end)
            {
               return  "The Element didn't find in the array";                 
            }

            int mid = (start + end) / 2;

            if (array[mid]==K)
            {
                return "The Element found out at index: "+mid ;
            }
            else if (array[mid]<K)
            {
                return FindElementinRecurrive(array, K, mid + 1, end);
            }
            else
            {
               return FindElementinRecurrive(array, K, start, mid - 1);
            }
        }
    }

    class leetcode
    {
        public int maxsubstringcount(string s)
        {
            Hashtable notdub = new Hashtable();
            Queue notans = new Queue();
            var maxlen = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (notdub.ContainsKey(s[i]))
                {
                    while (notans.Count > 0 && notdub.Contains(s[i]))
                    {
                        var curnum = notans.Dequeue();
                        notdub.Remove(curnum);
                    }
                }
                else
                {
                    notdub.Add(s[i], true);
                    notans.Enqueue(s[i]);
                    int curlen = notans.Count;
                    maxlen = curlen > maxlen ? curlen : maxlen;
                }
            }
            return maxlen;
        }

        // Finding last word lenght in the given string

        public int LengthOfLastWord(string s)
        {
            //string[] wordArray = s.Trim().Split(' ').ToArray();
            //return wordArray[wordArray.Length - 1].Length;
            return s.Trim().Split(' ').LastOrDefault().Length;
        }
// Convert Roman Numbers to Normal Numbers
        public int RomantoNumber(string s)
        {
            Dictionary<char, int> roman = new Dictionary<char, int>()
            {
                { 'I',1},{'V',5 },{'X',10},{'L',50},{'C',100},{'D',500},{'M',1000}
            };
            int result = 0;
             int nextindex = 1;
            for (int i = 0; i < s.Length; i++, nextindex++)
            {
                var current = roman[s[i]];
                var next = nextindex < s.Length ?   roman[s[nextindex]]:0;
                // nextindex = nextindex + 1;
                if (current<next)
                {
                    i = nextindex;
                    nextindex = nextindex + 1;
                    result +=  next - current;
                   
                    continue;
                }
                result += current;
            }
            return result;
        }
        //Longest Prefix
           public string LongestPrefix(string[] input)
        {
           
            if (!input.Any())
            {
                return string.Empty;
            }
            int minlen = input.Min(y => y.Length);
            string shortestWord = input.FirstOrDefault(x => x.Length == minlen);
            for (var i = shortestWord.Length; i > 0; i--)
            {
                if (input.All(a => a.StartsWith(shortestWord )))
                    return shortestWord ;
                shortestWord = shortestWord.Substring(0, i - 1);
            }
            return null;
        }
    }
}
 
