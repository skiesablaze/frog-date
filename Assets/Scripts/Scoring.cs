using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Scoring : MonoBehaviour
{
    private GetBones playerGetBones;
    private GetBones goalGetBones;
    private List<Transform> goalBones;
    private List<Transform> playerBones;
    public GameObject goalFrog;
    public Vector3 translation;
    public string playerName;
    public string goalName;


    float score(string playerName, string goalName)
    {
        translation = new Vector3(0f,12f,0f);
        float pairdistance = 0;
        float totalDistance = 0;

        playerGetBones = GameObject.Find(playerName).GetComponent<GetBones>();
        playerGetBones.getBones();
        playerBones = playerGetBones.listOfBones;

        goalGetBones = GameObject.Find(goalName).GetComponent<GetBones>();
        goalGetBones.getBones();
        goalBones = goalGetBones.listOfBones;
        
        var playerAndGoal = playerBones.Zip(goalBones, (p, g) => new {player = p, goal = g});
        foreach(var bonePair in playerAndGoal)
        {
            Vector3 worldgoal = transform.TransformPoint(bonePair.goal.position);
            Vector3 worldplayer = transform.TransformPoint(bonePair.player.position)+translation;
            pairdistance = Vector3.Distance(worldgoal, worldplayer);
            totalDistance += pairdistance;            
        }
        totalDistance = 100 - 100 * totalDistance/playerAndGoal.Count();
        return(totalDistance);
    }
    void Start() {
        playerName = "frog2_manybones";
        goalName = "cute_frog";
    }
    void Update(){
        float Score;
        Score = score(playerName, goalName);
        if (Score > 99){
            Score = 100;
        }        
        }

}
