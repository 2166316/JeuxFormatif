using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class TestCounter : NetworkBehaviour
{
    private NetworkVariable<int> counter = new NetworkVariable<int>(0,NetworkVariableReadPermission.Everyone,NetworkVariableWritePermission.Owner);

    void Start()
    {
        

    }

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        Debug.Log(counter.Value + "");
       // counter.OnValueChanged += OnCounterChanged;
    }

    private void OnCounterChanged(int? previous,int? current)
    {
        Debug.Log(counter.Value+"");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("Owner?" + IsOwner);
            IncrementCounterServerRpc();
            Debug.Log(counter.Value + "");
        }
    }

    [Rpc(SendTo.Owner)]
    public void IncrementCounterServerRpc()
    {
        counter.Value++;
    }
}
