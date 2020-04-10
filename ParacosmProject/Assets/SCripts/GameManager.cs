using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject MainScene;
    public GameObject BattleScene;
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
        MainScene = GameObject.FindGameObjectWithTag("MainScene");
        BattleScene= GameObject.FindGameObjectWithTag("BattleScene");
        BattleScene.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void BattleSceneOn()
    {
        MainScene.SetActive(false);
        BattleScene.SetActive(true);
    }
}
