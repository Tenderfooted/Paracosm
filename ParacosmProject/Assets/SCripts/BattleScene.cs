using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleScene : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider ActionBar;
    public GameObject PlayerActionIcon;
    public GameObject playerIcon;                   //this is used purely to set the starting position for action bar UI elements, pretty Dodgy I know
    public Vector3 ActionbarStart;

    public BattleEnemy[] enemies;
    public GameObject[] spawnpoints;                // this is an array that grabs all the spawn points from the battlescene<< will later be populated by grabbing all tagged spawnpoints when moving to a scene based battle system.

    private OverworldEnemy oldovenemy;
	public static BattleScene instance;
    public GameObject Camera;

	private Vector3 offset;                                     // Forgive me 

    public float playerct;                // the time the player is on    when it reaches the players cast time it performs the action These var names f*cking suck so hopefully Ill fix it later
    public float playersct;               // the current cast time of the skill determines how far along the action bar the player must move before casting

    public float playerspeed = 1;               // the players speed, determines how fast they move on the action bar
    
    float enemyct;                        // the current time the enemy is on when it equals their cast time they perform their action
    public float enemysct;                // the enemies cast time for their current ability                    
    public float enemysspeed;             // the enemy speed   
    // bool TimerActive;                       //  is used to check if the turn is counting down*
    
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
        gameObject.SetActive(false);
	}
	void Start () {
	Camera = GameObject.FindGameObjectWithTag("MainCamera");
    ActionbarStart = playerIcon.transform.position; 
                         // lil cheeky way to set the battlescene to inactive as soon as the scene loads
                                                    //   ^^ will probably need to be removed for another method when loading is implemented otherwise you couldnt load into combat.
                                                        //^^ isnt an issue for checkpoint based loading
	}
	
	// Update is called once per frame
	void Update () {
	//transform.position = Camera.transform.position ;	
        if ( playersct > playerct)
        {
            Debug.Log("timeMoving");
            Time.timeScale = 1.0f;
            playerct += playerspeed * Time.deltaTime;               // maybe this sucks. I should look into it :/ prolly wont tho
            for( int i = 0; i <enemies.Length; i++)                 // goes through each enemy and ticks up their timer. maybe speed should affect cast times and not the timers, so the action bar can be more accurate??:"[]
            {
                enemies[i].currenttime += enemies[i].speed * Time.deltaTime;
            }
            if(playerct > playersct)
            {
                Debug.Log("PlayerAbility cast!");            // **place holder** for whatever method will need to eb called to do the player ability may be
                enemies[1].health = enemies[1].health - PlayerScript.strength;      // place holder to remove the health from the second enemy for testing
                enemies[1].HealthbarUpdate();                   // this has to be called to update the healthbar to reflect the change in hp!
            }
            
            for(int i = 0; i < enemies.Length ; i ++)
            {
                if (enemies[i].currenttime >enemies[i].casttime)
                {
                    Debug.Log("ability casting?");
                    enemies[i].selectedAbility();        // selected ability is a delegate that is assigned a method when enemies[?].AbilityChoose is called
                    enemies[i].currenttime = 0;
                    enemies[i].AbilityChoose(); // I think these should be here. I really should have rewritten that psuedo code. this is to much for me to improvise :()

                    // ^^ Got no errors after writing all this new combat stuff up. Now I am fearful. I shudder at each warning symbol. surely delegates arent that easy.
                }
            }
            /*if(enemyct > enemysct)                          // << this means enemies cant cast unless the player fails to cast prolly not a big deal but still kinda dumb
            {
                Debug.Log("overworldEnemy Ability cast, OH NO");     // **place holder ** for the enemies ability animation/effects being played
                enemyct = 0.00f;
                enemysct =4.0f;                              // **place holder** for enemy ability putting in its cast time, 
            }           */          // << old code for when there was a single enemy. will now check all enemy and execute their chosen abilities!
        }
        else 
        {
            Time.timeScale = 0.0f;
        }
        ActionBar.value = ActionBar.value + (playerspeed* Time.deltaTime);
        if(ActionBar.value >= 20)
        {
            ActionBar.value = 0.0f;
        }
        if (enemies[1].health <= 0.0f )                       // this needs a revamp me thinks :/
        {
            EnemyDeath();
            Debug.Log(" the enemies current health was too low!!");

        }
        //else Debug.Log("timepaused");
	    
    }
    public void EnemyDeath()
    {
        GameManager.BattleSceneOff();
        oldovenemy.Death();
    }
    public void InitiateCombat(OverworldEnemy overworldEnemy)
    {
        //TimerActive = false;                              outdated timeractive boolean method for setting the time
        Debug.Log("combat Initiating");
        enemies = new BattleEnemy[overworldEnemy.enemies.Length];

        enemies = overworldEnemy.enemies;
        for (int i = 0; i < enemies.Length ; i++)
        {   
            Debug.Log(i);
            if( enemies[i] != null && spawnpoints[i] != null)
            {
                enemies[i] = Instantiate(overworldEnemy.enemies[i], spawnpoints[i].transform);  
                Debug.Log("Instantiating!" + i);
                enemies[i].AbilityChoose();
            }
        } 
        //enemysspeed = overworldEnemy.speed;
        playersct = 0.0f;
        playerct = 0.01f;
        // oldovenemy = overworldEnemy;
        
    }
    public void TestAbilityPlaceholder()
    {
        if( Time.timeScale == 0.0f)                                             // checks time is frozen so players cant spam the button like monkeys. ofc i<0 and i>0 will both return false when i=0 what is wrong with me
        {
            Debug.Log("PewPew Chosen");                                         // if time is moving then the ability cant be moved anymore
            playerct = 0.0f;
            playersct = 5.0f;
            float iconpos = ActionBar.value + (playersct + ((playerspeed * playersct) *Time.deltaTime));
            if(iconpos > 20)
            {
                iconpos = iconpos-20;
            }
            PlayerActionIcon.transform.position = new Vector3(ActionbarStart.x + iconpos, ActionbarStart.y, ActionbarStart.z);
        }
    }
    public void StrengthUp()
    {
        if (Time.timeScale > 0.0f)                       // if time is moving then the ability cant be activated anymore
        {
            Debug.Log("Strewth");
            playerct = 0.0f;
            playersct = 1.0f;
            float iconpos = ActionBar.value + playersct;
            if(iconpos > 20)
            {
                iconpos = iconpos-20;
            }
            PlayerActionIcon.transform.position = new Vector3(ActionbarStart.x + iconpos, ActionbarStart.y, ActionbarStart.z);
        }
    }

    // ** alot of psuedocode below is outdated and no longer the plan, Check psuedo code file for diagrams that are also outdated! Delegates and additional classes are the plan now
    //    and absurd amounts of greater/lesser than checks in the update loop. Im sorry for the strain this causes ones mind
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
     ^ I was gonna try to do a co-routine, but Ive never written one before and I realised it may not really be necessary, Unless we ??(some idea I thought of in the shower and have clearly forgotten)
    it may be possible to make the entire battle system a co routine, so instead of being this script that plays when ever the battle object is set to active 
    when the player bumps a enemy,
    it is instead this piece of code that is summoned to run alongside the update loot everytime the player touches an enemy and banished when the enemies die,
    there may be pros and cons to this system that I will think of later cause Im lazy :p    


    to do the action bar we could literally just have a square that moves up it at a rate based on the players speed and have the time variable thing set to 0 
    so it doesnt move, we could even have it set to a low value so the player must choose between rushing or planning their moves at the cost of time. 
    ^this is probably the best method as we could have cool backgorund effects that play in slow motion as the player picks their move. and it should be 
    fairly easy


    UI:
    player actions will probably be a list of buttons that way we can set all of their tint values at once and access them easily
    the buttons will simply call methods from the battleController (BattleScene script)

    The icons resembling enemy and player timers will lerp between two points on the action bar,  A = start of bar, B= end of bar T= equals position on bar
    every update T = T+(playerspeed * time.deltatime)

    Icons for player ability will be lerped as well at T
    ^this wont work as Lerp Works on a range of 0-1
    I want to simply move a box to the right but I dont know how to do that in UI ;-;
    Screw that jazz Im just gonna use a slider with a value of 0-40 and custom images







    */
}
