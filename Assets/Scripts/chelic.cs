using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chelic : MonoBehaviour
{
    public  float spead;
    public bool Is_lestnica;
    public Rigidbody rb;
    public Camera Camera; 
    public static float spd;
    public static bool is_ground;
    public int x;
    public static  float progress= 5f;
    public static float KD = 0f;
    public float X;
   // bool Is_Paused;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Peremennie()
    {
       // Is_Paused = Pause_Menu.Is_Paused;
    }
    void FixedUpdate()
    {
        Dvizhenie();
        spd = rb.velocity.magnitude;
        X = spd;
        Peremennie();
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            is_ground = true;
            x = 1;
        }
        if (collision.gameObject.tag == "Lestnica")
        {
          //  Is_lestnica = true;
            is_ground = true;
            x = 1;
        }

    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            is_ground = false;
            x = 0;
        }
        if (collision.gameObject.tag == "Lestnica")
        {
           // Is_lestnica = false;
          //  x = 0;
        }
    }
    void Dop_Push()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            spead = 4f;
            if ((progress <= 5)&&(KD==0))
            {
                progress += Time.deltaTime;
            }
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            if (progress > 0f)
            {
                spead = 20f;
                progress -= Time.deltaTime;
            }
            else
            {
                spead = 10;
            }
        }
        else
        {
            spead = 10;
            if ((progress <= 5) && (KD == 0))
            {
                progress += Time.deltaTime;
            }
        }

        if (progress <= 0f)
        {
            if (KD < 12f)
            {
                KD += Time.deltaTime;
            }
            else
            {
                progress = 5f;
                KD = 0;
            }
        }
    }
    void Dvizhenie()
    {
       // if (Is_Paused == false)
        {
            float Y = 0f; ;
            Dop_Push();
            if (is_ground == true)
            {
                if (Is_lestnica == true)
                {
                  ///  Y = 2;
                }
                else
                {
                    Y = 0;
                }
                if (Input.GetKey(KeyCode.W))
                {
                    Vector3 dwiz = new Vector3(Camera.transform.forward.x, Y, Camera.transform.forward.z);
                    {
                        rb.velocity = dwiz.normalized * spead;
                    }

                }
                if (Input.GetKey(KeyCode.S))
                {
                    Vector3 dwiz = new Vector3(Camera.transform.forward.x, Y, Camera.transform.forward.z);
                    {
                        rb.velocity = -dwiz.normalized * spead;
                    }
                }
                if (Input.GetKey(KeyCode.D))
                {
                    Vector3 dwiz = new Vector3(Camera.transform.right.x, Y, Camera.transform.right.z);
                    {
                        rb.velocity = dwiz.normalized * spead;
                    }
                }
                if (Input.GetKey(KeyCode.A))
                {
                    Vector3 dwiz = new Vector3(Camera.transform.right.x, Y, Camera.transform.right.z);
                    {
                        rb.velocity = -dwiz.normalized * spead;
                    }
                }
                if ((!Input.GetKey(KeyCode.W)) && (!Input.GetKey(KeyCode.A)) && (!Input.GetKey(KeyCode.S)) && (!Input.GetKey(KeyCode.D)))
                {
                    rb.velocity = new Vector3(0f, -1f, 0f) * (spead-1);
                }
            }
            else
            {
                rb.AddForce(new Vector3(0f, -1f, 0f)  * spead*2);
            }

        }
    }

}
