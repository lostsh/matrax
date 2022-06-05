using System;
using System.Collections.Generic;

namespace Matrax
{
    class Column
    {
        public static bool BLOCK = false;

        /// max height of a column
        public int Height { get; set; } = 24;

        public int X { get; set; }

        /// y position of the begening
        private int yStart = 0;

        /// list of chars in the column
        private List<Char> chars = new List<Char>();

        /// height of the column to be printed
        private int length = 7;

        public Column()
        {
            initVars();
        }

        /// init all variables
        private void initVars()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);

            length = rand.Next(0, Height);
            yStart = rand.Next(0, Height - length);
            chars.Clear();
            if(BLOCK) chars.Add(new Char{ Character = '█' });
        }

        private void removeTopChar(){
            if(chars.Count > 0){
                chars.RemoveAt(0);
                Console.SetCursorPosition(X, yStart);
                Console.Write("\b ");
            }
        }

        private void addBottomChar(){
            Console.SetCursorPosition(X, yStart+chars.Count);
            chars.Add(new Char());
            Console.Write("\b"+chars[chars.Count-1]);
        }

        public void writeFade(){
            if(yStart + chars.Count >= Height)
            {
                if (chars.Count > 0)
                {
                    removeTopChar();
                    yStart++;
                }
                else
                {
                    initVars();
                }
            }
            else
            {
                if(chars.Count == length)
                {
                    removeTopChar();
                    yStart++;
                }
                addBottomChar();
                //if (BLOCK) invertBottomChars();
            }
        }

        /// <summary>
        /// Invert the two last elements of chars
        /// Used to be sure that the block still on the bottom
        /// </summary>
        private void invertBottomChars()
        {
            if (chars.Count > 1)
            {
                Char tmp = chars[chars.Count - 1];
                // put the bloc (n-2) at the bottom
                chars[chars.Count - 1] = chars[chars.Count - 2];
                Console.SetCursorPosition(X, yStart + chars.Count);
                Console.Write("\b" + chars[chars.Count - 1]);
                // replace the (n-2) with the char supposed to be at bottom
                chars[chars.Count - 2] = tmp;
                Console.SetCursorPosition(X, yStart + chars.Count - 1);
                Console.Write("\b" + chars[chars.Count - 2]);
            }
        }

        public Char get(int y)
        {
            Char c = new Char { Character = ' ' };
            int index = y - yStart;
            if (index > 0 && index < chars.Count-1) c = chars[index];
            return c;
        }

    }
}
