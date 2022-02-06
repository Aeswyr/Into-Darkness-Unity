using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable] public class SerializableDictionary<K, V> : Dictionary<K, V>, ISerializationCallbackReceiver
{
    [SerializeField] private List<Pair> list = new List<Pair>();

    // save the dictionary to lists
    public void OnBeforeSerialize()
    {
        //list.Clear();

        //foreach (KeyValuePair<K, V> pair in this)
        //{
        //    list.Add(new Pair {key = pair.Key, value = pair.Value});
        //}
    }

    // load dictionary from lists
    public void OnAfterDeserialize()
    {
        this.Clear();

        for (int i = 0; i < list.Count; i++)
            if (!this.ContainsKey(list[i].key))
                this.Add(list[i].key, list[i].value);
    }
    [Serializable] private struct Pair {
        public K key;
        public V value;
    }

}
