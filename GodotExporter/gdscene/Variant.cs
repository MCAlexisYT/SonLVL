namespace SonicRetro.SonLVL.GodotExporter
{
    public class Variant
    {
        internal static class Vector2
        {
            public float x;
            public float y;
        }
        internal static class Vector2i
        {
            public int x;
            public int y;
        }
        internal static class Vector3
        {
            public float x;
            public float y;
            public float z;
        }
        internal static class Vector3i
        {
            public int x;
            public int y;
            public int z;
        }
        internal static class Vector4
        {
            public float x;
            public float y;
            public float z;
            public float w;
        }
        internal static class Vector4i
        {
            public int x;
            public int y;
            public int z;
            public int w;
        }
        internal static class Rect2
        {
            public Vector2 Position;
            public Vector2 Size;
        }
        internal static class Rect2i
        {
            public Vector2i Position;
            public Vector2i Size;
        }
        internal static enum VariantType
        {
            FLOAT,
            INT,
            VECTOR2,
            VECTOR2I,
            VECTOR3,
            VECTOR3I,
            VECTOR4,
            VECTOR4I,
            STRING,
            RECT2,
            RECT2I,
            AABB,
            PACKEDBYTEARRAY,
            PACKEDFLOATARRAY,
            PACKEDINTARRAY,
            PACKEDVECTOR2ARRAY,
            PACKEDVECTOR3ARRAY,
            PACKEDVECTOR4ARRAY,
            PACKEDSTRINGARRAY
        }
        internal byte[] PackedByteArrayValue;
        internal float[] PackedFloatArrayValue;
        internal int[] PackedIntArrayValue;
        internal string[] PackedStringArrayValue;
        internal Vector2[] PackedVector2ArrayValue;
        internal Vector3[] PackedVector3ArrayValue;
        internal Vector4[] PackedVector4ArrayValue;

    }
}