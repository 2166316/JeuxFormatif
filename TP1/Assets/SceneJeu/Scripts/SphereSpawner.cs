using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSpawner : MonoBehaviour
{
   
    private Vector3 pos1 = new Vector3(-6,3,16);
    //private Vector3 pos3 = new Vector3(-6,3,24);
    private Vector3 pos2 = new Vector3(3,3,17);

    public GameObject spawner;

    private GameObject sphere1;
    
    private GameObject sphere2;

    public GameObject prefab;

    void Start()
    {
        sphere1 =  Instantiate(prefab, pos1, Quaternion.identity);
        sphere2 =  Instantiate(prefab, pos2, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

        if(sphere1.transform.position.y < -1){
            Destroy(sphere1);
            sphere1 =  Instantiate(prefab, pos1, Quaternion.identity);
        }

        if(sphere2.transform.position.y < -1){
            Destroy(sphere2);
            sphere2 =  Instantiate(prefab, pos2, Quaternion.identity);
        }
        
    }
}
