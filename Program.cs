using System.Drawing;

namespace FindIdenticalPenmen
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a Bitmap object from an image file.
            var penmenBitmap = new Bitmap("test.bmp");

            var penmenProc = new PenmenProcessor(penmenBitmap);

            penmenProc.FindIdenticalPenmen();
        }
    }
}
