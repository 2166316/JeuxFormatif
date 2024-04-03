using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent capsule; 
    public GameObject goal; 
    public bool shouldMove = false; 
    // Update is called once per frame 
    void Update() { 
        if (shouldMove) 
        { 
            capsule.SetDestination(goal.transform.position); 
        } 
    }
}
