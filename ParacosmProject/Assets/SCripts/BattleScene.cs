using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScene : MonoBehaviour
{
    // Start is called before the first frame update
	public static BattleScene instance;
    public GameObject Camera;

	private Vector3 offset;
    playertime
    
 	// Use this for initialization
	void Awake()						// set up for battle scene to become a singleton if required later on
    {
        if (instance != null)
        {
            Destroy (gameObject);
        }
        else
        {
            instance = this;
			Debug.Log("BattleScene instance set");
        }
	}
	void Start () {
	Camera = GameObject.FindGameObjectWithTag("MainCamera");
	
	}
	
	// Update is called once per frame
	void Update () {
	//transform.position = Camera.transform.position ;	
	    
    }
    public void EnemyDeath()
    {
        GameManager.BattleSceneOff();

    }
    public void InitiateCombat()
    {

    }

}
