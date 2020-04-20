using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        BattleScene.instance.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public static void BattleSceneOn(OverworldEnemy currentEnemy)
    {
        MainScene.instance.gameObject.SetActive(false);
        BattleScene.instance.gameObject.SetActive(true);
        BattleScene.instance.transform.position = CameraScript.instance.transform.position;        //moves the camera to the battlescene position.
        BattleScene.instance.InitiateCombat(currentEnemy);
    }
    public static void BattleSceneOff()
    {
        MainScene.instance.gameObject.SetActive(true);
        BattleScene.instance.gameObject.SetActive(false);
    }
}
