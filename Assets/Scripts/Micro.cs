using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Micro : MonoBehaviour
{ 
    AudioSource aud;
    public bool is_speak_for_vkl = true;
    public bool is_speak_for_vikl = false;
    //public float volume;
    void Start()
    {
        aud = GetComponent<AudioSource>();
        Microphone.GetDeviceCaps("", out int minFreq, out int maxFreq);
        aud.clip = Microphone.Start("", true, 100, 88200);
        aud.Play();
    }
    private void Update()
    {
        
    }
    /*  void Microphone_vkl()
      { 
          if(is_speak_for_vkl == true)
          {
              is_speak_for_vkl = false;
              Microphone.GetDeviceCaps("", out int minFreq, out int maxFreq);
              aud.clip = Microphone.Start("", true, 100, 88200);
              aud.Play();
              is_speak_for_vikl = true;
          }

      }
      void Microphone_vikl()
      {
          if (is_speak_for_vikl == true)
          {
              is_speak_for_vikl = false;
              aud.Stop();
              Microphone.End("");
              is_speak_for_vkl = true;
          }
      }
    */
}
