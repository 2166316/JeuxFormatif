using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AiController : MonoBehaviour
{

    public UnityEngine.AI.NavMeshAgent ai; 
    private Animator animator;
    public GameObject[] goals;
    private const string SPEED = "Speed";
    private int animatorVitesseHash;
    private const string CRAWL = "Crawling";
    private int animatorCrawlHash;
    private const string BLEND = "Blend";
    private int animatorBlendHash;
    
    private GameObject goalActual;
    private bool isCrawling;
    private float originalSpeed;

    private bool isdancing = false;

    void Start()
    {
        originalSpeed = ai.speed;
        animator = GetComponent<Animator>();
        animatorBlendHash = Animator.StringToHash(BLEND);
        animatorVitesseHash = Animator.StringToHash(SPEED);
        animatorCrawlHash = Animator.StringToHash(CRAWL);
        int goalNb = goals.Length;
        goalActual = new GameObject();
        changeGoal();

    }

    public void changeGoal(){
        System.Random random = new System.Random();
        int newGoal = random.Next(0,(goals.Length));
        while( goals[newGoal].Equals(goalActual)){
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
            //print("particule");
            //stop particules
            ParticleSystem particleSystem = coll.gameObject.GetComponentInChildren<ParticleSystem>();
            if (particleSystem != null)
            {
                particleSystem.Stop();
                //reset les particules dans 1 seconde    
                float nbSeconde = 10f;
                StartCoroutine(RestartParticlesAfterDelay(particleSystem, nbSeconde));
                StartCoroutine(StopPlayerDance());
            }else{
                changeGoal();
            }
        }

        print(coll.gameObject.tag.ToString());
        if(coll.gameObject.tag == "CrawlSpace"){
            print(1);
            animator.SetBool(animatorCrawlHash, true);
            ai.speed = 0.8f;
        }
        else if(coll.gameObject.tag == "Walk"){
            print(2);
             animator.SetBool(animatorCrawlHash, false);
            ai.speed = 1f;
        }
        else{
            print(3);
            animator.SetBool(animatorCrawlHash, false);
            ai.speed = originalSpeed;
        }

        
    }

    void Update()
    {
        if(!isdancing){
            ai.isStopped = false;
            ai.SetDestination(goalActual.transform.position);

            float currentSpeed = ai.velocity.magnitude;
            animator.SetFloat(animatorVitesseHash, currentSpeed);
        }
    }


    //coroutine pour dancer
    IEnumerator StopPlayerDance()
    {
        isdancing = true;
        ai.isStopped = true;
        animator.SetFloat(animatorBlendHash,1);
        yield return new WaitForSeconds(1f);
        animator.SetFloat(animatorBlendHash,2);
        yield return new WaitForSeconds(2f);
        animator.SetFloat(animatorBlendHash,0);
        isdancing = false;
    }

     //coroutine pour repartir particules   
    IEnumerator RestartParticlesAfterDelay(ParticleSystem particleSystem, float duration)
    {
        yield return new WaitForSeconds(duration);

        //restart particules
        particleSystem.Play();
    }
}
