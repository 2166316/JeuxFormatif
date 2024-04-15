using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform target; 
    public float speed = 20; 
    public Vector3 offset;   
    //offset approprié 0f, 2f, -5f
    void Start(){
        offset = new Vector3(-5f, 2f, 0f);
    }

    void Update(){
        
    }

    void LateUpdate()
    {
        if (target != null)
        { 
            Vector3 desiredPosition = target.position + offset; 
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, speed * Time.deltaTime);
            transform.position = smoothedPosition;
        }
    }
}
