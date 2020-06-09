using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
	private Vector3 offset;
	public static CameraScript instance;

	void Awake()
	{
		if (instance != null)
        {
            Destroy (gameObject);
        }
        else
        {
            instance = this;
        }
	}
 	// Use this for initialization
	void Start () {
	Player = GameObject.FindGameObjectWithTag("Player");
	transform.position = new Vector3(Player.transform.position.x,Player.transform.position.y,transform.position.z);
	offset = transform.position - Player.transform.position;	

	}
	
	// Update is called once per frame
	void Update () {
	transform.position = Player.transform.position + offset;	
	}
}
