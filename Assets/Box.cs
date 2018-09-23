using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
        GameObject go = GameObject.Find("Outside_Grounds");
        Debug.Log(go.transform.childCount);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
