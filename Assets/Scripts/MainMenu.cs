using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class MainMenu : MonoBehaviour
{
    private Camera mainCamera; 
    private bool fading = false;
    public Canvas canvas;

    private DialogueRunner dialogueRunner;

    void Start()
    {
        mainCamera = Camera.main;
        dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
    }
    void Update()
    {
        var curAlpha = canvas.GetComponent<CanvasGroup>().alpha;
        if(fading == true && curAlpha > 0) 
        {
            canvas.GetComponent<CanvasGroup>().alpha = curAlpha - (0.75f * Time.deltaTime);
        }
        else if(fading == true && curAlpha <= 0)
        {
            fading = false;
            //mainCamera.transform.position = new Vector3(0,0,0);

        }
    }
    
    public void StartGame()
    {
        var alphaColor = canvas.GetComponent<CanvasGroup>().alpha;
        Debug.Log(alphaColor);
        fading = true;
        Debug.Log(fading);

        dialogueRunner.StartDialogue("Date");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting");
    }
}