using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Hunter;

namespace Hunter
{
    public class ColorGradientHelper
    {
        public static Color CalcualteColor(Color[] colors, float precent)
        {
            if (precent >= 1.0f)
            {
                return colors[colors.Length - 1];
            }

            float offset = 1.0f / (colors.Length - 1);

            int index = (int)(precent / offset);

            if (index >= (colors.Length - 1))
            {
                return colors[colors.Length - 1];
            }

            float startValue = offset * index;

            float adjustPrecent = (precent - startValue) / offset;

            Color c0 = colors[index];
            Color c1 = colors[index + 1];

            float inverPrecent = 1.0f - adjustPrecent;

            float r = c0.r * inverPrecent + c1.r * adjustPrecent;
            float g = c0.g * inverPrecent + c1.g * adjustPrecent;
            float b = c0.b * inverPrecent + c1.b * adjustPrecent;
            float a = c0.a * inverPrecent + c1.a * adjustPrecent;

            return new Color(r, g, b, a);
        }


        public static Color CalcualteColor(string[] colors, float precent)
        {
            if (precent >= 1.0f)
            {
                return CommonPalette.StringToColor(colors[colors.Length - 1]);;
            }

            
            float offset = 1.0f / (colors.Length - 1);

            int index = (int)(precent / offset);

            if (index >= (colors.Length - 1))
            {
                return CommonPalette.StringToColor(colors[colors.Length - 1]);
            }

            return CommonPalette.StringToColor(colors[index]);
        }
    }

public class CommonPalette
{
    public static Color StringToColor(string colorStr)
    {
        if (string.IsNullOrEmpty(colorStr))
        {
            return new Color();
        }
        int colorInt = int.Parse(colorStr, System.Globalization.NumberStyles.AllowHexSpecifier);
        return IntToColor(colorInt);
    }
    
    public static Color IntToColor(int colorInt)
    {
        float basenum = 255;

        int b = 0xFF & colorInt;
        int g = 0xFF00 & colorInt;
        g >>= 8;
        int r = 0xFF0000 & colorInt;
        r >>= 16;
        return new Color((float)r / basenum, (float)g / basenum, (float)b / basenum, 1);

    }
}
}
