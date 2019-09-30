using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        float XRot = Input.GetAxis("Horizontal") * 10 ;
        Quaternion target= Quaternion.Euler(23.19f , XRot , 0);
       transform.rotation =  Quaternion.Slerp(transform.rotation , target, Time.deltaTime * 5);
	}
}
