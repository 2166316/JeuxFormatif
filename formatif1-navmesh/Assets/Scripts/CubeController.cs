using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public  GameObject cube;

    public float xPosMax;
    public float xPosMin;

    public bool moveUp;

    public float moveSpeed;


    // Start is called before the first frame update
    void Start()
    {
        if(transform.position.x >= xPosMax){
            moveUp = false;
        }
        else{
            moveUp = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
    
        if(transform.position.x >= xPosMax){
            moveUp = false;
        }

        if(transform.position.x <= xPosMin){
            moveUp = true;
        }

        if(moveUp){
          cube.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }else{
          cube.transform.Translate(Vector3.left  * moveSpeed * Time.deltaTime);
        }
    }
}
