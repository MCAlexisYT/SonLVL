using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SonicRetro.SonLVL.GodotExporter.scene
{
	public class Scene
	{
		public List<SceneNode> Nodes;
		public List<SceneInternalResource> Resources;
		public List<SceneExternalDependency> ExternalDependencies;
		public List<SceneSignal> Signals;
		public override string ToString()
		{
			string str = "[gd_scene format=3]\n";

			foreach (var item in ExternalDependencies)
			{
				str += "\n" + item.ToString();
			}
			foreach (var item in Resources)
			{
				str += "\n\n" + item.ToString();
			}
			foreach (var item in Nodes)
			{
				str += "\n\n" + item.ToString();
			}
			str += "\n";
			foreach (var item in Signals)
			{
				str += "\n" + item.ToString();
			}
			return str;
		}


	}
}
