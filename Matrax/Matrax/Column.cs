using System;
using System.Collections.Generic;

namespace Matrax
{
    class Column
    {
        public static bool BLOCK = true;

        /// max height of a column
        public int Height { get; set; } = 24;

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

        private void initVars()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);

            length = rand.Next(0, Height);
            yStart = rand.Next(0, Height - length);
            chars.Clear();
            if(BLOCK) chars.Add(new Char{ Character = '█' });
        }

        /// fade column down
        public void fade() {

            // // if the char len < length
            // add a bottom char
            if (yStart + chars.Count < Height && chars.Count < length)
            {
                chars.Add(new Char());
                if (BLOCK) invertBottomChars();
            }

            // // if the chars len == length
            // remove the top char
            // add a new bottom char
            // update yStart to +1
            if(chars.Count == length && yStart + chars.Count < Height)
            {
                chars.RemoveAt(0);
                chars.Add(new Char());
                yStart++;
                if (BLOCK) invertBottomChars();
            }

            // if u toutch the bottom of the screen
            //  fade until the end of the column
            //  choose a new random size and yStart to restart
            if(yStart + chars.Count >= Height)
            {
                System.Diagnostics.Debug.WriteLine("Now fade off");
                if (chars.Count > 0)
                {
                    // fade until the end
                    chars.RemoveAt(0);
                    yStart++;
                }
                else
                {
                    initVars();
                }
            }
        }

        /// <summary>
        /// Invert the two last elements of chars
        /// Used to be sure that the block still on the bottom
        /// </summary>
        private void invertBottomChars()
        {
            if(chars.Count > 1)
            {
                Char tmp = chars[chars.Count - 1];
                chars[chars.Count - 1] = chars[chars.Count - 2];
                chars[chars.Count - 2] = tmp;
            }
        }

        public Char get(int y)
        {
            Char c = new Char { Character = ' ' };
            int index = y - yStart;
            if (index > 0 && index < chars.Count) c = chars[index];
            return c;
        }

    }
}
