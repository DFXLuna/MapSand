﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicFollower : MonoBehaviour {

	public GameObject toFollow;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = new Vector3( toFollow.transform.position.x, 
		                                   transform.position.y, 
										   toFollow.transform.position.z );

	}
}
