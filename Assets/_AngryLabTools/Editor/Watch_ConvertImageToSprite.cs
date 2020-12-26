
using UnityEngine;
using UnityEditor;

/// <summary>
/// This script watches for a folder called Sprite(s) and converts any image imported into the project to a Sprite automatically
/// </summary>
public class Watch_ConvertImageToSprite : AssetPostprocessor
{
    void OnPreprocessTexture()
    {
        // Automatically convert any texture file with "GUIImages" in its file name into an uncompressed unchanged GUI Image.
        if (assetPath.Contains("Sprite") || assetPath.Contains("Sprites"))
        {
            Debug.Log("Converting to Sprite!");
            TextureImporter _textureImp = (TextureImporter)assetImporter;
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
                compressionQuality = (int) TextureCompressionQuality.Best
            });

            // Clearing all platform Settings
            _textureImp.ClearPlatformTextureSettings("Web");
            _textureImp.ClearPlatformTextureSettings("Standalone");
            _textureImp.ClearPlatformTextureSettings("iPhone");

        }

    }

}