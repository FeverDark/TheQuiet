using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AnimaytionVraga : vrag
{
    // Start is called before the first frame update

    public Animator animator;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Is_Viiev_dlya_anim==true)
        {
            animator.SetBool("Beg", true);
        }
        else
        {
            animator.SetBool("Beg", false);
        }

        if(bool_for_patrool==true)
        {
            animator.SetBool("Patrool", true);
        }
        else
        {
            animator.SetBool("Patrool", false);
        }

    }
}
