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
    private AudioSource bgmusic;
    private Gameplay playerScript;
    private bool fading = false;
    private DialogueRunner dialogueRunner;
    
    void Start()
    {
        dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
        mainCamera = Camera.main;
        playerCamera = GameObject.Find("PlayerCam").GetComponent<Camera>();
        gameUI = GameObject.Find("GameUI").GetComponent<Canvas>();
        bgmusic = gameObject.GetComponent<AudioSource>();
        playerScript = GameObject.Find("frog2_manybones").GetComponent<Gameplay>();
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
            bgmusic.enabled = false;
            //mainCamera.transform.position = new Vector3(-0.35f,1.35f,-0.76f);
            //mainCamera.transform.rotation = Quaternion.Euler(new Vector3(13,110,0));
            playerCamera.enabled = true;
            gameUI.enabled = true;

        }
    }
    
    public void StartGame()
    {
        var alphaColor = canvas.GetComponent<CanvasGroup>().alpha;
        fading = true;
        Debug.Log(fading);
        dialogueRunner.StartDialogue("Date");
        playerScript.enabled = true;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting");
    }
 
}