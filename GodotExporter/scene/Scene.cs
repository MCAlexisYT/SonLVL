using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SonicRetro.SonLVL.GodotExporter.scene
{
	public class Scene
	{
		public List<SceneNode> nodes;
		public List<SceneInternalResource> resources;
		public List<SceneExternalDependency> externalDependencies;
		public List<SceneSignal> signals;
		public string ToString()
		{
			string str = "[gd_scene format=3]\n";

			foreach (var item in externalDependencies)
			{
				str += "\n" + item.ToString();
			}
			foreach (var item in resources)
			{
				str += "\n\n" + item.ToString();
			}
			foreach (var item in nodes)
			{
				str += "\n\n" + item.ToString();
			}
			str += "\n";
			foreach (var item in signals)
			{
				str += "\n" + item.ToString();
			}
			return str;
		}
	}
}
