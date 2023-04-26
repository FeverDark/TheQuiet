using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause_Menu : MonoBehaviour
{
    public GameObject pause;
    public static bool Is_Paused = false;
    public bool Is_Setting;

    void Start()
    {
        pause.SetActive(false);
    }
    void FixedUpdate()
    {
        Proverka_Na_Ecpeape();
    }
    public  void Vikluchenie_Nastroek()
    {
        pause.SetActive(false);
        Is_Paused = false;
    }

    void Proverka_Na_Ecpeape()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Is_Paused == true)
            {
                Continue();
            }
            else
            {
                Pause();
            }
        }
    }

    void Pause()
    {
        pause.SetActive(true);
        Is_Paused = true;
    }
    void Continue()
    {
        pause.SetActive(false);
        Is_Paused = false;
    }

}
