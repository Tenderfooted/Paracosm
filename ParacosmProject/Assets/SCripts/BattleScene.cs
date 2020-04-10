using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScene : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Camera;
	private Vector3 offset;
    
 	// Use this for initialization
	void Start () {
	Camera = GameObject.FindGameObjectWithTag("MainCamera");
	
	}
	
	// Update is called once per frame
	void Update () {
	transform.position = Camera.transform.position ;	
	    
    }

}
