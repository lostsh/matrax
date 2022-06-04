using System;

namespace Matrax
{
    /// <summary>
    /// Class <c>Char</c> represent a valid character
    /// </summary>
    class Char
    {
        public char Character { get; set; }

        /// western latin letters and number and katakana
        //private static readonly (int, int)[] Ranges = new (int, int)[] {(48, 57), (65, 90), (97, 122), (12449, 12542) };
        // western latin letters and numbers and printable unicode chars
        private static readonly (int, int)[] Ranges = new (int, int)[] {(48, 57), (65, 90), (97, 122), (1300, 1350), (1377, 1400), (7450, 7467), (7531, 7578), (8352, 8383), (8352, 8383) };
        /// western latin letters and number and half-width katakana
        //private static readonly (int, int)[] Ranges = new (int, int)[] {(48, 57), (65, 90), (97, 122), (65376, 65504)};

        public Char()
        {
            //Random rand = new Random((int)DateTime.Now.Ticks);
            Random rand = new Random();

            // choose a char interval
            int charRange = rand.Next(0, Ranges.Length);
            // choose a char in the choosen interval
            int charDecimalCode = rand.Next(Ranges[charRange].Item1, Ranges[charRange].Item2);

            Character = Convert.ToChar(charDecimalCode);
        }

        public override string ToString()
        {
            return Character+"";
        }
    }
}
