using System.Collections.Generic;

namespace SonicRetro.SonLVL.GodotExporter
{

	public class SceneInternalResource
	{
		public string Type;
		public string ID;
		public Dictionary<string, Variant> KVs;

		public override string ToString()
		{
			string str = "[sub_resource type=\"" + Type + "\" id=\"" + ID + "\"]";

			foreach (var kv in KVs)
			{
				str += "\n" + kv.Key + " = " + kv.Value.ToString();
			}

			return str;
		}

		public string GetReference()
		{
			return "SubResource(\"" + ID + "\")";
		}
	}
}