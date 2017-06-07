using UnityEngine;

namespace ChromaSDK.ChromaPackage.Model
{
    public static class ChromaUtils
    {
        /// <summary>
        /// Convert Unity Color to BGR int
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static int ToBGR(Color color)
        {
            int red = (int)(Mathf.Clamp01(color.r)) * 255;
            int green = (int)(Mathf.Clamp01(color.g) * 255) << 8;
            int blue = (int)(Mathf.Clamp01(color.b) * 255) << 16;
            return blue | green | red;
        }

        /// <summary>
        /// Convert BGR int to Unity Color
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static Color ToRGB(int color)
        {
            int red = color & 0xFF;
            int green = (color & 0xFF00) >> 8;
            int blue = (color & 0xFF000) >> 16;
            return new Color(red * 255f, green * 255f, blue * 255f);
        }
    }
}
