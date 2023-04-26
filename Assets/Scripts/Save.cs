using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Save : MonoBehaviour
{
    
    void Start()
    {
        
        if (PlayerPrefs.HasKey("Yarkost"))
        {
           All_Settings.Yarkost = PlayerPrefs.GetFloat("Yarkost");
        }
        else
        {
           All_Settings.Yarkost = 0;
        }
    }
}
