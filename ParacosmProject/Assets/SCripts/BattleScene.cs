using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScene : MonoBehaviour
{
    // Start is called before the first frame update
	public static BattleScene instance;
    public GameObject Camera;

	private Vector3 offset;
    public float playertime;                // the time the player is on    when it reaches the players cast time it performs the action
    float enemytime;                        // the current time the enemy is on when it equals their cast time they perform their action
    bool TimerActive;                       //  is used to check if the turn is counting down*
    
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
    public void InitiateCombat(OverworldEnemy Enemy)
    {
        TimerActive = false;
        
    }

}
