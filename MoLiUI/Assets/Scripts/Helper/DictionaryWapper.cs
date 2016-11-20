using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

public class DictionaryWapper<TKey, TValue>
{

	protected Dictionary<TKey, TValue> _dict;



	public Action<TKey,TValue,TValue> OnChanged;
	public Action<TKey,TValue> OnAdd;
	public Action<TKey,TValue> OnRemoved;

	public Dictionary<TKey,TValue> GetReadOnlyCopy()
	{
		Dictionary<TKey,TValue> newdesc = new Dictionary<TKey,TValue>();

		foreach (KeyValuePair<TKey,TValue> kvp in _dict )
		{
			newdesc.Add(kvp.Key,kvp.Value);
		}
		return newdesc;
	}

	public List<KeyValuePair<TKey,TValue>> ToList(){

		List<KeyValuePair<TKey,TValue>> list = new List<KeyValuePair<TKey, TValue>>();
		foreach (KeyValuePair<TKey,TValue> kvp in _dict )
		{
			list.Add(kvp);
		}

		return list;
	}

	public List<TValue> Values(){
		
		List<TValue> list = new List< TValue>();
		foreach (KeyValuePair<TKey,TValue> kvp in _dict )
		{
			list.Add(kvp.Value);
		}
		
		return list;
	}

	public bool ContainsKey(TKey key)
	{
		return _dict.ContainsKey(key);
	}



	public bool ContainsValue(TValue vaule)
	{
		return _dict.ContainsValue (vaule);
	}

	public KeyValuePair<TKey,TValue> ElementAt(int index)
	{
		//index = 1;
		if (index >=0 && index < _dict.Count) {
			var d = _dict.ElementAt(index);
			var r = new KeyValuePair<TKey, TValue>(d.Key,d.Value);
			return r;
		} else {
			return new KeyValuePair<TKey, TValue>(default(TKey),default(TValue)); ;
		}

	}

	public DictionaryWapper(Dictionary<TKey, TValue> dict)
	{
		_dict = dict;
	}

	public DictionaryWapper()
	{
		_dict = new Dictionary<TKey, TValue>();
	}

	public TValue this[TKey Key]
	{
		get { return _dict[Key]; }
		set 
		{ 
			if (!_dict[Key].Equals(value)) 
			{
				if(OnChanged!=null)
					OnChanged(Key,value,_dict[Key]);

				_dict[Key] = value;
			}
		}


	}

	public int Count
	{
		get{return _dict.Count;}
	}


	public void Add(TKey Key,TValue value)
	{


		_dict.Add (Key, value);
		if(OnChanged!=null){
			OnChanged (Key, value , default(TValue));
		}

		if(OnAdd!=null){
			OnAdd (Key, value);
		}

	}

	public void Clear()
	{
		_dict.Clear ();
	}

	public void Remove(TKey key)
	{
		_dict.Remove(key);
	}
}