using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateByMouse : MonoBehaviour {

    public float minX = -360.0f;
    public float maxX = 360.0f;

    public float minY = -45.0f;
    public float maxY = 45.0f;

    public float sensX = 500.0f;
    public float sensY = 500.0f;

    float rotationY = 0.0f;
    float rotationX = 0.0f;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if(Input.touchCount == 2){

            }else if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)            
            {
                rotationX -= Input.GetAxis("Mouse X") * sensX * Time.deltaTime;
                rotationY += Input.GetAxis("Mouse Y") * sensY * Time.deltaTime;
                rotationY = Mathf.Clamp(rotationY, minY, maxY);
                transform.GetChild(0).localEulerAngles = new Vector3(0, rotationX, 0);
                transform.localEulerAngles = new Vector3(rotationY, 0, 0);              

            }
        }
    }
}
