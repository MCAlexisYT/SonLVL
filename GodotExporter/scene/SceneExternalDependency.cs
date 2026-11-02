using System;
using System.Text.RegularExpressions;

namespace SonicRetro.SonLVL.GodotExporter
{

	public class SceneExternalDependency
	{
		public string ID;
		public string Type;
		public string Path;
		public string UID;

		public override string ToString()
		{
			return "[ext_resource type=\"" + Type + "\" uid=\"" + UID + "\" path=\"" + Path + "\" id=\"" + ID + "\"]";
		}

		public string GetReference()
		{
			return "ExtResource(\"" + ID + "\")";
		}

		public static SceneExternalDependency FromString(string data)
		{
			Regex regex_root = new Regex("^\[ext_resource (.*)\]$");
			Regex regex_type = new Regex("type=\"(.*)\"");
			Regex regex_uid = new Regex("uid=\"(.*)\"");
			Regex regex_path = new Regex("path=\"(.*)\"");
			Regex regex_id = new Regex("id=\"(.*)\"");

			

			return new SceneExternalDependency
			{
				
			};
		}
	}
}