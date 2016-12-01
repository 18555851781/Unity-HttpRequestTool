using UnityEngine;

using System;
using System.IO;
using System.Text;
using System.Reflection;
using System.Runtime.Serialization;
using System.Collections;
using System.Collections.Generic;



namespace MoLiFrameWork.Network
{
	/// <summary>
	/// Json packer.
	/// </summary>
	public class JsonPacker
	{
		/// <summary>
		/// Unpack the specified json and t.
		/// </summary>
		/// <param name="json">Json.</param>
		/// <param name="t">T.</param>
		public static object Unpack( string name,JSONNode json , Type t )
		{
			if (t.IsPrimitive)
			{
				if (t.Equals (typeof (int))) return int.Parse(json.Value);
				else if (t.Equals (typeof (int))) return int.Parse(json.Value);
				else if (t.Equals (typeof (uint))) return uint.Parse(json.Value);
				else if (t.Equals (typeof (float))) return float.Parse(json.Value);
				else if (t.Equals (typeof (double))) return double.Parse(json.Value);
				else if (t.Equals (typeof (long))) return long.Parse(json.Value);
				else if (t.Equals (typeof (ulong))) return ulong.Parse(json.Value);
				else if (t.Equals (typeof (bool))) return bool.Parse(json.Value);
				else if (t.Equals (typeof (byte))) return byte.Parse(json.Value);
				else if (t.Equals (typeof (sbyte))) return sbyte.Parse(json.Value);
				else if (t.Equals (typeof (short))) return short.Parse(json.Value);
				else if (t.Equals (typeof (ushort))) return ushort.Parse(json.Value);
				else if (t.Equals (typeof (char))) return char.Parse(json.Value);
				else if (t.Equals (typeof(string))) return json.Value;
				else
				{
					throw new NotSupportedException (name + " is NotSupportedException:"+t.Name); 
				}
			}

			if( t.Equals(typeof(string)))
				return json.Value;

			if (t.IsArray)
			{
				if ( !(json is JSONArray) )
					throw new FormatException("");
				Type et = t.GetElementType ();
				Array ary = Array.CreateInstance (et, json.Count);
				for (int i = 0; i < ary.Length; i ++)
					ary.SetValue (Unpack ("array", json[i] , et), i);
				return ary;
			}

			if (t.IsGenericType) {

				var d = new Dictionary<string,string>();
				foreach( KeyValuePair<string,JSONNode> item in json.AsObject)
				{
					d.Add(item.Key,item.Value.ToString());
				}
				return new DictionaryWapper<string,string>(d);
			}
			
			object o;
			if(t.IsSubclassOf(typeof(ScriptableObject)))
			{
				o = ScriptableObject.CreateInstance (t);
			}
			else
			{
				o = FormatterServices.GetUninitializedObject (t);
			}
			ReflectionCacheEntry entry = ReflectionCache.Lookup (t);
			foreach( KeyValuePair<string,JSONNode> item in json.AsObject)
			{
				string filed_name = item.Key;

				FieldInfo f;
				if (!entry.FieldMap.TryGetValue (filed_name, out f))
				{
					//error
					Debug.Log("no property name: " + filed_name);
					continue;
					//throw new FormatException ();
				}
				f.SetValue (o, Unpack (name, item.Value , f.FieldType));
			}
			return o;
		}
	}

}
