
using UnityEngine;
using Unity.Netcode;

public class NetworkSingleton<T> : NetworkBehaviour where T : Component {
    public static readonly T Instance = (T)FindObjectOfType(typeof(T));
}