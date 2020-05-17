using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
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
}
