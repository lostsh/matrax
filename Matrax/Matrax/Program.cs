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
            bool clear = false;
            bool sleep = true;
            foreach(string s in args){
                if (s.Equals("--no-block")) Console.WriteLine("Not yet implemented");//Column.BLOCK = false;
                if (s.Equals("--help")) { Console.WriteLine("Options are :\n\t--no-block : do not display block char\n\t--clear : clear on each frame\n\t--no-sleep : do not sleep between each frame"); Console.ReadKey(); return; }
                if (s.Equals("--clear")) clear = true;
                if (s.Equals("--no-sleep")) sleep = false;
            }


            int height = Console.WindowHeight;
            int width = Console.WindowWidth;
            //Console.SetBufferSize(width+1, height+1);
            List<Column> columns = new List<Column>();
            for (int i = 0; i < width; i++) columns.Add(new Column { Height = height, X = i });

            StringBuilder cout = new StringBuilder();
            for (int i = 0; i < height; i++)
            {
                columns.ForEach(c => cout.Append(c.get(i)));
                cout.Append('\n');
            }
            Console.Write(cout);

            while (true)
            {
                columns.ForEach(c => c.writeFade());
                if(sleep)System.Threading.Thread.Sleep(150);
            }
        }
    }
}
