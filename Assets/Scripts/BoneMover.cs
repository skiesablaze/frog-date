using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneMover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LateUpdate () {
        if (Input.GetKeyDown("a"))
        {
            transform.Rotate(Vector3.up, 10);
        }
    }

}
