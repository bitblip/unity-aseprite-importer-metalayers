using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

namespace Aseprite
{
    public enum MetaDataType { UNKNOWN, TRANSFORM, NORMAL_MAP, MASK };

    public class MetaData
    {
        static public string MetaDataChar = "@";

        public MetaDataType Type { get; private set; }
        //Average position per frames
        public Dictionary<int, Vector2> Transforms { get; private set; }
        public List<string> Args { get; private set; }

        public MetaData(string layerName)
        {
            var transformRegex = new Regex("@transform\\(\"(.*)\"\\)");
            var transformMatch = transformRegex.Match(layerName);
            if (transformMatch.Success)
            {
                Type = MetaDataType.TRANSFORM;
                Args = new List<string>();
                Args.Add(transformMatch.Groups[1].Value);
                Transforms = new Dictionary<int, Vector2>();

                return;
            }

            var normalRegex = new Regex("@normalmap", RegexOptions.IgnoreCase);
            var normalMapMatch = normalRegex.IsMatch(layerName);
            if(normalMapMatch)
            {
                Type = MetaDataType.NORMAL_MAP;
                Args = new List<string>();

                return;
            }

            Debug.LogWarning($"Unsupported aseprite metadata {layerName}");
        }
    }
}
