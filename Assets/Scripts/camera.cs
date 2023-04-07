using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class camera : MonoBehaviour
{
    float x;
    float y;
    float xzh_chto = 0.7f;
    public Transform Player;
    float x_prom;
    float y_prom;
    float speed_dvizh = 0.5f;
    float curent_X;
    float curent_Y;
    float speed_Uv = 2.5f;
    float speed_Um = 1.5f;
    public float progress;
    public float KD;
    bool Is_Paused = false;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Peremennie()
    {
        progress = chelic.progress;
        KD = chelic.KD;
        //Is_Paused = Pause_Menu.Is_Paused;
    }
    void FixedUpdate()
    {
        Camera_Dvizh();
        Pole_Zreniy();
        Cursor_Loc();
        Peremennie();
    }
    void Cursor_Loc()
    {
        if (Is_Paused == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
    void Pole_Zreniy()
    {
        if (Is_Paused == false)
        {
            if ((Input.GetKey(KeyCode.LeftShift)) && (((Input.GetKey(KeyCode.W))) || (Input.GetKey(KeyCode.A))
                || (Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.D))) && (!Input.GetKey(KeyCode.LeftControl)))
            {
                if (progress > 0f)
                {
                    Camera.main.fieldOfView = Mathf.MoveTowards(Camera.main.fieldOfView, 90.0f, speed_Uv);
                }
                else
                {
                    Camera.main.fieldOfView = Mathf.MoveTowards(Camera.main.fieldOfView, 60.0f, speed_Um);
                }
            }
            else
            {
                Camera.main.fieldOfView = Mathf.MoveTowards(Camera.main.fieldOfView, 60.0f, speed_Um);
            }
        }

    }
           

void Camera_Dvizh()
    {
        if (Is_Paused == false)
        {
            x += Input.GetAxis("Mouse X") * xzh_chto;
            y += Input.GetAxis("Mouse Y") * xzh_chto;
            y = Mathf.Clamp(y, -90, 90);

            x_prom = Mathf.SmoothDamp(x, x_prom, ref curent_X, speed_dvizh);
            y_prom = Mathf.SmoothDamp(y, y_prom, ref curent_Y, speed_dvizh);
            transform.rotation = Quaternion.Euler(-y_prom, x_prom, 0f);
            Player.transform.rotation = Quaternion.Euler(0f, x_prom, 0f);
        }
    }
}
