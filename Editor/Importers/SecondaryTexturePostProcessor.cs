using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace AsepriteImporter
{
    public class SecondaryTexturePostProcessor : AssetPostprocessor
    {
        void OnPreprocessAsset()
        {
            // Did we just import an aseprite file?
            if(assetPath.Contains("aseprite"))
            {
                Debug.Log("Detected aseprite file?");
            }
        }
    }
}
