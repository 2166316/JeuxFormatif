using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim; 
    int variableVerticalMove; 
    int variableHorizontalMove; 
    // Start is called before the first frame update
    void Start() { 
        variableVerticalMove = Animator.StringToHash("vertical"); 
        variableHorizontalMove = Animator.StringToHash("horizontal"); 
    } // Update is called once per frame
      void Update() { 
        Move(); 
    } 
    private void Move() { 
        float vertical = Input.GetAxis("Vertical"); 
        float horizontal = Input.GetAxis("Horizontal"); 
        Vector3 movement = transform.forward * vertical + transform.right * horizontal; 
        movement *= Time.deltaTime; 
        transform.position += movement; 
        anim.SetFloat(variableVerticalMove, vertical); 
        anim.SetFloat(variableHorizontalMove, horizontal); 
    }
}
