using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public Vector3 direction = Vector3.forward;
    public float forceMagnitude = 60f;
    public ForceMode forceMode = ForceMode.Impulse;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Push();
        
    }

    void Push()
    {
        rb.AddForce(direction.normalized * (Time.deltaTime * forceMagnitude), forceMode);
    }
}
