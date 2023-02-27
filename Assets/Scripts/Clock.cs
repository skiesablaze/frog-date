using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public float maxTime = 60f;
    public float curTime = 0f;
    public bool running = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(running == true) 
        {
        curTime = curTime + Time.deltaTime;
        var curAngle = new Vector3(0,0,1) * (curTime / maxTime) * 360.0f;
        transform.eulerAngles = -curAngle;

        if(curTime > maxTime)
        {
            curTime = maxTime;
        }
        }
    }
}
