using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Rendering;

public class All_Settings : MonoBehaviour
{
    // public Slider Volume_Slider;
    //public float Volume;

    public Slider Yarkost_Slider;
    public static float Yarkost;
    public PostProcessProfile x;
    ColorGrading ColorGrading;
    public Dropdown Razhreshenie;
    Resolution[] resolutions;

    void Start()
    {
        Start_Razreshenie();
        Start_Yarkost();
    }
    void Update()
    {
        Yarkost = (Yarkost_Slider.value * 100 - 50);
        ColorGrading.brightness.value = Yarkost;
    }
    public void SaveGame()
    {
        PlayerPrefs.SetFloat("Yarkost", Yarkost);
        PlayerPrefs.Save();
    }
    void Start_Yarkost()
    {
        x.TryGetSettings(out ColorGrading);
        if (PlayerPrefs.HasKey("Yarkost"))
        {
            Yarkost = PlayerPrefs.GetFloat("Yarkost");
        }
        else
        {
            Yarkost = 0;
        }
        Yarkost_Slider.value = (Yarkost + 50) / 100;
    }
    void Start_Razreshenie()
    {
        Razhreshenie.ClearOptions();
        List<string> option = new List<string>();
        resolutions = Screen.resolutions;
        int index = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            option.Add(resolutions[i].width+"x"+resolutions[i].height+" "+resolutions[i].refreshRate+"Hz");
            if((resolutions[i].width==Screen.currentResolution.width)&&(resolutions[i].height==Screen.currentResolution.height))
            {
                index = i;
            }
        }
        Razhreshenie.AddOptions(option);
        Razhreshenie.RefreshShownValue();
    }
    public void Set_Razhreshenie(int index)
    {
        Resolution resolution = resolutions[index];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

}

