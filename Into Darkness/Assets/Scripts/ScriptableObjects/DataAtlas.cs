using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable] public class DataAtlas<K, V> {
    [SerializeField] private List<DataPair> atlas;
    private DataPair[] table;

    public DataAtlas() {
        if (atlas == null)
            return;
        table = new DataPair[atlas.Count * 2];

        foreach (var data in atlas) {
            Insert(data);
        }
    }

    private void Insert(DataPair data) {
        int hash = data.key.GetHashCode();
        int index = hash % table.Length;
        while (table[index] != default(DataPair)) {
            index = (index + 1) % table.Length;
        }
        table[index] = data;
    }

    public V Get(K key) {
        int hash = key.GetHashCode();
        int index = hash % table.Length;
        while (table[index] == default(DataPair) || !Equals<K>(table[index].key, key)) {
            index = (index + 1) % table.Length;
        }
        return table[index].value;
    }

    private static bool Equals<T>(T x, T y) {
         return typeof(T).IsValueType
            ? object.Equals(x, y)
            : ReferenceEquals(x, y);
    }

    [Serializable] private struct DataPair {
        public K key;
        public V value;

        public static bool operator ==(DataPair l, DataPair r) {
            return Equals<K>(l.key, r.key) && Equals<V>(l.value, r.value);
        }

        public static bool operator !=(DataPair l, DataPair r) {
            return !Equals<K>(l.key, r.key) || !Equals<V>(l.value, r.value);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}