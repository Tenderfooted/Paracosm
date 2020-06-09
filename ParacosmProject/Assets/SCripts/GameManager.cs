using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private float timeprevious;
    public bool ispaused;
    GameObject helddialogue;    // an easy way to turn off the dialogue with esc, by passing the dialogue from the npc to this variable we can turn it off later! :3
    public hotkeys buttonpressed;           // this uses the hotkeys enum in PlayerBattle cs. It exists here so the buttons in the battle screeen can activate player abilities
    public SaveData savedata;
    public bool Isload = false;
    
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
    public static void BattleSceneOn(OverworldEnemy currentEnemy, PlayerScript overworldPlayer)
    {
        MainScene.instance.gameObject.SetActive(false);                                            // turns mainscene object and all its children inactive
        BattleScene.instance.gameObject.SetActive(true);                                           // turns the Battlescebe abd all its children active
        BattleScene.instance.transform.position = CameraScript.instance.transform.position;        //moves the battle scene to the camera position
        BattleScene.instance.InitiateCombat(currentEnemy, overworldPlayer);                                         // passes the battlescene the enemy the player just encountered.
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
    public void buttonpressq()                                      // these are hopefully just place holders until a better hotkey system is made !!
    {
        PlayerBattle.abilityselected = hotkeys.q;

    }
        public void buttonpressw()
    {
        PlayerBattle.abilityselected = hotkeys.w;
        
    }
        public void buttonpresse()
    {
        PlayerBattle.abilityselected = hotkeys.e;

    }
        public void buttonpressr()
    {
        PlayerBattle.abilityselected = hotkeys.r;
        
    }
    public void ExitGame()
    {
        Application.Quit();
    }   

    // Set up and plan code for save function here
    // load method that reads a json file for two numbers, first the build of the level to load, and secondly the number of the checkpoint to spawn the player at :/

    // save function
    // writes the checkpoint number and player number to a Json file

    // the gamemanager will need to be able to find the checkpoint of the save spot.    alternate method. write the players X,Y,Z coordinates to json and the level, then we dont have to bother with the checkpoint system
    // can add the players stats to this later
    public void LoadGame()
    {
        Debug.Log("loading");
        string json;
        json = File.ReadAllText(Application.dataPath+"/saves/savedata.json");
        savedata = JsonUtility.FromJson<SaveData>(json);
        Debug.Log(savedata.playerloc);
        Debug.Log(savedata.buildnum);
        SceneManager.LoadScene(savedata.buildnum);
        Isload = true;
    }
    public void SaveGame()
    {
        Debug.Log("Saving");
        Scene scene = SceneManager.GetActiveScene();
        savedata = new SaveData();
        savedata.buildnum = scene.buildIndex;
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            Debug.Log("PLAYER FOUND LMO");
        }
        savedata.playerloc = player.transform.position;
        string json = JsonUtility.ToJson(savedata);
        File.WriteAllText(Application.dataPath+"/saves/savedata.json",json);

    }
    public void PlayerPush()
    {
        GameObject player = GameObject.FindWithTag("Player");
        player.transform.position = savedata.playerloc;
        Destroy(player);
        Instantiate(player, savedata.playerloc, Quaternion.identity);
    }

}
public class SaveData
{
    public int buildnum = 0;
    public Vector3 playerloc;

}
