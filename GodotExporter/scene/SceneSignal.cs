namespace SonicRetro.SonLVL.GodotExporter
{
    public class SceneSignal
    {
        public string Signal;
        public string NodePathFrom;
        public string NodePathTo;
        public string Method;

        public override string ToString()
        {
            return "[connection signal=\"" + Signal + "\" from=\"" + NodePathFrom + "\" to=\"" + NodePathTo + "\" method=\"" + Method + "\"]";
        }
    }
}