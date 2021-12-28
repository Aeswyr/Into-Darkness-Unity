using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerManager : NetworkSingleton<PlayerManager> {
    private NetworkVariable<int> playerCount = new NetworkVariable<int>();

    void Start() {
        NetworkManager.Singleton.OnClientConnectedCallback += OnPlayerJoin;
        NetworkManager.Singleton.OnClientDisconnectCallback += OnPlayerLeave;    
    }

    private void OnPlayerJoin(ulong id) {
        playerCount.Value++;
        Debug.Log($"Player {id} joined");
    }

    private void OnPlayerLeave(ulong id) {
        playerCount.Value--;
        Debug.Log($"Player {id} left");
    }
}