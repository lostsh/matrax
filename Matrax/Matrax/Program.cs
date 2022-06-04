using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

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
            Console.SetBufferSize(width+1, height+1);
            List<Column> columns = new List<Column>();
            for (int i = 0; i < width; i++) columns.Add(new Column { Height = height });
            while (true)
            {
                StringBuilder cout = new StringBuilder();
                for (int i = 0; i < height; i++)
                {
                    columns.ForEach(c => cout.Append(c.get(i)));
                    cout.Append('\n');
                }
                Console.Write(cout);
                columns.ForEach(c => c.fade());
                if(sleep)System.Threading.Thread.Sleep(150);
                if(clear)Console.Clear();
            }
        }

        /// <summary>
        /// Work for one column
        /// </summary>
        private static void test()
        {
            Column cl = new Column();
            cl.Height = Console.WindowHeight;
            System.Diagnostics.Debug.WriteLine("Console height : " + cl.Height);
            while (true)
            {
                StringBuilder cout = new StringBuilder();
                for (int i = 0; i < cl.Height; i++)
                {
                    cout.Append(cl.get(i));
                    cout.Append('\n');
                }
                Console.Write(cout);
                cl.fade();
                //System.Threading.Thread.Sleep(150);
                System.Threading.Thread.Sleep(550);
            }
        }

        private static void workNicely()
        {
            int height = Console.WindowHeight;
            int width = Console.WindowWidth;
            List<Column> columns = new List<Column>();
            for (int i = 0; i < width; i++) columns.Add(new Column { Height = height });
            while (true)
            {
                for (int i = 0; i < height; i++)
                {
                    StringBuilder line = new StringBuilder();
                    columns.ForEach(c => line.Append(c.get(i)));
                    Console.WriteLine(line);
                }
                columns.ForEach(c => c.fade());
                System.Threading.Thread.Sleep(150);
                Console.Clear();
            }
        }
    }
}
