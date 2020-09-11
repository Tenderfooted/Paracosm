using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Player;
	private Vector3 offset;
    private Vector3 oldpos;
    private Vector3 targetpos;
	public static BackgroundScript instance;

    
    [Range(0.0f, 1.0f)]
    public float moverate;      // this determines the rate the background moves with the player

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
	void Start () 
    {
	Player = GameObject.FindGameObjectWithTag("Player");
	transform.position = new Vector3(Player.transform.position.x,transform.position.y/*Player.transform.position.y*/,transform.position.z);
	offset = transform.position - Player.transform.position;
    oldpos = transform.position;	

	}
	
	// Update is called once per frame
	void Update () {
	//transform.position = Player.transform.position + offset;

    // plan for backgrounds
    // saves old position and new position to move to, 

    // saves the backgrounds starting position
    // moves halfway(or some value) between the old and new pos to move to
    transform.position = new Vector2(oldpos.x + Player.transform.position.x * moverate, oldpos.y + Player.transform.position.y * moverate);
    }



}
