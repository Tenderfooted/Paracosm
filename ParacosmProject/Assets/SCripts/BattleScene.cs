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

    // combat PsuedoCode:
    /* Player enters combat. Player enters their move while time is frozen, nothing happens in this state.
    when the player enters their move the enemy also picks a move from their list of moves, 
    both the player and the enemies moves have a certain value that must be exceeded before effects of their moves play
    the rate at which the timers that exceeds these values count up is based on the characters Speed stat, which can be altered mid combat by special moves
    when the timer reaches the enemy move, it plays its effects and the enemy picks another move.
    when the timer reaches the players move the effect plays and then time "freezes" allowing the player to pick another move.
    
    normal update method
    Variables needed:
    -player skill cast time sct(will be taken from the skill method/class)     -player speed(will be taken from the player)   -player current timer   ct
    -enemy skill cast time (will be taken from the skill method/class)   -enemy current timer   -enemy speed(will be taken from the enemy)
    
    the timers will need to will need to be counting up every update frame, except when the player is picking their next ability, this will be a boolean set to true 
    when the timer equals the players cast time, if -playfreeze is true then dont update timers. *it cant be If -playerct > Playersct then dont tick up because then the

    if playerct > Player sct                                    
        then dont count up
    if not 
        tick up values
        if playerct > Player sct                                        < in this example the players ability effects would start playing on the frame
            then play abilty effects                                      before the code would start iffing past the tick up values
        if enemyct > enemy sct                                            this could easily be reversed for neatness (if Player sct >player ct then DO count down)
            then play enemy effects                                       Player sct would need to be reset to 0 when the player picks there next ability.  
            enemy sct = pick new enemy ability.exe
            ect = 0

    IEnumerator Timer()
    {
        for
    }
    I was gonna try to do a co-routine, but Ive never written one before
    */
}
