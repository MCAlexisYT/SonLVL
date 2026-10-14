namespace SonicRetro.SonLVL.GodotExporter
{
    public class Variant
    {
        internal static class Vector2
        {
            public float X;
            public float Y;
        }
        internal static class Vector2i
        {
            public int X;
            public int Y;
        }
        internal static class Vector3
        {
            public float X;
            public float Y;
            public float Z;
        }
        internal static class Vector3i
        {
            public int X;
            public int Y;
            public int Z;
        }
        internal static class Vector4
        {
            public float X;
            public float Y;
            public float Z;
            public float W;
        }
        internal static class Vector4i
        {
            public int X;
            public int Y;
            public int Z;
            public int W;
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
        internal static class AABB
        {
            public Vector3 Position;
            public Vector3 Size;
        }
        internal static class Basis
        {
            public Vector3 X;
            public Vector3 Y;
            public Vector3 z;
        }
        internal static class Transform2D
        {
            public Vector2 Origin;
            public Vector2 X;
            public Vector2 Y;
        }
        internal static class Transform3D
        {
            public Basis Basis;
            public Vector3 Origin;
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
            PACKEDFLOAT32ARRAY,
            PACKEDFLOAT64ARRAY,
            PACKEDINT32ARRAY,
            PACKEDINT64ARRAY,
            PACKEDVECTOR2ARRAY,
            PACKEDVECTOR3ARRAY,
            PACKEDVECTOR4ARRAY,
            PACKEDSTRINGARRAY
        }
        internal 
        internal byte[] PackedByteArrayValue;
        internal float[] PackedFloatArrayValue;
        internal int[] PackedIntArrayValue;
        internal string[] PackedStringArrayValue;
        internal Vector2[] PackedVector2ArrayValue;
        internal Vector3[] PackedVector3ArrayValue;
        internal Vector4[] PackedVector4ArrayValue;

    }
}