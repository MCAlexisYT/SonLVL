using System.Collections.Generic;

namespace SonicRetro.SonLVL.GodotExporter
{
    public class SceneNode
    {
        public SceneExternalDependency Instance;
        public string Parent;
        public string Type = "Node";
		public string Name;
        public Dictionary<string, Variant> KVs;

		public override string ToString()
		{
			string str = "[node name=\"" + Name + "\" type=\"" + Type + "\" parent=\"" + Parent + "]";
			if (Instance != null)
			{
				str = "[node name=\"" + Name + "\" type=\"" + Type + "\" parent=\"" + Parent + " instance=" + Instance.GetReference() + "]";
			}

			foreach (var kv in KVs)
			{
				str += "\n" + kv.Key + " = " + kv.Value.ToString();
			}

			return str;
		}
    }
}