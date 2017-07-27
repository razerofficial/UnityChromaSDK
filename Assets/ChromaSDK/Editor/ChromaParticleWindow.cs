using ChromaSDK;
using UnityEditor;
using UnityEngine;

class ChromaParticleWindow : EditorWindow
{
    private static ChromaSDKBaseAnimation _sAnimation = null;
    private static Camera _RenderCamera = null;
    private static RenderTexture _sRenderTexture = null;

    [MenuItem("Window/ChromaSDK/Open Chroma Particle Window")]
    private static void OpenPanel()
    {
        ChromaParticleWindow window = GetWindow<ChromaParticleWindow>();
        if (null == window)
        {
            window.name = "Chroma Particle Window";
        }
    }

    private void DisplayRenderTexture(int y, int width, int height)
    {
        Rect rect = new Rect(0, y, width, height);
        Color oldColor = GUI.backgroundColor;
        Texture2D oldTexture = GUI.skin.box.normal.background;
        GUI.skin.box.normal.background = ChromaSDKAnimationBaseEditor.GetBlankTexture();
        const int border = 2;
        rect.width = width + 2 * border;
        rect.height = height + 2 * border;
        GUI.backgroundColor = Color.red;
        GUI.Box(rect, "");
        rect.width = width;
        rect.height = height;
        rect.x += border;
        rect.y += border;
        GUI.backgroundColor = Color.black;
        GUI.Box(rect, "");
        GUI.backgroundColor = oldColor;
        GUI.skin.box.normal.background = oldTexture;
        GUI.DrawTexture(rect, _sRenderTexture);
    }

    private void OnGUI()
    {
        _sAnimation = (ChromaSDKBaseAnimation)EditorGUILayout.ObjectField("Animation", _sAnimation, typeof(ChromaSDKBaseAnimation), true);

        _RenderCamera = (Camera)EditorGUILayout.ObjectField("RenderCamera", _RenderCamera, typeof(Camera), true);
        Rect rect = GUILayoutUtility.GetLastRect();
        if (_RenderCamera)
        {
            const int size = 256;
            if (null == _sRenderTexture)
            {
                _sRenderTexture = new RenderTexture(size, size, 24, RenderTextureFormat.RGB565);
                _RenderCamera.targetTexture = _sRenderTexture;
            }
            _RenderCamera.Render();
            rect.y += 30;
            DisplayRenderTexture((int)rect.y, 256, 256);
            if (_sAnimation)
            {
                rect.y += 300;
                const int padding = 8;
                if (_sAnimation is ChromaSDKAnimation1D)
                {
                    int maxLeds = ChromaUtils.GetMaxLeds((_sAnimation as ChromaSDKAnimation1D).Device);
                    for (int k = 1; (k * maxLeds) < position.width && (rect.y + rect.height) <= position.height; k *= 2)
                    {
                        DisplayRenderTexture((int)rect.y, maxLeds * k, k);
                        rect.y += k + padding;
                    }
                }
                else if (_sAnimation is ChromaSDKAnimation2D)
                {
                    DisplayRenderTexture((int)rect.y, 22, 6);
                    int maxRow = ChromaUtils.GetMaxRow((_sAnimation as ChromaSDKAnimation2D).Device);
                    int maxColumn = ChromaUtils.GetMaxColumn((_sAnimation as ChromaSDKAnimation2D).Device);
                    DisplayRenderTexture((int)rect.y, maxColumn, maxRow);
                    for (int k = 1; (k * maxColumn) < position.width && (rect.y + rect.height) <= position.height; k *= 2)
                    {
                        DisplayRenderTexture((int)rect.y, maxColumn * k, maxRow * k);
                        rect.y += maxRow * k + padding;
                    }
                }
            }
        }

        Repaint();
    }
}
