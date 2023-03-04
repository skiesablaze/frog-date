using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;
  
public class SceneChanger : MonoBehaviour 
{
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