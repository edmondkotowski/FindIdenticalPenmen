using System;
using System.Collections.Generic;
using System.Drawing;

namespace FindIdenticalPenmen
{
    public class PenmenMatch
    {
        Point Penmen1 { get; set; }

        Point Penmen2 { get; set; }

        double Percentage { get; set; }
    }

    public class PenmenProcessor
    {
        private readonly Bitmap _penmenBitmap;

        public PenmenProcessor(Bitmap penmenBitmap)
        {
            if (penmenBitmap == null) throw new ArgumentNullException("penmenBitmap");

            _penmenBitmap = penmenBitmap;
        }

        // Should eventually output Identical 
        public IEnumerable<PenmenMatch> FindIdenticalPenmen()
        {
            var map = ParsePenmen();
            PrintPenmen(map);

            return null;
        }

        public IEnumerable<IEnumerable<int>> ParsePenmen()
        {
            var map = new List<List<int>>();

            for (var y = 0; y < _penmenBitmap.Height; y++)
            {
                var list = new List<int>();
                for (var x = 0; x < _penmenBitmap.Width; x++)
                {
                    var pixel = _penmenBitmap.GetPixel(x, y);

                    // find penmen pixel
                    if (pixel.R < 100 && pixel.G < 100 && pixel.B < 100)
                    {
                        list.Add(1);
                        continue;
                    }

                    list.Add(0);
                }

                map.Add(list);
            }

            return map;
        }

        private void PrintPenmen(IEnumerable<IEnumerable<int>> map)
        {
            var outputFile = new System.IO.StreamWriter("output.txt");

            foreach (var list in map)
            {
                foreach (var value in list)
                {
                    if (value == 0)
                    {
                        outputFile.Write(" ");
                        continue;
                    }

                    outputFile.Write("*");
                }
                outputFile.WriteLine();
            }

            outputFile.Close();
        }

        private void SplitPenmen()
        {
            
        }
    }
}