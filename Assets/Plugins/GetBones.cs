using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBones : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform){
            Debug.Log(child);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
