using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldEnemy : MonoBehaviour
{
    //public GameManager gameManager;
    // public EnemyStat battleStats; old implementation of the stats in a seperate class
    public float speed;
    public float health;
    public float attack;
    public float damage;
    public Action[] attack1;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {   
        Debug.Log("trigEntered");
        if(col.tag == "Player")
        {
            Debug.Log("PlayerEntered");
            GameManager.BattleSceneOn(this);
            
        }
    }


    /*public class EnemyStat                        old implementation of seperate stat class
    {
        public float speed;
        public float health;
        public float attack;
        public float damage;
    } */
}
