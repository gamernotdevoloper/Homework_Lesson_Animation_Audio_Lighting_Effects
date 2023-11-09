using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Animator animator;

    private float xSpeed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Gets the player input 
        xSpeed = Input.GetAxis("Horizontal");


        //Updates the Animator States based on player input 
        if (xSpeed != 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        //Uses scale to flip the player left or right so we can use one animation for walking
        if (xSpeed < 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0,-90,0));
        }
        else if (xSpeed > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
        }

        //Make the player move 
        transform.position += new Vector3(xSpeed * Time.deltaTime, 0, 0);
    }
}
