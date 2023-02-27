using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GetBones : MonoBehaviour
{
    public List<Transform> listOfBones;
    public bool testbool = true;

    public void iterBones(Transform t){
        listOfBones.Add(t.transform);
        foreach(Transform child in t.transform){
            iterBones(child);
        }
    }
    // Start is called before the first frame update
    public void getBones()
    {
        listOfBones = new List<Transform>();
        iterBones(gameObject.transform);
        foreach(var bone in listOfBones){
        }
    }
}
