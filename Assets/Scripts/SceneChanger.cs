using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;
  
public class SceneChanger : MonoBehaviour 
{
    [YarnCommand("credits")]
    public void LoadCredits()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
    
    public void ChangeScene(int sceneID) 
    {  
        SceneManager.LoadScene(sceneID);  
    }  
}   