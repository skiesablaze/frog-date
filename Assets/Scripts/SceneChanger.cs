using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;
  
public class SceneChanger : MonoBehaviour 
{
    
    void start()
    {
        var audioSource = GetComponent<AudioSource>();
        Debug.Log(audioSource.time);
        //public static int GetDifferentiatingVariable () { return differentiatingVariable; }
    }

    
    [YarnCommand("start_button")]
    public void PressStart()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }
    
    [YarnCommand("credits")]
    public void LoadCredits()
    {
        SceneManager.LoadScene(3, LoadSceneMode.Single);
    }
    
    public void ChangeScene(int sceneID) 
    {  
        SceneManager.LoadScene(sceneID);  
    }  
}   