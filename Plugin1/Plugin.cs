using System.ComponentModel.Composition;
using System.Drawing;
using Test.PluginFramework;
using Test.PluginFramework.Core;

namespace Plugin1
{
    [Export(typeof(IFilter))]
    public class Plugin : IFilter
    {
        public string Name => "Flip Image";

        public Image RunPlugin(Image src)
        {
            Bitmap bitmap = new Bitmap(src);
            Bitmap newBitmap = new Bitmap(src);

            for (int row = 0; row < bitmap.Height; ++row)
            {
                for (int col = 0; col < bitmap.Width; ++col)
                {
                    newBitmap.SetPixel(bitmap.Width - col - 1, bitmap.Height - row - 1,
                        bitmap.GetPixel(col, row));
                }
            }

            bitmap.Dispose();
            return newBitmap;
        }

    }
}
