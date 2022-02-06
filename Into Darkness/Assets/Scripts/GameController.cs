using UnityEngine;
using Unity.Netcode;
using TMPro;

public class GameController : Singleton<GameController>
{

    [SerializeField] private TextMeshProUGUI infoText;
    // Start is called before the first frame update
    async void Start()
    {
        NetworkStartVars startData = FindObjectOfType<NetworkStartVars>();
        if (startData == null || startData.IsHost) {
            if (RelayManager.Instance.IsRelayEnabled)
                await RelayManager.Instance.SetupRelay();
            if (NetworkManager.Singleton.StartHost()) {
                Debug.Log("Host started");
                infoText.text = $"Join Code: {RelayManager.Instance.JoinCode}";
            } else {
                Debug.Log("Host failed");
            }
        } else {
            if (RelayManager.Instance.IsRelayEnabled)
                await RelayManager.Instance.JoinRelay(startData.joinCode);
            if (NetworkManager.Singleton.StartClient()) {
                Debug.Log("Client Started");
            } else {
                Debug.Log("Client Failed");
            }
        }
        if (startData != null)
            Destroy(startData.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
