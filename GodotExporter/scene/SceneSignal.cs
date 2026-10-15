namespace SonicRetro.SonLVL.GodotExporter
{
    public class SceneSignal
    {
        public string Signal;
        public SceneNode From;
        public SceneNode To;
        public string Method;

        public override string ToString()
        {
            return "[connection signal=\"" + Signal + "\" from=\"" + From.Name + "\" to=\"" + To.Name = "\" method=\"" + Method + "\"]";
        }
    }
}