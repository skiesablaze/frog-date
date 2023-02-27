using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;



public class Scoring : MonoBehaviour
{
    private GetBones playerFrog;
    private GetBones goalFrog;
    private List<Transform> goalBones;
    private List<Transform> playerBones;
    public Vector3 translation;
    float score()
    {
        translation = new Vector3(0f,12f,0f);
        float pairdistance = 0;
        float totalDistance = 0;

        playerFrog = GameObject.Find("frog2_manybones").GetComponent<GetBones>();
        playerFrog.getBones();
        playerBones = playerFrog.listOfBones;

        goalFrog = GameObject.Find("goalFrog").GetComponent<GetBones>();
        goalFrog.getBones();
        goalBones = goalFrog.listOfBones;
        
        var playerAndGoal = playerBones.Zip(goalBones, (p, g) => new {player = p, goal = g});
        foreach(var bonePair in playerAndGoal)
        {
            Vector3 worldgoal = transform.TransformPoint(bonePair.goal.position);
            Vector3 worldplayer = transform.TransformPoint(bonePair.player.position)+translation;
            pairdistance = Vector3.Distance(worldgoal, worldplayer);
            totalDistance += pairdistance;
            //totalDistance += Mathf.Pow(pairdistance, 2);
            
        }
        totalDistance = 100 - 100 * totalDistance/playerAndGoal.Count();
        return(totalDistance);
    }
    void Update(){
        if (Input.GetKeyDown("space")){
        float Score;
        Score = score();
        if (Score > 99){
            Score = 100;
        }        
        print("score = "+ Score);
        }

    }
}
