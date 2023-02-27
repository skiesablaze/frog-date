using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManipulatorMouseControl : MonoBehaviour
{
    private Camera Camera;
    private bool _dragging;
    private Vector3 offset;
    private Vector3 screenPoint;
    private Collider curBone;


    void Start()
    {
        Camera = GameObject.Find("PlayerCam").GetComponent<Camera>();
    }

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
                //Debug.Log(hit.collider.transform.parent.gameObject.name);
                if(hit.collider.transform.parent.gameObject.name == "Armature") 
                {
                    curBone = hit.collider;
                    screenPoint = Camera.main.WorldToScreenPoint(curBone.transform.position);
                    offset = curBone.transform.position - Camera.ScreenToWorldPoint(Vector3.Scale(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z), new Vector3(-1,-1,1)));
                    //Debug.Log(curBone);
                    _dragging = true;
                    //Debug.Log("Click");
                    
                }
                
            }
        }
        else if (_dragging && Input.GetMouseButton(0))
        {
            Vector3 curScreenPoint = Vector3.Scale(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z), new Vector3(-1,-1,1));
            Vector3 curPosition = Camera.ScreenToWorldPoint(curScreenPoint)+ offset;
            curBone.transform.position = curPosition;
            //Debug.Log(curBone);
            //Debug.Log(Camera.ScreenToWorldPoint(Input.mousePosition));
            //var mouseDelta = Camera.ScreenToWorldPoint(Input.mousePosition);
            //curBone.transform.Translate(mouseDelta);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("MouseUp");
            _dragging = false;
        }
    }
}
