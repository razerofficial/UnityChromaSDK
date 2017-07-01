using ChromaSDK.Api;
using ChromaSDK.ChromaPackage.Model;
using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Random = System.Random;

namespace ChromaSDK
{
    public static class ChromaUtils
    {
        /// <summary>
        /// Thread safe random object
        /// </summary>
        private static Random _sRandom = new System.Random(123);

        /// <summary>
        /// Get the max column given the device
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public static int GetMaxColumn(ChromaDevice2DEnum device)
        {
            switch (device)
            {
                case ChromaDevice2DEnum.Keyboard:
                    return Keyboard.MAX_COLUMN;
                case ChromaDevice2DEnum.Keypad:
                    return Keypad.MAX_COLUMN;
                case ChromaDevice2DEnum.Mouse:
                    return Mouse.MAX_COLUMN;
            }
            return 0;
        }

        /// <summary>
        /// Get the max row given the device
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public static int GetMaxRow(ChromaDevice2DEnum device)
        {
            switch (device)
            {
                case ChromaDevice2DEnum.Keyboard:
                    return Keyboard.MAX_ROW;
                case ChromaDevice2DEnum.Keypad:
                    return Keypad.MAX_ROW;
                case ChromaDevice2DEnum.Mouse:
                    return Mouse.MAX_ROW;
            }
            return 0;
        }

        /// <summary>
        /// Get the max leds for the given device
        /// </summary>
        /// <param name="device"></param>
        /// <returns></returns>
        public static int GetMaxLeds(ChromaDevice1DEnum device)
        {
            switch (device)
            {
                case ChromaDevice1DEnum.ChromaLink:
                    return ChromaLink.MAX_LEDS;
                case ChromaDevice1DEnum.Headset:
                    return Headset.MAX_LEDS;
                case ChromaDevice1DEnum.Mousepad:
                    return Mousepad.MAX_LEDS;
            }
            return 0;
        }

        public static int GetLowByte(int mask)
        {
            return (int)(mask & 0xFF);
        }

        public static int GetHighByte(int mask)
        {
            return (int)(((mask & 0xFF00) >> 8) & 0xFF);
        }

        public static EffectArray2dInput CreateColors2D(ChromaDevice2DEnum device)
        {
            int maxRows = GetMaxRow(device);
            int maxColumns = GetMaxColumn(device);
            var rows = new EffectArray2dInput();
            for (int i = 0; i < maxRows; ++i)
            {
                var row = new List<int>();
                for (int j = 0; j < maxColumns; ++j)
                {
                    row.Add(0);
                }
                rows.Add(row);
            }
            return rows;
        }

        public static EffectArray2dInput CreateRandomColors2D(ChromaDevice2DEnum device)
        {
            int maxRows = GetMaxRow(device);
            int maxColumns = GetMaxColumn(device);
            var rows = new EffectArray2dInput();
            for (int i = 0; i < maxRows; ++i)
            {
                var row = new List<int>();
                for (int j = 0; j < maxColumns; ++j)
                {
                    row.Add(_sRandom.Next(16777215));
                }
                rows.Add(row);
            }
            return rows;
        }

        public static EffectResponseId CreateEffectCustom2D(ChromaApi api, ChromaDevice2DEnum device, EffectArray2dInput input)
        {
            if (null == api)
            {
                Debug.LogError("CreateEffectCustom2D: Parameter api is null!");
                return null;
            }
            if (null == input)
            {
                Debug.LogError("CreateEffectCustom2D: Parameter input is null!");
                return null;
            }
            int maxRow = GetMaxRow(device);
            int maxColumn = GetMaxColumn(device);
            if (maxRow != input.Count ||
                (input.Count > 0 &&
                maxColumn != input[0].Count))
            {
                Debug.LogError(string.Format("CreateEffectCustom2D Array size mismatch row: %d==%d column: %d==%d!",
                    maxRow,
                    input.Count,
                    maxColumn,
                    input.Count > 0 ? input[0].Count : 0));
            }

            switch (device)
            {
                case ChromaDevice2DEnum.Keyboard:
                    return api.PostKeyboardCustom(input);
                case ChromaDevice2DEnum.Keypad:
                    return api.PostKeypadCustom(input);
                case ChromaDevice2DEnum.Mouse:
                    return api.PostMouseCustom(input);
            }
            return null;
        }

        public static EffectIdentifierResponse SetEffect(ChromaApi api, string effectId)
        {
            if (null == api)
            {
                Debug.LogError("SetEffect: Parameter api is null!");
                return null;
            }
            if (string.IsNullOrEmpty(effectId))
            {
                Debug.LogError("SetEffect: Parameter effectId cannot be null or empty!");
                return null;
            }

            var input = new EffectIdentifierInput(effectId, null);
            return api.PutEffect(input);
        }

        public static EffectIdentifierResponse RemoveEffect(ChromaApi api, string effectId)
        {
            if (null == api)
            {
                Debug.LogError("RemoveEffect: Parameter api is null!");
                return null;
            }
            if (string.IsNullOrEmpty(effectId))
            {
                Debug.LogError("RemoveEffect: Parameter effectId cannot be null or empty!");
                return null;
            }

            var input = new EffectIdentifierInput(effectId, null);
            return api.RemoveEffect(input);
        }

        /// <summary>
        /// Convert Unity Color to BGR int
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static int ToBGR(Color color)
        {
            int red = (int)(Mathf.Clamp01(color.r) * 255);
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
            const float invert = 1f / 255f;
            int red = color & 0xFF;
            int green = (color & 0xFF00) >> 8;
            int blue = (color & 0xFF0000) >> 16;
            return new Color(red * invert, green * invert, blue * invert);
        }

        /// <summary>
        /// Avoid blocking the Unity main thread, execute the action on a new thread
        /// </summary>
        /// <param name="action"></param>
        public static void RunOnThread(Action action)
        {
            Thread thread = new Thread(new ThreadStart(() => {
                try
                {
                    action.Invoke();
                }
                catch (Exception)
                {
                    Debug.LogError("Failed to invoke action!");
                }
            }));
            thread.Start();
        }
    }
}
