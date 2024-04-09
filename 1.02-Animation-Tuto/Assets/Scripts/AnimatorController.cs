using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator animator;
    public float speedvoulu = 2f;
    private float vitesseMarche = 0f;

    private int animatorSpeedHash;
    private int animatorRotationRightHash;
    private int animatorRotationLeftHash;

    private const string speed = "Speed";
    private const string turningRight = "TurningRight";
    private const string turningLeft = "TurningLeft";
    // Start is called before the first frame update
    void Start()
    {
        //va chercher l'animator sur le game object avec le script (player)
        animator = GetComponent<Animator>();
        animatorSpeedHash = Animator.StringToHash(speed);
        animatorRotationRightHash = Animator.StringToHash(turningRight);
        animatorRotationLeftHash = Animator.StringToHash(turningLeft);
    }

    // Update is called once per frame
    void Update()
    {
        float vitesse = vitesseMarche;
        float avance = Input.GetAxis("Vertical");

         float vitesseRotation = 75.0f;
        float rotate = Input.GetAxis("Horizontal");
        float rotation = Input.GetAxis("Horizontal") * vitesseRotation * Time.deltaTime;

        Debug.Log(rotate + "");
        if (rotate > 0)
        {
            // Player is moving right
            transform.Rotate(0,(rotation),0);
            animator.SetBool(animatorRotationRightHash, true);
        }
        else if (rotate < 0)
        {
            // Player is moving left
            transform.Rotate(0, (rotation), 0);
            animator.SetBool(animatorRotationLeftHash, true);
        }
        else
        {
            // Player is not moving horizontally
            animator.SetBool(animatorRotationRightHash, false);
            animator.SetBool(animatorRotationLeftHash, false);
        }

        if (avance > 0)
        {
            animator.SetFloat(animatorSpeedHash, speedvoulu);
            transform.Translate(Vector3.forward * (speedvoulu * Time.deltaTime));
        }
        else
        {
            animator.SetFloat(animatorSpeedHash, vitesse);
        }

       // animator.SetFloat(animatorSpeedHash, vitesse);
    }
}
