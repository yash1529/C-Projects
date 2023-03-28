using System;
using System.Collections.Generic;
using System.Linq;

namespace searchbox
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> WordFound = new HashSet<string>();
            string[] arr = { "pink", "redpink", "computer", "laptop", "shoe", "shoebite", "Nikeshoe new red" };
            Console.Write("Give an input : ");
            string userinput = Console.ReadLine();



            //to remove appostrophie if its there
            userinput = userinput.Replace('"', ' ').Trim();
            userinput = userinput.Replace("'", "").Trim();
            if (!(userinput.Contains(",") || userinput.Contains(" "))) userinput += ",";//convert into list



            //given user input is converted to list as per the whitespace or commas.
            List<string> userinputlist = new List<string>();
            if (userinput.Contains(','))
            {
                userinputlist = userinput.Split(',').ToList();
            }
            else if (userinput.Contains(' '))
            {
                userinputlist = userinput.Split(' ').ToList();
            }



            while (userinputlist.Contains("")) userinputlist.Remove("");//remove all white spaces string which are there in it




            //invoking the functions:
            print(makedict(userinputlist, arr));
            Console.ReadLine();




        }



        static Dictionary<string, HashSet<string>> makedict(List<string> userlist, string[] listarr)
        {
            //make key value pair for list of words found from userinput in listarr 
            Dictionary<string, HashSet<string>> foundkeywords = new Dictionary<string, HashSet<string>>();
            foreach (string userlistword in userlist)
            {
                foreach (string givenlist in listarr)
                {
                    if (givenlist.Contains(userlistword))
                    {
                        if (foundkeywords.ContainsKey(userlistword))
                        {
                            //entry already exsisted
                            foundkeywords[userlistword].Add(givenlist);
                        }
                        else
                        {
                            //new entry
                            foundkeywords.Add(userlistword, new HashSet<string>() { givenlist });
                        }
                    }
                }
            }
            return foundkeywords;
        }



        static void print(Dictionary<string, HashSet<string>> foundkeywordlist)
        {
            //to print the list of words founds in arr
            Console.WriteLine("\n\n");
            int i = 0;
            foreach (var kvp in foundkeywordlist)
            {
                if (kvp.Value.Count > 0 && kvp.Key.Length > 2)
                {
                    Console.WriteLine("{0}'s found in {1} words", kvp.Key, kvp.Value.Count);
                    kvp.Value.ToList<String>().ForEach(x => Console.WriteLine(x));
                    Console.WriteLine("\n*************************************************************\n");
                }
            }
        }
    }
}
    

