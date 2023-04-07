using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class vrag: MonoBehaviour
{
    float Radius_dly_raycast = 1000;
    public float Radius = 25;
    public Rigidbody rb_vraga;
    public float Angle = 90;
    public Transform Player;
    public Transform Vrag;
    public static bool Is_Viiev_dlya_anim = false;
    Color color = Color.white;
    public Transform[] array_points = new Transform[7];
    NavMeshAgent AI_Agent;
    public static bool bool_for_patrool = false;
    public static  bool bool_for_prostoy = false;
    public int kount_for_point;
    bool bool_Dly_smeny;

    AudioListener audioListener;
    public float volum;
    void Start()
    {
        rb_vraga = Vrag.GetComponent<Rigidbody>();
        AI_Agent = gameObject.GetComponent<NavMeshAgent>();
        kount_for_point = Random.Range(1, 7);
        audioListener = GetComponent<AudioListener>();
    }

    void Prostoy()
    {
        if (bool_Dly_smeny == true)
        {
            bool_Dly_smeny = false;
            kount_for_point = Random.Range(0, 6);  
        }
    }

    void Patrool()
    {
            if (Vector3.Distance(array_points[kount_for_point].transform.position, Vrag.transform.position) <= 2)
            {
                bool_Dly_smeny = true;
                bool_for_prostoy = true;
                bool_for_patrool = false;
                rb_vraga.velocity = new Vector3(0f, 0f, 0f);
                Invoke("Prostoy",2);
            }
            else
            {
                AI_Agent.SetDestination(array_points[kount_for_point].transform.position);
                bool_for_patrool = true;
                bool_for_prostoy = false;
            }
    }
   void Is_Viev()
    {
        float real_angle = Vector3.Angle(Vrag.forward, Player.position - Vrag.position);

        RaycastHit hit;
        Ray ray = new Ray(Vrag.transform.position + new Vector3(0,1f,0),(Player.position - Vrag.position));
        Physics.Raycast(ray, out hit, Radius_dly_raycast);
        Debug.DrawLine(ray.origin, hit.point, color);

            /*
            if (hit.collider.gameObject != Player.gameObject)
            {
                color = Color.red;
                h = false;
            }
            else if (hit.collider.gameObject == Player.gameObject)
            {
                color = Color.green;
                h = true;
            }
            */
            if ((real_angle <= Angle / 2) && (Vector3.Distance(Vrag.position, Player.position) <= Radius) && (hit.collider.gameObject == Player.gameObject))
            {
                color = Color.red;
                AI_Agent.SetDestination(Player.transform.position);
                Is_Viiev_dlya_anim = true;
            }
            else
            {
                AI_Agent.SetDestination(array_points[kount_for_point].transform.position);
                Patrool();
                color = Color.green;
                Is_Viiev_dlya_anim = false;
            }
    }
    void FixedUpdate()
    {
        Risunoc();
        Is_Viev();
    }

    void Risunoc()
    {
        Vector3 Right = Vrag.position + Quaternion.Euler(-new Vector3(0, Angle / 2f, 0)) * (Vrag.forward * Radius);
        Vector3 Left = Vrag.position + Quaternion.Euler(new Vector3(0, Angle / 2f, 0)) * (Vrag.forward*Radius);
        Debug.DrawLine(Vrag.position, Left, color);
        Debug.DrawLine(Vrag.position, Right, color);
        Debug.DrawLine(Vrag.position, array_points[kount_for_point].transform.position, color);
    }
}
