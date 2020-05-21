using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private float timeprevious;
    public bool ispaused;
    GameObject helddialogue;    // an easy way to turn off the dialogue with esc, by passing the dialogue from the npc to this variable we can turn it off later! :3
    
    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null)
        {
            Destroy (gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        if( BattleScene.instance != null)          //checks if battlescene exists before night nighting it
        {
            BattleScene.instance.gameObject.SetActive(false);                       // this flips the battlescene off, will probably need to be used as well when loading
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public static void BattleSceneOn(OverworldEnemy currentEnemy)
    {
        MainScene.instance.gameObject.SetActive(false);                                            // turns mainscene object and all its children inactive
        BattleScene.instance.gameObject.SetActive(true);                                           // turns the Battlescebe abd all its children active
        BattleScene.instance.transform.position = CameraScript.instance.transform.position;        //moves the camera to the battlescene position.
        BattleScene.instance.InitiateCombat(currentEnemy);                                         // passes the battlescene the enemy the player just encountered.
    }
    public static void BattleSceneOff()
    {
        MainScene.instance.gameObject.SetActive(true);
        BattleScene.instance.gameObject.SetActive(false);   // turns off the combat                                                   
         // will need to record the current enemy fighting so we can execute them after
    }
    public void LaunchGame() 
    {
        Debug.Log("Loading Scene!!!!!!!!!!!!!! <D:");
        SceneManager.LoadScene(1);                  // this will probably be shunted to a Load/save manager later when that exists :p
        BattleScene.instance.gameObject.SetActive(false);       // wtf I dont need to tell it where to find the battleScene? I dont remember making it static..
    }
      public void Pause()
    {
        // this will open the pause menu and pause the game
        // first record current delta time, this is so it cant be used to bug combat speed
        //then set delta time to 0
        //when esc has been selected then the set delta time to its previous value
        timeprevious = Time.timeScale;
        Time.timeScale = 0.0f;
        PauseMenu.instance.gameObject.SetActive(true);
        ispaused = true;
        
    }
    public void Resume()
    {
        Time.timeScale = timeprevious;
        PauseMenu.instance.gameObject.SetActive(false);
         SkillMenu.instance.gameObject.SetActive(false);
        if(helddialogue != null)
        {
            helddialogue.SetActive(false);              // if there is dialogue held then it is turned off when the player wants to resume.
        }
        ispaused = false;
    }
    public void SkillMenuOpen()
    {
        timeprevious = Time.timeScale;
        Time.timeScale = 0.0f;
        SkillMenu.instance.gameObject.SetActive(true);
        ispaused = true;
    }
    public void DialogueOpen(GameObject dialogue)               // recieves the dialogue gameobject from the npctriggerscript, enables it and pauses time
    {

        timeprevious = Time.timeScale;
        //Time.timeScale = 0.0f;                    // un comment this to make dialogue pause the game!
        dialogue.SetActive(true);
        ispaused = true;
    }


}
