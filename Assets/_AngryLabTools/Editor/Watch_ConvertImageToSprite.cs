
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Linq;

/// <summary>
/// This script watches for a folder called Sprite(s) and converts any image imported into the project to a Sprite automatically
/// </summary>
public class Watch_ConvertImageToSprite : AssetPostprocessor
{
    void OnPreprocessTexture()
    {
        AssetDatabase.Refresh();
        Debug.Log("Running");
        // Automatically convert any texture file with "GUIImages" in its file name into a compressed GUI Image.
        if (assetPath.ToLower().StartsWith("image/sprite/") || assetPath.ToLower().Contains("images/sprites/") && assetPath.EndsWith(".png"))
        {
            Debug.Log("Converting to Sprite!");
            var path = Path.GetDirectoryName(assetPath);
            GetListOfPngImages(path);
        }

    }

    void GetListOfPngImages(string folder)
    {
        var parentFolder = Path.GetDirectoryName(folder);
        if (string.IsNullOrEmpty(parentFolder)) return;

        IOrderedEnumerable<string> listOfPng = Directory.EnumerateFiles(folder, "*.png", SearchOption.TopDirectoryOnly).OrderBy(a => a);
        ConvertPngImage(listOfPng);
    }

    void ConvertPngImage(IOrderedEnumerable<string> list)
    {
        foreach (var item in list)
        {
            AssetImporter asset = AssetImporter.GetAtPath(item);
            TextureImporter _textureImp = (TextureImporter)asset;
            _textureImp.textureType = TextureImporterType.Sprite;
            _textureImp.textureShape = TextureImporterShape.Texture2D;
            _textureImp.spriteImportMode = SpriteImportMode.Single;
            _textureImp.spritePixelsPerUnit = 100;
            _textureImp.wrapMode = TextureWrapMode.Clamp;
            _textureImp.filterMode = FilterMode.Bilinear;

            _textureImp.SetPlatformTextureSettings(new TextureImporterPlatformSettings()
            {
                maxTextureSize = 1024,
                resizeAlgorithm = TextureResizeAlgorithm.Mitchell,
                format = TextureImporterFormat.Automatic,
                compressionQuality = (int)TextureCompressionQuality.Best
            });

            // Clearing all platform Settings
            _textureImp.ClearPlatformTextureSettings("Web");
            _textureImp.ClearPlatformTextureSettings("Standalone");
            _textureImp.ClearPlatformTextureSettings("iPhone");

        }
    }

}
