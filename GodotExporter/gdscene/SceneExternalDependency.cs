namespace SonicRetro.SonLVL.GodotExporter
{
    public class SceneExternalDependency
    {
        public string ID;
        public string Type;
        public string Path;
        public string UID;

        public string ToString()
        {
            return "[ext_resource type=\"" + Type + "\" uid=\"" + UID + "\" path=\"" + Path + "\" id=\"" + ID + "\"]";
        }

        public string getReference()
        {
            return "ExtResource(\"" + ID + "\")";
        }
    }
}