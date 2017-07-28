using ChromaSDK;
using ChromaSDK.ChromaPackage.Model;
using Eric5h5;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Type = System.Type;

class ChromaParticleWindow : EditorWindow
{
    private const string KEY_ANIMATION = "ChromaSDKAnimationPath";
    private const string KEY_CAMERA = "ChromaSDKCameraPath";

    private const int RENDER_TEXTURE_SIZE = 256;

    private ChromaSDKBaseAnimation _mAnimation = null;
    private Camera _mRenderCamera = null;
    private RenderTexture _mRenderTexture = null;
    private Texture2D _mTempTexture = null;

    [MenuItem("Window/ChromaSDK/Open Chroma Particle Window")]
    private static void OpenPanel()
    {
        ChromaParticleWindow window = GetWindow<ChromaParticleWindow>();
        if (null == window)
        {
            window.name = "Chroma Particle Window";
        }
    }

    Object LoadPath(string key, Type type)
    {
        if (EditorPrefs.HasKey(key))
        {
            string path = EditorPrefs.GetString(key);
            if (!string.IsNullOrEmpty(path))
            {
                Object obj = AssetDatabase.LoadAssetAtPath(path, type);
                if (null != obj)
                {
                    return obj;
                }
                else
                {
                    int id;
                    if (int.TryParse(path, out id))
                    {
                        return EditorUtility.InstanceIDToObject(id);
                    }
                }
            }
        }
        return null;
    }

    private void OnEnable()
    {
        _mAnimation = (ChromaSDKBaseAnimation)LoadPath(KEY_ANIMATION, typeof(ChromaSDKBaseAnimation));
        Object obj = LoadPath(KEY_CAMERA, typeof(Camera));
        if (obj &&
            obj is Camera)
        {
            _mRenderCamera = (Camera)obj; 
        }
    }

    void SavePath(Object obj, string key)
    {
        if (obj)
        {
            string path = AssetDatabase.GetAssetPath(obj);
            if (!string.IsNullOrEmpty(path))
            {
                EditorPrefs.SetString(key, path);
            }
            else
            {
                EditorPrefs.SetString(key, obj.GetInstanceID().ToString());
            }
        }
    }

    private void OnDisable()
    {
        SavePath(_mAnimation, KEY_ANIMATION);
        SavePath(_mRenderCamera, KEY_CAMERA);
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
        GUI.DrawTexture(rect, _mRenderTexture);
    }

    private void CaptureFrame()
    {
        if (_mAnimation)
        {
            if (_mAnimation is ChromaSDKAnimation2D)
            {
                ChromaSDKAnimation2D animation = (ChromaSDKAnimation2D)_mAnimation;
                animation.Unload();
                int maxRow = ChromaUtils.GetMaxRow(animation.Device);
                int maxColumn = ChromaUtils.GetMaxColumn(animation.Device);

                _mTempTexture = new Texture2D(RENDER_TEXTURE_SIZE, RENDER_TEXTURE_SIZE, TextureFormat.RGB24, false);
                RenderTexture.active = _mRenderTexture;
                _mRenderCamera.Render();
                DisplayRenderTexture(0, maxColumn, maxRow);
                _mTempTexture.ReadPixels(new Rect(0, 0, _mTempTexture.width, _mTempTexture.height), 0, 0, false);
                _mTempTexture.Apply();
                TextureScale.Bilinear(_mTempTexture, maxColumn, maxRow);
                _mTempTexture.Apply();
                RenderTexture.active = null;
                Color[] pixels = _mTempTexture.GetPixels();
                List<EffectArray2dInput> frames = animation.Frames;
                EffectArray2dInput frame = ChromaUtils.CreateColors2D(animation.Device);
                int index = 0;
                for (int i = maxRow-1; i >= 0; --i)
                {
                    List<int> row = frame[i];
                    for (int j = 0; j < maxColumn; ++j)
                    {
                        Color color = pixels[index];
                        row[j] = ChromaUtils.ToBGR(color);
                        ++index;
                    }
                }
                DestroyImmediate(_mTempTexture);
                //frames[0] = frame;
                frames.Add(frame);
                animation.Frames = frames;
                ChromaSDKAnimationBaseEditor.GoToLastFrame();
            }
        }
    }

    private void OnGUI()
    {
        //_mTempTexture = (Texture2D)EditorGUILayout.ObjectField("TempTexture", _mTempTexture, typeof(Texture2D), true);

        _mAnimation = (ChromaSDKBaseAnimation)EditorGUILayout.ObjectField("Animation", _mAnimation, typeof(ChromaSDKBaseAnimation), true);

        _mRenderCamera = (Camera)EditorGUILayout.ObjectField("RenderCamera", _mRenderCamera, typeof(Camera), true);

        if (_mRenderCamera &&
            _mAnimation)
        {
            GUI.enabled = !_mAnimation.IsPlaying();
            if (GUILayout.Button("Capture Frame"))
            {
                CaptureFrame();
            }
            GUI.enabled = true;
        }

        if (_mAnimation)
        {
            GUI.enabled = ChromaConnectionManager.Instance.Connected;
            if (GUILayout.Button("Play"))
            {
                _mAnimation.Play();
            }
            GUI.enabled = true;
        }

        Rect rect = GUILayoutUtility.GetLastRect();
        if (_mRenderCamera)
        {
            if (null == _mRenderTexture)
            {
                _mRenderTexture = new RenderTexture(RENDER_TEXTURE_SIZE, RENDER_TEXTURE_SIZE, 24, RenderTextureFormat.RGB565);
                _mRenderCamera.targetTexture = _mRenderTexture;
            }
            _mRenderCamera.Render();
            rect.y += 30;
            DisplayRenderTexture((int)rect.y, RENDER_TEXTURE_SIZE, RENDER_TEXTURE_SIZE);
            if (_mAnimation)
            {
                rect.y += 300;
                const int padding = 8;
                if (_mAnimation is ChromaSDKAnimation1D)
                {
                    int maxLeds = ChromaUtils.GetMaxLeds((_mAnimation as ChromaSDKAnimation1D).Device);
                    for (int k = 1; (k * maxLeds) < position.width && (rect.y + rect.height) <= position.height; k *= 2)
                    {
                        DisplayRenderTexture((int)rect.y, maxLeds * k, k);
                        rect.y += k + padding;
                    }
                }
                else if (_mAnimation is ChromaSDKAnimation2D)
                {
                    int maxRow = ChromaUtils.GetMaxRow((_mAnimation as ChromaSDKAnimation2D).Device);
                    int maxColumn = ChromaUtils.GetMaxColumn((_mAnimation as ChromaSDKAnimation2D).Device);
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
