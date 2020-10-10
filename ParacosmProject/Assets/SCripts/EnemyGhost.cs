using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGhost : MonoBehaviour
{
    private bool hunting = false;
    GameObject player;
    PlayerMovement playerscript;
    Animator animator;
    public float speed;
    public float huntrange;
    float freezetimer = 3f;
    bool isfrozen = false;

    public int health = 1;
    // Start is called before the first frame update
    // this is the simple version that simply moves towards the player 
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player"); 
        playerscript = player.GetComponent<PlayerMovement>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
        if(isfrozen == true)
        {
            freezetimer = freezetimer - Time.deltaTime;
            if(freezetimer <= 0f)
            {
                isfrozen = false;
                animator.SetBool("hunting", true);
                freezetimer = 3f;
            }
        }
        if(hunting == true && isfrozen == false)
        {
            
            Vector3 move = player.transform.position - transform.position ;
            transform.Translate(move.normalized* speed * Time.deltaTime, Space.World);
           /* if(move.magnitude > huntrange)
            {
                hunting = false;
                animator.SetBool("hunting", false);
            } */
            if ( move.magnitude < 0.5f)
            {
                playerscript.health = playerscript.health - 1;
                isfrozen = true;
                animator.SetBool("hunting", false);
           }
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            hunting = true;
            animator.SetBool("hunting", true);
            Debug.Log("hunting");
        }
    }

    public void DamageTaken(int damage)
    {
        health = health - damage;
    }
}
