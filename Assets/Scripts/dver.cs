using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dver : MonoBehaviour
{
    public bool Is_Open = false;
    public GameObject dver_;
    public GameObject chel;
    // Update is called once per frame
    void FixedUpdate()
    {
        if ((Mathf.Pow((chel.transform.position.x - dver_.transform.position.x), 2)) + (Mathf.Pow((chel.transform.position.y - dver_.transform.position.y), 2)) <= 10)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                if(Is_Open==false)
                {
                    dver_.transform.RotateAround(new Vector3(1,0,0),new Vector3(0,1,0), 90f);
                    Is_Open = true;
                }
                else
                {
                    dver_.transform.RotateAround(new Vector3(1, 0, 0), new Vector3(0, 1, 0), -90f);
                    Is_Open = false;
                }
            }
        }
    }
}
