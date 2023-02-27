using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class Facelift : MonoBehaviour
{
    private DialogueRunner dialogueRunner;
    private Scoring faceliftScore;

    [YarnCommand("start_facelift")]
    public void StartFacelift(){
        Debug.Log("runs facelift commands");

        //Start ScoreTimer
        //StartClock
        StartCoroutine(ScoreTimer());
    }

    IEnumerator ScoreTimer(){
        Debug.Log("Started Coroutine at timestamp : " + Time.time);
        yield return new WaitForSeconds(5);
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        //run score function
        //call node depending on returned score
        print(faceliftScore.score("frog2_manybones", "goalFrog"));

        //TODO: change that 80 to a constant
        if (faceliftScore.score("frog2_manybones", "goalFrog") > 80){
            Debug.Log("goodend");
            
            dialogueRunner.StartDialogue("GoodEnd");
        }
        else{
            Debug.Log("badend");
            dialogueRunner.StartDialogue("BadEnd");
        }
    }

    void Start(){
        dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
        faceliftScore = FindObjectOfType<Scoring>();
    }
}
