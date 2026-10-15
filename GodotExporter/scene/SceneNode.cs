using System.Collections.Generic;

namespace SonicRetro.SonLVL.GodotExporter
{
    public class SceneNode
    {
        public SceneExternalDependency Instance;
        public string Parent;
        public string Type = "Node";
        public Dictionary<string, Variant> KVs;
    }
}