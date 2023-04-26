using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Scene_changer : MonoBehaviour
{
    public static string Name;
    public void ChengeName(string name)
    {
        Name = name;
    }
    public void ChangeScene() 
    {
        SceneManager.LoadScene(Name);
    }
    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
