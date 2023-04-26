using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class vzaimodeistvie_c_vrsgom : chelic
{
    bool uron;
    public int sostoynie = 100;
    float secundomer = 0f;
    public float Health = 100;
    public bool uron_ot_visoti;
    public Transform Player;
    public Transform Vrag;
    float Radius = 50;
    float Radius_Vzxglyda = 1000;
    public bool is_speak_for_vkl = true;
    public bool is_speak_for_vikl = false;


    void Start()
    {
        
    }
    void Minus_Zdorovie()
    {
        if (uron == true)
        {
            uron = false;
            Health -= 33.5f;
        }
        if (is_ground == false)
        {
            uron_ot_visoti = true;
        }
        if ((is_ground == true) && (uron_ot_visoti == true))
        {
            uron_ot_visoti = false;
            Health -= 10f;
        }
       // Slider_Health.value = Health / 100f;
    }
    void  Minus_Sosotoynie()
    {
        RaycastHit hit;
        Ray ray = new Ray(Player.transform.position + new Vector3(0, 1f, 0), (Vrag.position - Player.position));
        Physics.Raycast(ray, out hit, Radius_Vzxglyda);
        //Debug.DrawLine(ray.origin, hit.point, Color.blue);
        if (((Vector3.Distance(Player.position, Vrag.position) <= Radius) && (hit.collider.gameObject == Vrag.gameObject)))
        {
            secundomer += Time.deltaTime;
            if (secundomer >= 0.5f)
            {
                sostoynie--;
                secundomer = 0f;
            }
        }
    }
    void Dvizhenie_na_Micro()
    {
        
       /* if (Input.GetKeyUp(KeyCode.B))
        {
            GetComponent<Micro>().enabled = false;
        }
       */
    }

    void FixedUpdate()
    {
        Minus_Sosotoynie();
        Minus_Zdorovie();
       // Dvizhenie_na_Micro();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Vrag")
        {
            uron = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Vrag")
        {
            uron = false;
        }
    }
}
