using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent blueAgent; 
    public UnityEngine.AI.NavMeshAgent redAgent;

    // Start is called before the first frame update 
    void Start() { 
        //agent = GetComponent<UnityEngine.AI.NavMeshAgent>(); 
    } 
    // Update is called once per frame 
    void Update() { 
        if (Input.GetMouseButtonDown(0)) { 

            RaycastHit hit; 

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) 
            { 
                blueAgent.SetDestination(hit.point); 
        
            }
        } 

        if (Input.GetMouseButtonDown(1)) { 

            RaycastHit hit; 

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) 
            { 
                redAgent.SetDestination(hit.point); 
        
            }
        } 
    }
}
