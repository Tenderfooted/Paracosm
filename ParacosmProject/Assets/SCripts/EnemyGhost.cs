using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGhost : EnemyClass
{
    private bool hunting = false;
    public float huntrange;
    float freezetimer = 3f;
    bool isfrozen = false;
    bool isShrinking = false;

    // Start is called before the first frame update
    // this is the simple version that simply moves towards the player 

       void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player"); 
        playerscript = player.GetComponent<PlayerMovement>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    /* void Update()
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
            /* if ( move.magnitude < 0.5f)
            {
                playerscript.health = playerscript.health - 1;
                isfrozen = true;
                animator.SetBool("hunting", false);
           } 
        } 
    } */
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
    public void DealDamage()
    {
        playerscript.health = playerscript.health - 1;
        isfrozen = true;
        animator.SetBool("hunting", false);
    }
    public override void HealthCheck()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public override void Movement()
    {
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
    public override void OnHit(Vector3 hitpos, int damage)
    {
        health = health - damage;
        Vector3 dir = (transform.position - hitpos).normalized;
        rb2d.AddForce( dir * (damage*30), ForceMode2D.Impulse);
        if(isShrinking == false)
        {
            StartCoroutine(HitShrink());
            isShrinking = true;
        }
    }
    IEnumerator HitShrink()
    {
        while(transform.localScale.x >0.5f)
        {
            transform.localScale = transform.localScale - new Vector3(0.01f,0,0);
            yield return 0;
        }
        while(transform.localScale.x <1.0f)
        {
            transform.localScale = transform.localScale + new Vector3(0.01f,0,0);
            yield return 0;
        }
        isShrinking = false;
    }
}
