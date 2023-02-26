using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManipulatorMouseControl : MonoBehaviour
{
    public Camera Camera;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("Mouse Click");
            
            var ray = Camera.ScreenPointToRay(Input.mousePosition);
            //Debug.DrawRay(ray.origin, ray.direction*4, Color.green, 10000f, false);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
            Debug.Log(hit.collider);
            hit.collider.transform.Rotate(Vector3.up);
            // the object identified by $$anonymous$$t.transform was clicked
            // do whatever you want
            }
        }
    }
}
