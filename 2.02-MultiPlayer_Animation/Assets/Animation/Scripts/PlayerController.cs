using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using System;

public class PlayerController : NetworkBehaviour
{
    private Animator animator;

    //la constant qui contient le nom deu parametre pour communiquer avec l'Animator
    private const string DANCING = "dancing";

    //HashCode vers les variables de l'Animator (permet de communiquer avec lui)
    private int animatorDancingHash;

    void Start()
    {
        animator = GetComponent<Animator>();
        animatorDancingHash = Animator.StringToHash(DANCING);

    }

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        if(!IsHost && IsOwner)
        {
            UpdatePositionServerRpc();
        }
    }

    [Rpc(SendTo.Server)]
    private void UpdatePositionServerRpc()
    {
        transform.Translate(Vector3.left * 2);
    }

    void Update()
    {
        //Debug.Log("d");

        if (IsOwner)
        {
           bool isDancing = Input.GetKey(KeyCode.Space);
            ManageDancingAnimationRpc(Input.GetKey(KeyCode.Space));
            //animator.SetBool(animatorDancingHash, isDancing);
        }
    }

    [RpcAttribute(SendTo.Server)]
    private void ManageDancingAnimationRpc(bool isDancing)
    {
        animator.SetBool(animatorDancingHash, isDancing);
    }
}
