using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplifyPath
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Solution
    {
        /// <summary>
        /// if no folder goes up, say /home/../../, just return /.
        /// for consecutive /, replace with single /.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string SimplifyPath(string path)
        {
            if (path == null || path == string.Empty || path == "/")
            {
                return path;
            }
            
            const string Separator = @"/";
            string[] tokens = path.Split(Separator[0]);
            List<string> result = new List<string>();

            foreach(var token in tokens)
            {
                if (token == "..")
                {
                    if (result.Any())
                    {
                        // go to parent folder. remove last element.
                        result.RemoveAt(result.Count - 1);
                    }                    
                    else
                    {
                        // no folder to go up.
                        //throw new ArgumentException(@"bad format. .. in the beginning of string.");
                        result.Clear();
                    }
                }
                else if (token == string.Empty)
                {
                    //throw new ArgumentException(@"bad format. double /.");
                    //result.Add(token);
                    //multiple /, do nothing.
                }
                else if (token != ".")
                {
                    // add new entry.
                    result.Add(token);
                }
            }

            return Separator + string.Join(Separator, result);
        }
    }
}
