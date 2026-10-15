using System.Collections.Generic;
using SonicRetro.SonLVL.API;
using System;
using SonicRetro.SonLVL.GodotExporter.scene;

namespace SonicRetro.SonLVL.GodotExporter
{
    public static class Exporter
    {
        public static string GodotProjectRoot;

        // format: key: object definition, value: scene path (relative to GodotProjectRoot)
        public static Dictionary<ObjectDefinition, string> ObjPaths;

        // format: key: level name, value: level path (relative to GodotProjectRoot)
        public static Dictionary<string, string> LevelPaths;

        public static void Export()
        {
            Scene scene = new Scene();

            Chunk[] chunks = LevelData.Chunks.ToArray();
        }
    }
}