using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class laglight : MonoBehaviour
{
    public Light x;
    public float time = 0;
    public Material cvet;
    public Material nesvet;
    public GameObject go;
    public bool is_cvet;
     void Start()
     {
        x.intensity = 0;
        go.GetComponent<MeshRenderer>().material = cvet;
     }
    void FixedUpdate()
    {
        time += Time.deltaTime;

            if((time>=0.1)&&(time<0.2))
            {
                x.intensity = 10;
                go.GetComponent<MeshRenderer>().material = cvet;
            }
            else if((time >= 0.2) && (time < 0.3))
            {
                x.intensity = 0;
                go.GetComponent<MeshRenderer>().material = nesvet;
            }
            else if ((time >= 0.3) && (time < 0.4))
            {
                x.intensity = 10;
                go.GetComponent<MeshRenderer>().material = cvet;
            }
            else if ((time >= 0.4) && (time < 0.5))
            {
                x.intensity = 0;
                go.GetComponent<MeshRenderer>().material = nesvet;
            }
            else if ((time >= 0.5) && (time < 0.6))
            {
                x.intensity = 10;
                go.GetComponent<MeshRenderer>().material = cvet;
            }
            else if ((time >= 0.6) && (time < 0.7))
            {
                 x.intensity = 0;
                 go.GetComponent<MeshRenderer>().material = nesvet;
            }
            else if ((time >= 0.7) && (time < 2.2))
             {
                x.intensity = 10;
                go.GetComponent<MeshRenderer>().material = cvet;
             }
            else if(time>=2.5)
            {
                time = 0;
            }
    }
        

}
