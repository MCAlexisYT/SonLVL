using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using SonicRetro.SonLVL.API;

namespace SonicRetro.SonLVL.GodotExporter
{
	public class Scene
	{
		public SceneNode RootNode;
		public List<SceneNode> Nodes;
		public List<SceneInternalResource> Resources;
		public List<SceneExternalDependency> ExternalDependencies;
		public List<SceneSignal> Signals;
		public override string ToString()
		{
			string str = "[gd_scene format=3]\n";

			foreach (SceneExternalDependency item in ExternalDependencies)
			{
				str += "\n" + item.ToString();
			}
			foreach (SceneInternalResource item in Resources)
			{
				str += "\n\n" + item.ToString();
			}
			str += "\n\n" + RootNode.RootToString();
			foreach (SceneNode item in Nodes)
			{
				str += "\n\n" + item.ToString();
			}
			str += "\n";
			foreach (SceneSignal item in Signals)
			{
				str += "\n" + item.ToString();
			}
			return str;
		}
	}
}
