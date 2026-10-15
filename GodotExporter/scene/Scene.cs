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
    }
}
