using System.Threading.Tasks;
using UnityEngine;
using Unity.Netcode;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Core.Environments;
using Unity.Services.Relay;
using Unity.Services.Relay.Models;

public class RelayManager : Singleton<RelayManager>
{
    [SerializeField] private string environment = "production";
    [SerializeField] private int maxConnections = 8;
    [SerializeField] private UnityTransport transport => NetworkManager.Singleton.gameObject.GetComponent<UnityTransport>();
    public bool IsRelayEnabled => transport != null && transport.Protocol == UnityTransport.ProtocolType.RelayUnityTransport;
    public string JoinCode {
        get;
        private set;
    }

    public async Task<RelayHostData> SetupRelay() {
        Debug.Log("Relay server starting");

        InitializationOptions options = new InitializationOptions()
            .SetEnvironmentName(environment);
        await UnityServices.InitializeAsync(options);

        if (!AuthenticationService.Instance.IsSignedIn) {
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
        }

        Allocation allocation = await Relay.Instance.CreateAllocationAsync(maxConnections);
        RelayHostData relayHostData = new RelayHostData {
            Key = allocation.Key,
            Port = (ushort)allocation.RelayServer.Port,
            AllocationID = allocation.AllocationId,
            AllocationIDBytes = allocation.AllocationIdBytes,
            IPv4Address = allocation.RelayServer.IpV4,
            ConnectionData = allocation.ConnectionData,
        };

        relayHostData.JoinCode = await Relay.Instance.GetJoinCodeAsync(relayHostData.AllocationID);
        transport.SetRelayServerData(relayHostData.IPv4Address, relayHostData.Port, relayHostData.AllocationIDBytes,
            relayHostData.Key, relayHostData.ConnectionData);

        Debug.Log($"Relay server started with join code {relayHostData.JoinCode}");
        JoinCode = relayHostData.JoinCode;

        return relayHostData;
    }

    public async Task<RelayJoinData> JoinRelay(string joinCode) {
        Debug.Log($"Relay attempting to join room {joinCode}");

        InitializationOptions options = new InitializationOptions()
            .SetEnvironmentName(environment);
        await UnityServices.InitializeAsync(options);

        if (!AuthenticationService.Instance.IsSignedIn) {
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
        }

        JoinAllocation allocation = await Relay.Instance.JoinAllocationAsync(joinCode);
        RelayJoinData relayJoinData = new RelayJoinData {
            Key = allocation.Key,
            Port = (ushort)allocation.RelayServer.Port,
            AllocationID = allocation.AllocationId,
            AllocationIDBytes = allocation.AllocationIdBytes,
            IPv4Address = allocation.RelayServer.IpV4,
            ConnectionData = allocation.ConnectionData,
            HostConnectionData = allocation.HostConnectionData,
            JoinCode = joinCode,
        };

        transport.SetRelayServerData(relayJoinData.IPv4Address, relayJoinData.Port, relayJoinData.AllocationIDBytes,
            relayJoinData.Key, relayJoinData.ConnectionData, relayJoinData.HostConnectionData);

        Debug.Log("Relay joined successfully");
        JoinCode = relayJoinData.JoinCode;

        return relayJoinData;
    }
}
