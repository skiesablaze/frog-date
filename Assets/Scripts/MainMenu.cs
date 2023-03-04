using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class MainMenu : MonoBehaviour
{
    private Camera mainCamera;
    private Camera playerCamera;
    private Canvas gameUI;
    public Canvas canvas;
    public Button StartBtn;
    private AudioSource bgmusic;
    private Gameplay playerScript;
    private GameObject SceneManager;
    //private bool fading = false;
    // new script
    private bool fading = false;
    // new script    
    private DialogueRunner dialogueRunner;
    
    void Start()
    {
        dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
        mainCamera = Camera.main;
        // playerCamera = GameObject.Find("PlayerCam").GetComponent<Camera>();
        // gameUI = GameObject.Find("GameUI").GetComponent<Canvas>();
        bgmusic = gameObject.GetComponent<AudioSource>();
        Button btn = StartBtn.GetComponent<Button>();
        // playerScript = GameObject.Find("frog2_manybones").GetComponent<Gameplay>();
    }
    
    
    public void StartGame()
    {
        var alphaColor = canvas.GetComponent<CanvasGroup>().alpha;
        Debug.Log(fading);
        dialogueRunner.StartDialogue("Date");

    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting");
    }
    void TaskOnClick(){
        fading = true;
        Debug.Log ("You have clicked the button!");
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
            //fading = false;
            StartGame();
            fading = false;
        }
    }
}