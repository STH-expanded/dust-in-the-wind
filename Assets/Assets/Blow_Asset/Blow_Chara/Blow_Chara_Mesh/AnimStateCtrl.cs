using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimStateCtrl : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        // Walking input
        bool isWalking = animator.GetBool("Is_Walking");
        bool forwardPressed = gameObject.tag == "Player1" ? Input.GetKey("up") || Input.GetKey("left") || Input.GetKey("right") || Input.GetKey("down") : Input.GetKey("z") || Input.GetKey("q") || Input.GetKey("s") || Input.GetKey("d");

        if (!isWalking && forwardPressed)
        {
            animator.SetBool("Is_Walking", true);
        }

        if (isWalking && !forwardPressed)
        {
            animator.SetBool("Is_Walking", false);
        }

        // Breathe_Out input
        bool isBreatheOut = animator.GetBool("Is_Breathe_Out");
        blowHitbox targetHitbox = gameObject.transform.GetChild(1).GetComponent<blowHitbox>();
        bool BreatheOutPressed = Input.GetKey(targetHitbox.blowKey);

        if (!isBreatheOut && BreatheOutPressed)
        {
            animator.SetBool("Is_Breathe_Out", true);
        }

        if (isBreatheOut && !BreatheOutPressed)
        {
            animator.SetBool("Is_Breathe_Out", false);
        }

        // Breathe_In input
        bool isBreatheIn = animator.GetBool("Is_Breathe_In");
        bool BreatheInPressed = Input.GetKey(targetHitbox.attractKey);

        if (!isBreatheIn && BreatheInPressed)
        {
            animator.SetBool("Is_Breathe_In", true);
        }

        if (isBreatheIn && !BreatheInPressed)
        {
            animator.SetBool("Is_Breathe_In", false);
        }

        // faire le triger du GetHit quand le perso ce fait hit par le collider du wind
        bool isGetingHit = animator.GetBool("Is_GetingHit");

    }
}
