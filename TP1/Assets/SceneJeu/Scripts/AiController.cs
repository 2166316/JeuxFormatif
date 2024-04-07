using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AiController : MonoBehaviour
{

    public UnityEngine.AI.NavMeshAgent ai; 

    public GameObject[] goals;
     
    public bool moving = false; 

    private GameObject goalActual;

    void Start()
    {
        int goalNb = goals.Length;
        goalActual = new GameObject();
        changeGoal();
    }

    public void changeGoal(){
        System.Random random = new System.Random();
        int newGoal = random.Next(0,(goals.Length));
        while( (goals[newGoal].Equals(goalActual))){
            newGoal = random.Next(0,(goals.Length));
             
        }
        //print(newGoal);
        goalActual = goals[newGoal];
    }



    void OnTriggerEnter(Collider coll){

        if (coll.gameObject.tag == "Goal")
        {
           // print("Collision");
            changeGoal();
            moving = false;
            print("particule");
            //stop particules
            ParticleSystem particleSystem = coll.gameObject.GetComponentInChildren<ParticleSystem>();
            if (particleSystem != null)
            {
                print("particule");
                particleSystem.Stop();

                //reset les particules dans 1 seconde    
                float nbSeconde = 3f;
                StartCoroutine(RestartParticlesAfterDelay(particleSystem, nbSeconde));
            }
        }
    }

    void Update()
    {
        if (!moving) 
        { 
          ai.SetDestination(goalActual.transform.position);
          moving = true;
        }
    }

     //coroutine pour repartir particules   
    IEnumerator RestartParticlesAfterDelay(ParticleSystem particleSystem, float delay)
    {
        yield return new WaitForSeconds(delay);

        // Restart particles
        particleSystem.Play();
    }
}
