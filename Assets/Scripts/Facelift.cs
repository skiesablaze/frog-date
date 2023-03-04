using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.UI;

public class Facelift : MonoBehaviour
{
    private DialogueRunner dialogueRunner;
    private Scoring faceliftScore;
    public GameObject[] emotions;
    public GameObject goalFrog;
    public Image clockHand;
    public Canvas gameUI;
    public AudioClip winSound;
    public AudioClip loseSound;
    private AudioSource resultAudioSource;


    [YarnCommand("start_facelift")]
    public void StartFacelift(){
        Debug.Log("runs facelift commands");
        //Start ScoreTimer
        //StartClock
        SpawnGoalFrog();
        StartCoroutine(ScoreTimer());
    }

    private void SpawnGoalFrog(){
        int idx = Random.Range(0, emotions.Length);
        goalFrog = emotions[idx];
        // setting goal frog off screen
        Vector3 position = new Vector3(-10f,-10f,-10f);
        Instantiate(goalFrog, position, Quaternion.Euler(0,90,0));

        Debug.Log(goalFrog.name);
    }

    IEnumerator ScoreTimer(){
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        var clockScript = clockHand.GetComponent<Clock>();
        clockScript.running = true;
        clockScript.curTime = 0;
        yield return new WaitForSeconds(5);
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        //run score function
        //call node depending on returned score
        print(faceliftScore.score("frog2_manybones", $"{goalFrog.name}(Clone)"));

        //TODO: change that 80 to a constant
        if (faceliftScore.score("frog2_manybones", $"{goalFrog.name}(Clone)") > 80){
            Debug.Log("goodend");
            resultAudioSource.clip = winSound;
            resultAudioSource.Play();
            dialogueRunner.StartDialogue("GoodEnd");
        }
        else{
            Debug.Log("badend");
            resultAudioSource.clip = loseSound;
            resultAudioSource.Play();
            dialogueRunner.StartDialogue("BadEnd");
        }
    }
    void Start(){
        dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
        faceliftScore = FindObjectOfType<Scoring>();
        gameUI.enabled = true;
        resultAudioSource = gameObject.GetComponent<AudioSource>();
    }
}
