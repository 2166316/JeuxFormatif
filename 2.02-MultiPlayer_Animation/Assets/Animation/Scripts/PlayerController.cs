using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;

    //la constant qui contient le nom deu parametre pour communiquer avec l'Animator
    private const string DANCING = "dancing";

    //HashCode vers les variables de l'Animator (permet de communiquer avec lui)
    private int animatorDancingHash;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animatorDancingHash = Animator.StringToHash(DANCING);

    }

    // Update is called once per frame
    void Update()
    {
        bool isDancing = Input.GetKey(KeyCode.Space);
        animator.SetBool(animatorDancingHash, isDancing);
    }
}
