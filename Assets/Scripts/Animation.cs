using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animation : chelic
{
    //float spd;
    public Animator animator;

    // Update is called once per frame
    void FixedUpdate()
    {
        //spd = chelic.spd;
        
        if (is_ground == true)
        { 
            if (Input.GetKey(KeyCode.W))
            {
                animator.SetBool("Walk", true);
            }
            else
            {
                animator.SetBool("Walk", false);
            }

            if ((Input.GetKey(KeyCode.D))&&(Input.GetKey(KeyCode.LeftControl)))
            {
                animator.SetBool("Right_Ctrl", true);
            }
            else
            {
                animator.SetBool("Right_Ctrl", false);
            }
            if ((Input.GetKey(KeyCode.W)) && (Input.GetKey(KeyCode.LeftControl)))
            {
                animator.SetBool("Farward_Ctrl", true);
            }
            else
            {
                animator.SetBool("Farward_Ctrl", false);
            }

            if ((Input.GetKey(KeyCode.A)) && (Input.GetKey(KeyCode.LeftControl)))
            {
                animator.SetBool("Left_Ctrl", true);
            }
            else
            {
                animator.SetBool("Left_Ctrl", false);
            }

            if ((Input.GetKey(KeyCode.S)) && (Input.GetKey(KeyCode.LeftControl)))
            {
                animator.SetBool("Back_Ctrl", true);
            }
            else
            {
                animator.SetBool("Back_Ctrl", false);

            }

            if (Input.GetKey(KeyCode.A))
            {
                animator.SetBool("Left", true);
            }
            else
            {
                animator.SetBool("Left", false);
            }

            if (Input.GetKey(KeyCode.S))
            {
                animator.SetBool("Back", true);
            }
            else
            {
                animator.SetBool("Back", false);
            }


            if (Input.GetKey(KeyCode.D))
            {
                animator.SetBool("Right", true);
            }
            else
            {
                animator.SetBool("Right", false);
            }

            if (Input.GetKey(KeyCode.LeftControl))
            {
                animator.SetBool("Ctrl", true);
            }
            else
            {
                animator.SetBool("Ctrl", false);
            }
            if(chelic.spead>=20)
            {
                animator.SetBool("Ran", true);
            }
            else
            {
                animator.SetBool("Ran", false);
            }
        }
    }


}
