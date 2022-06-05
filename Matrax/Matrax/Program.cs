using System;
using System.Text;
using System.Collections.Generic;

namespace Matrax
{
    class Program
    {
        static void Main(string[] args)
        {
            /// App ouput settings
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;

            /// App arguments
            bool sleep = true;
            bool async = true;
            foreach (string s in args){
                if (s.Equals("--help")) { Console.WriteLine("Options are :\n" +
                    "\t--block : display block char at the column end\n" +
                    "\t--no-sleep : do not sleep between each frame\n" +
                    "\t--async    : fade column in an async way"); Console.ReadKey(); return; }
                if (s.Equals("--block")) Console.Error.WriteLine("bloc function not yet implemented");//Column.BLOCK = true;
                if (s.Equals("--async")) async = true;
                if (s.Equals("--no-sleep")) sleep = false;
            }

            /// Run the app
            int height = Console.WindowHeight;
            int width = Console.WindowWidth;
            List<Column> columns = new List<Column>();

            /// Draw initial screen
            for (int i = 0; i < width; i++) columns.Add(new Column { Height = height, X = i });
            StringBuilder cout = new StringBuilder();
            for (int i = 0; i < height; i++)
            {
                columns.ForEach(c => cout.Append(c.get(i)));
                cout.Append('\n');
            }
            Console.Write(cout);

            /// Update screen
            Random rand = new Random();
            while (true)
            {
                if (async)
                {
                    for(int i=0; i < columns.Count; i+=4)
                    {
                        columns[rand.Next(0, columns.Count)].writeFade();
                    }
                }
                else
                {
                    columns.ForEach(c => c.writeFade());
                }
                if(sleep)System.Threading.Thread.Sleep((async?50:150));
            }
        }
    }
}
