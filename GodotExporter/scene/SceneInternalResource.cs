using System.Collections.Generic;
using System.Text.RegularExpressions;

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
	/*
	public class SceneResourceFile
	{
		public SceneInternalResource Main;
		public SceneInternalResource[] SubResources;
		public SceneExternalDependency[] ExternalDependencies;

		public static SceneResourceFile FromString(string data)
		{
			return new SceneResourceFile(data);
		}

		public SceneResourceFile(string data)
		{
			Regex regex_start_of_file = new Regex(@"\[gd_resource type="".*"".*\](?:.|\n)*\n\n\[resource\](?:\n.*=.*)*$", RegexOptions.CultureInvariant); // Yes, I know this breaks with things like multiline strings. But it *should* work for TileSet resources.
			string str_keyvalues = regex_start_of_file.Replace(data, "");

			Dictionary<string, string> temp_root = new Dictionary<string, string>();
			foreach (string line in str_keyvalues.Split('\n'))
			{
				string[] e = line.Split('=', 2);
				temp_root.Add(e[0], e[1]);
			}
		}
	}
	*/
}