using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using SonicRetro.SonLVL.GodotExporter;
using System;
using System.Runtime.Versioning;

namespace SonicRetro.SonLVL.GodotExporter
{

	public class Variant
	{
		public class Vector2
		{
			public float X;
			public float Y;
			public override string ToString()
			{
				return "Vector2(" + numbers() + ")";
			}
			public string numbers()
			{
				return X.ToString() + ", " + Y.ToString();
			}

			public Vector2(float x, float y)
			{
				X = x;
				Y = y;
			}
			public Vector2(Vector2 value)
			{
				X = value.X;
				Y = value.Y;
			}
			public Vector2(int x, int y)
			{
				X = (float)x;
				Y = (float)y;
			}
		}
		public class Vector2i
		{
			public int X;
			public int Y;
			public override string ToString()
			{
				return "Vector2i(" + numbers() + ")";
			}
			public string numbers()
			{
				return X.ToString() + ", " + Y.ToString();
			}
			public Vector2i(int x, int y)
			{
				X = x;
				Y = y;
			}
			public Vector2i(Vector2i value)
			{
				X = value.X;
				Y = value.Y;
			}
		}
		public class Vector3
		{
			public float X;
			public float Y;
			public float Z;
			public override string ToString()
			{
				return "Vector3(" + numbers() + ")";
			}
			public string numbers()
			{
				return X.ToString() + ", " + Y.ToString() + ", " + Z.ToString();
			}
			public Vector3(float x, float y, float z)
			{
				X = x;
				Y = y;
				Z = z;
			}
			public Vector3(Vector2 xy, float z)
			{
				X = xy.X;
				Y = xy.Y;
				Z = z;
			}
			public Vector3(float x, Vector2 yz)
			{
				X = x;
				Y = yz.X;
				Z = yz.Y;
			}
			public Vector3(Vector3 value)
			{
				X = value.X;
				Y = value.Y;
				Z = value.Z;
			}
		}
		public class Vector3i
		{
			public int X;
			public int Y;
			public int Z;
			public override string ToString()
			{
				return "Vector3i(" + numbers() + ")";
			}
			public string numbers()
			{
				return X.ToString() + ", " + Y.ToString() + ", " + Z.ToString();
			}
			public Vector3i(int x, int y, int z)
			{
				X = x;
				Y = y;
				Z = z;
			}
			public Vector3i(Vector2i xy, int z)
			{
				X = xy.X;
				Y = xy.Y;
				Z = z;
			}
			public Vector3i(int x, Vector2i yz)
			{
				X = x;
				Y = yz.X;
				Z = yz.Y;
			}
			public Vector3i(Vector3i value)
			{
				X = value.X;
				Y = value.Y;
				Z = value.Z;
			}
		}
		public class Vector4
		{
			public float X;
			public float Y;
			public float Z;
			public float W;
			public override string ToString()
			{
				return "Vector4(" + numbers() + ")";
			}
			public string numbers()
			{
				return X.ToString() + ", " + Y.ToString() + ", " + Z.ToString() + ", " + W.ToString();
			}
			public Vector4(float x, float y, float z, float w)
			{
				X = x;
				Y = y;
				Z = z;
				W = w;
			}
			public Vector4(Vector2 xy, float z, float w)
			{
				X = xy.X;
				Y = xy.Y;
				Z = z;
				W = w;
			}
			public Vector4(float x, Vector2 yz, float w)
			{
				X = x;
				Y = yz.X;
				Z = yz.Y;
				W = w;
			}
			public Vector4(float x, float y, Vector2 zw)
			{
				X = x;
				Y = y;
				Z = zw.X;
				W = zw.Y;
			}
			public Vector4(Vector2 xy, Vector2 zw)
			{
				X = xy.X;
				Y = xy.Y;
				Z = zw.X;
				W = zw.Y;
			}
			public Vector4(Vector3 xyz, float w)
			{
				X = xyz.X;
				Y = xyz.Y;
				Z = xyz.Z;
				W = w;
			}
			public Vector4(float x, Vector3 yzw)
			{
				X = x;
				Y = yzw.X;
				Z = yzw.Y;
				W = yzw.Z;
			}
			public Vector4(Vector4 value)
			{
				X = value.X;
				Y = value.Y;
				Z = value.Z;
				W = value.W;
			}
		}
		public class Vector4i
		{
			public int X;
			public int Y;
			public int Z;
			public int W;
			public override string ToString()
			{
				return "Vector4i(" + numbers() + ")";
			}
			public string numbers()
			{
				return X.ToString() + ", " + Y.ToString() + ", " + Z.ToString() + ", " + W.ToString();
			}
			public Vector4i(int x, int y, int z, int w)
			{
				X = x;
				Y = y;
				Z = z;
				W = w;
			}
			public Vector4i(Vector2i xy, int z, int w)
			{
				X = xy.X;
				Y = xy.Y;
				Z = z;
				W = w;
			}
			public Vector4i(int x, Vector2i yz, int w)
			{
				X = x;
				Y = yz.X;
				Z = yz.Y;
				W = w;
			}
			public Vector4i(int x, int y, Vector2i zw)
			{
				X = x;
				Y = y;
				Z = zw.X;
				W = zw.Y;
			}
			public Vector4i(Vector2i xy, Vector2i zw)
			{
				X = xy.X;
				Y = xy.Y;
				Z = zw.X;
				W = zw.Y;
			}
			public Vector4i(Vector3i xyz, int w)
			{
				X = xyz.X;
				Y = xyz.Y;
				Z = xyz.Z;
				W = w;
			}
			public Vector4i(int x, Vector3i yzw)
			{
				X = x;
				Y = yzw.X;
				Z = yzw.Y;
				W = yzw.Z;
			}
			public Vector4i(Vector4i value)
			{
				X = value.X;
				Y = value.Y;
				Z = value.Z;
				W = value.W;
			}
		}
		public class Rect2
		{
			public Vector2 Position;
			public Vector2 Size;
			public override string ToString()
			{
				return "Rect2(" + Position.numbers() + ", " + Size.numbers() + ")";
			}
			public Rect2(Vector2 pos, Vector2 size)
			{
				Position = pos;
				Size = size;
			}
		}
		public class Rect2i
		{
			public Vector2i Position;
			public Vector2i Size;
			public override string ToString()
			{
				return "Rect2i(" + Position.numbers() + ", " + Size.numbers() + ")";
			}
			public Rect2i(Vector2i pos, Vector2i size)
			{
				Position = pos;
				Size = size;
			}
		}
		public class AABB
		{
			public Vector3 Position;
			public Vector3 Size;
			public override string ToString()
			{
				return "AABB(" + Position.numbers() + ", " + Size.numbers() + ")";
			}
			public AABB(Vector3 pos, Vector3 size)
			{
				Position = pos;
				Size = size;
			}
		}
		public class Basis
		{
			public Vector3 X;
			public Vector3 Y;
			public Vector3 Z;
			public override string ToString()
			{
				return "Basis(" + numbers() + ")";
			}
			public string numbers()
			{
				return X.ToString() + ", " + Y.ToString() + ", " + Z.ToString();
			}
			public Basis(Vector3 x, Vector3 y, Vector3 z)
			{
				X = x;
				Y = y;
				Z = z;
			}
		}
		public class Transform2D
		{
			public Vector2 X;
			public Vector2 Y;
			public Vector2 Origin;
			public override string ToString()
			{
				return "Transform2D(" + X.ToString() + ", " + Y.ToString() + ", " + Origin.ToString() + ")";
			}
			public Transform2D(Vector2 x, Vector2 y, Vector2 origin)
			{
				X = x;
				Y = y;
				Origin = origin;
			}
		}
		public class Transform3D
		{
			public Basis Basis;
			public Vector3 Origin;
			public override string ToString()
			{
				return "Transform3D(" + Basis.numbers() + ", " + Origin.numbers() + ")";
			}
			public Transform3D(Basis basis, Vector3 origin)
			{
				Basis = basis;
				Origin = origin;
			}
		}
		public class Color
		{
			public float R;
			public float G;
			public float B;
			public float A;
			public override string ToString()
			{
				return "Color(" + numbers() + ")";
			}
			public string numbers()
			{
				return R.ToString() + ", " + G.ToString() + ", " + B.ToString() + ", " + A.ToString();
			}
			public Color(float r, float g, float b, float a = 1.0f)
			{
				R = r;
				G = g;
				B = b;
				A = a;
			}
		}
		public class Projection
		{
			public Vector4 X;
			public Vector4 Y;
			public Vector4 Z;
			public Vector4 W;
			public override string ToString()
			{
				return "Projection(" + X.ToString() + ", " + Y.ToString() + ", " + Z.ToString() + ", " + W.ToString() + ")";
			}
			public Projection(Vector4 x, Vector4 y, Vector4 z, Vector4 w)
			{
				X = x;
				Y = y;
				Z = z;
				W = w;
			}
		}
		public VariantType Type = VariantType.NULL;
		public float FloatValue;
		public int IntValue;
		public string StringValue;
		public List<byte> PackedByteArrayValue;
		public List<float> PackedFloatArrayValue;
		public List<int> PackedIntArrayValue;
		public List<string> PackedStringArrayValue;
		public List<Vector2> PackedVector2ArrayValue;
		public List<Vector3> PackedVector3ArrayValue;
		public List<Vector4> PackedVector4ArrayValue;
		public List<Color> PackedColorArrayValue;
		public Dictionary<Variant, Variant> DictionaryValue;
		public List<Variant> ArrayValue;
		public Basis BasisValue;
		public Transform2D Transform2DValue;
		public Transform3D Transform3DValue;
		public Vector2 Vector2Value;
		public Vector2i Vector2iValue;
		public Vector3 Vector3Value;
		public Vector3i Vector3iValue;
		public Vector4 Vector4Value;
		public Vector4i Vector4iValue;
		public Rect2 Rect2Value;
		public Rect2i Rect2iValue;
		public AABB AABBValue;
		public Color ColorValue;
		public bool BoolValue;
		public Projection ProjectionValue;
		public SceneExternalDependency ExtResourceRef;
		public SceneInternalResource IntResourceRef;
		public enum VariantType
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
			PACKEDSTRINGARRAY,
			DICTIONARY,
			ARRAY,
			COLOR,
			PACKEDCOLORARRAY,
			PROJECTION,
			STRINGNAME,
			NODEPATH,
			BOOL,
			EXTERNAL_DEPENDENCY,
			INTERNAL_RESOURCE,
			NULL
		}

		public override string ToString()
		{
			string str = "";
			switch (Type)
			{
				case VariantType.FLOAT:
					return FloatValue.ToString();
				case VariantType.INT:
					return IntValue.ToString();
				case VariantType.VECTOR2:
					return Vector2Value.ToString();
				case VariantType.VECTOR2I:
					return Vector2iValue.ToString();
				case VariantType.VECTOR3:
					return Vector3Value.ToString();
				case VariantType.VECTOR3I:
					return Vector3iValue.ToString();
				case VariantType.VECTOR4:
					return Vector4Value.ToString();
				case VariantType.VECTOR4I:
					return Vector4iValue.ToString();
				case VariantType.STRING:
					return "\"" + StringValue.Replace("\\", "\\\\").Replace("\"", "\\\"") + "\"";
				case VariantType.RECT2:
					return Rect2Value.ToString();
				case VariantType.RECT2I:
					return Rect2iValue.ToString();
				case VariantType.AABB:
					return AABBValue.ToString();
				case VariantType.PACKEDBYTEARRAY:
					return "PackedByteArray(\"" + Convert.ToBase64String(PackedByteArrayValue.ToArray()) + "\")";
				case VariantType.PACKEDFLOAT32ARRAY:
					foreach (var item in PackedFloatArrayValue)
					{
						str += ", " + item.ToString();
					}

					return "PackedFloat32Array(" + str.Substring(2) + ")";
				case VariantType.PACKEDFLOAT64ARRAY:
					foreach (var item in PackedFloatArrayValue)
					{
						str += ", " + item.ToString();
					}

					return "PackedFloat64Array(" + str.Substring(2) + ")";
				case VariantType.PACKEDINT32ARRAY:
					foreach (var item in PackedFloatArrayValue)
					{
						str += ", " + item.ToString();
					}

					return "PackedFloat32Array(" + str.Substring(2) + ")";
				case VariantType.PACKEDINT64ARRAY:
					foreach (var item in PackedFloatArrayValue)
					{
						str += ", " + item.ToString();
					}

					return "PackedFloat64(" + str.Substring(2) + ")";
				case VariantType.PACKEDVECTOR2ARRAY:
					foreach (var item in PackedVector2ArrayValue)
					{
						str += ", " + item.numbers();
					}

					return "PackedVector2Array(" + str.Substring(2) + ")";
				case VariantType.PACKEDVECTOR3ARRAY:
					foreach (var item in PackedVector3ArrayValue)
					{
						str += ", " + item.numbers();
					}

					return "PackedVector3Array(" + str.Substring(2) + ")";
				case VariantType.PACKEDVECTOR4ARRAY:
					foreach (var item in PackedVector4ArrayValue)
					{
						str += ", " + item.numbers();
					}

					return "PackedVector4Array(" + str.Substring(2) + ")";
				case VariantType.PACKEDSTRINGARRAY:
					foreach (string item in PackedStringArrayValue)
					{
						str += ", \"" + item.Replace("\\", "\\\\").Replace("\"", "\\\"") + "\"";
					}
					return "PackedStringArray(" + str.Substring(2) + ")";
				case VariantType.DICTIONARY:
					foreach (var item in DictionaryValue)
					{
						str += ",\n" + item.Key.ToString() + ": " + item.Value.ToString();
					}

					return "{" + str.Substring(1) + "\n}";
				case VariantType.ARRAY:
					foreach (var item in ArrayValue)
					{
						str += ", " + item.ToString();
					}

					return "[" + str.Substring(2) + "]";
				case VariantType.COLOR:
					return ColorValue.ToString();
				case VariantType.PACKEDCOLORARRAY:
					foreach (var item in PackedColorArrayValue)
					{
						str += ", " + item.numbers();
					}

					return "PackedColorArray(" + str.Substring(2) + ")";
				case VariantType.PROJECTION:
					return ProjectionValue.ToString();
				case VariantType.STRINGNAME:
					return "&\"" + StringValue + "\"";
				case VariantType.NODEPATH:
					return "NodePath(\"" + StringValue + ")";
				case VariantType.BOOL:
					return BoolValue.ToString();
				case VariantType.EXTERNAL_DEPENDENCY:
					return ExtResourceRef.GetReference();
				case VariantType.INTERNAL_RESOURCE:
					return IntResourceRef.GetReference();
			}
			return "null";

		}

		public static Variant FromPrimitive(string value)
		{
			Variant var = new Variant();
			var.Type = VariantType.STRING;

			var.StringValue = value;
			return var;
		}
		public static Variant FromPrimitive(float value)
		{
			Variant var = new Variant();
			var.Type = VariantType.FLOAT;

			var.FloatValue = value;
			return var;
		}
		public static Variant FromPrimitive(int value)
		{
			Variant var = new Variant();
			var.Type = VariantType.INT;

			var.IntValue = value;
			return var;
		}
		public static Variant FromPrimitive(bool value)
		{
			Variant var = new Variant();
			var.Type = VariantType.BOOL;

			var.BoolValue = value;
			return var;
		}

		public static Variant FromPrimitiveArray(byte[] value)
		{
			Variant var = new Variant();
			var.Type = VariantType.PACKEDBYTEARRAY;

			var.PackedByteArrayValue = new List<byte>(value);
			return var;
		}
		public static Variant FromPrimitiveArray(int[] value)
		{
			Variant var = new Variant();
			var.Type = VariantType.PACKEDINT32ARRAY;

			var.PackedIntArrayValue = new List<int>(value);
			return var;
		}
		public static Variant FromPrimitiveArray(float[] value)
		{
			Variant var = new Variant();
			var.Type = VariantType.PACKEDFLOAT32ARRAY;

			var.PackedFloatArrayValue = new List<float>(value);
			return var;
		}
		public static Variant FromPrimitiveArray(string[] value)
		{
			Variant var = new Variant();
			var.Type = VariantType.PACKEDSTRINGARRAY;

			var.PackedStringArrayValue = new List<string>(value);
			return var;
		}

		public static Variant FromPrimitiveArray64Bit(float[] value)
		{
			Variant var = FromPrimitiveArray(value);
			var.Type = VariantType.PACKEDFLOAT64ARRAY;
			return var;
		}
		public static Variant FromPrimitiveArray64Bit(int[] value)
		{
			Variant var = FromPrimitiveArray(value);
			var.Type = VariantType.PACKEDINT64ARRAY;
			return var;
		}

		public static Variant NewVec2(float x, float y)
		{
			Variant var = new Variant();
			var.Type = VariantType.VECTOR2;

			var.Vector2Value = new Vector2(x, y);
			return var;
		}
		public static Variant NewVec2(Vector2 value)
		{
			Variant var = new Variant();
			var.Type = VariantType.VECTOR2;

			var.Vector2Value = new Vector2(value);
			return var;
		}

		public static Variant NewVec2i(int x, int y)
		{
			Variant var = new Variant();
			var.Type = VariantType.VECTOR2I;

			var.Vector2iValue = new Vector2i(x, y);
			return var;
		}
		public static Variant NewVec2i(Vector2i value)
		{
			Variant var = new Variant();
			var.Type = VariantType.VECTOR2I;

			var.Vector2iValue = new Vector2i(value);
			return var;
		}

		public static Variant NewVec3(float x, float y, float z)
		{
			Variant var = new Variant();
			var.Type = VariantType.VECTOR3;

			var.Vector3Value = new Vector3(x, y, z);
			return var;
		}
		public static Variant NewVec3(Vector3 value)
		{
			Variant var = new Variant();
			var.Type = VariantType.VECTOR3;

			var.Vector3Value = new Vector3(value);
			return var;
		}

		public static Variant NewVec3i(int x, int y, int z)
		{
			Variant var = new Variant();
			var.Type = VariantType.VECTOR3I;

			var.Vector3iValue = new Vector3i(x, y, z);
			return var;
		}
		public static Variant NewVec3i(Vector3i value)
		{
			Variant var = new Variant();
			var.Type = VariantType.VECTOR3I;

			var.Vector3iValue = new Vector3i(value);
			return var;
		}

		public static Variant NewVec4(float x, float y, float z, float w)
		{
			Variant var = new Variant();
			var.Type = VariantType.VECTOR4;

			var.Vector4Value = new Vector4(x, y, z, w);
			return var;
		}
		public static Variant newVec4(Vector4 value)
		{
			Variant var = new Variant();
			var.Type = VariantType.VECTOR4;

			var.Vector4Value = new Vector4(value);
			return var;
		}

		public static Variant newVec4i(int x, int y, int z, int w)
		{
			Variant var = new Variant();
			var.Type = VariantType.VECTOR4I;

			var.Vector4iValue = new Vector4i(x, y, z, w);
			return var;
		}
		public static Variant newVec4i(Vector4i value)
		{
			Variant var = new Variant();
			var.Type = VariantType.VECTOR4I;

			var.Vector4iValue = new Vector4i(value);
			return var;
		}


	}

}