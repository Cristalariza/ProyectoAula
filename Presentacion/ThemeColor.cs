using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Presentacion
{
    public static class ThemeColor
    {
        public static List<string> ColorList = new List<string>() {"#A9A9A9",
                                                                "#b0c4de",
                                                                "#808080",
                                                                "#87cefa",
                                                                "#778899",
                                                                "#b0e0e6",
                                                                "#B0C4DE",
                                                                "#ADD8E6",
                                                                "#C0C0C0",
                                                                "#87CEEB",
                                                                "#708090",
                                                                "#4682B4",
                                                                "#d3d3d3",
                                                                "#696969"};
        
        public static Color ChangeColorBrightness(Color color, double correctionFactor)
        {
            double red = color.R;
            double green = color.G;
            double blue = color.B;

            //Si el factor de corrección es menor a 0, el color se oscurece
            if (correctionFactor < 0)
            {
                correctionFactor = 1 + correctionFactor;
                red *= correctionFactor;
                green *= correctionFactor;
                blue *= correctionFactor;
            }
            //Si el factor de corrección es mayor a 0, el color se aclara
            else
            {
                red = (255 - red) * correctionFactor + red;
                green = (255 - green) * correctionFactor + green;
                blue = (255 - blue) * correctionFactor + blue;
            }

            return Color.FromArgb(color.A, (byte)red, (byte)green, (byte)blue);
        }
    }
}
