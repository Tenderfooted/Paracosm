﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
	private Vector3 offset;
 	// Use this for initialization
	void Start () {
	Player = GameObject.FindGameObjectWithTag("Player");
	offset = transform.position - Player.transform.position;	

	}
	
	// Update is called once per frame
	void Update () {
	transform.position = Player.transform.position + offset;	
	}
}
