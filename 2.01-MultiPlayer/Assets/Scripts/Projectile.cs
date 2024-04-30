using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.ProBuilder;

public class Projectile : NetworkBehaviour
{
    [SerializeField] private GameObject hitParticles;
    private Vector3 shootDirection;
    private GameObject player;

    [SerializeField] private float speed = 10f;
    public void Setup(Vector3 shootDir, GameObject player)
    {
        this.shootDirection = shootDir;
        this.player = player;   
    }

    void Update()
    {
        transform.position += shootDirection * Time.deltaTime * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != player && other.gameObject != gameObject)
        {
            if(other.gameObject.GetComponent<MeshRenderer>().enabled)
            {
                GameObject hitImpact = Instantiate(hitParticles, transform.position, Quaternion.identity);
                hitImpact.transform.localEulerAngles = new Vector3(0, 0, 90);
            }


            DestroyRpc();
        
        }
    }

    //wait before destroying
    private IEnumerator Despawn()
    {
        yield return new  WaitForSeconds(.5f);
        var instanceNetworkObject = gameObject.GetComponent<NetworkObject>();
        instanceNetworkObject.Despawn();

    }

    /// <summary>
    /// Permet de détruire le rpc
    /// </summary>
    [Rpc(SendTo.Server)]
    public void DestroyRpc()
    {
        try
        {
            StartCoroutine(Despawn());

        }
        catch(Exception e)
        {
            Debug.LogError(e.ToString());
        }
    }
}
