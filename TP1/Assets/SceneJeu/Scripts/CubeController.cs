using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public  GameObject cube;

    public float zPosMax;
    public float zPosMin;

    public bool moveUp;

    public float moveSpeed;


    // Start is called before the first frame update
    void Start()
    {
        //base
        zPosMax = 24f;
        zPosMin = 19f;
        if(transform.position.z >= zPosMax){
            moveUp = false;
        }
        else{
            moveUp = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
    
        if(transform.position.z >= zPosMax){
            moveUp = false;
        }

        if(transform.position.z <= zPosMin){
            moveUp = true;
        }

        if(moveUp){
          cube.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }else{
          cube.transform.Translate(Vector3.back  * moveSpeed * Time.deltaTime);
        }
    }
}
