using System.ComponentModel.Composition;
using System.Drawing;
using Test.PluginFramework.Core;

namespace Plugin2
{
    [Export(typeof(IFilter))]
    public class Plugin : IFilter
    {
        public string Name => "Make GrayScale";

        public Image RunPlugin(Image src)
        {
            var bitmap = new Bitmap(src);

            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    Color c = bitmap.GetPixel(i, j);

                    byte gray = (byte)(.21 * c.R + .71 * c.G + .071 * c.B);

                    bitmap.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
                }
            }
            return bitmap;
        }
    }
}
