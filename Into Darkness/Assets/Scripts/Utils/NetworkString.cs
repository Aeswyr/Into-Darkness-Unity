using Unity.Netcode;
using Unity.Collections;

public struct NetworkString : INetworkSerializable {
    private FixedString32Bytes data;

    public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter {
        serializer.SerializeValue(ref data);
    }
    
    public override string ToString() {
        return data.ToString();
    }

    public static implicit operator string(NetworkString s) => s.ToString();
    public static implicit operator NetworkString(string s) => new NetworkString {data = new FixedString32Bytes(s)};
}