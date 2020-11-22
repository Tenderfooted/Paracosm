using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySylph : EnemyClass
{
    private bool hunting = false;
    public float huntrange;
    float freezetimer = 3f;
    bool isfrozen = false;

    public float scaleX;

    public float chargeWarmup;
    public float recuperateTime; 
    public float aggrorange;

    private bool isCharging = false;    // is used to make sure only one eemy charge coroutine is running at a time
    private bool isShrinking = false;   // is used to make sure only one enemy shrink on hit coroutine is happening.
    private float hittimer = 0.0f;
    public CutscenePlayer cutScene;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player"); 
        playerscript = player.GetComponent<PlayerMovement>();
        rb2d = GetComponent<Rigidbody2D>();
        scaleX = transform.localScale.x;        // is used to ensure that the creature shrinks according to its size properly in case it isnt at 1
    }

    // Update is called once per frame

    public override void HealthCheck()
    {
        if(health <= 0)
        {
            if(cutScene != null)
            {
                cutScene.flag = true; // this is just here for the cutscene
            }
            Destroy(gameObject);
        }
        Vector3 dmgCheck = player.transform.position - transform.position;
        if( hittimer > 0)
        {
            hittimer = hittimer - Time.deltaTime;
        }
    }
    public override void Movement()
    {
        float distance = Vector2.Distance( player.transform.position, transform.position);
        if( distance < aggrorange && isCharging == false)
        {
            StartCoroutine(Aggressive(distance));
            isCharging = true;
        }
        // get player pos, wait 5 seconds Dash to player Pos
        // wait 2 seconds
    }
    public override void OnHit( Vector3 hitpos, int damage)
    {
        health = health - damage;
        Vector3 dir = (transform.position - hitpos).normalized;
        //rb2d.AddForce( dir * (damage*30), ForceMode2D.Impulse); //removed damage bump as it causes issues
        if(isShrinking == false)
        {
            StartCoroutine(HitShrink());
            isShrinking = true;
        }
        // float away
    }
    IEnumerator Aggressive(float chargedistance)
    {
        Debug.Log("now Aggressive");
        // find player pos, wait a second. Charge player and play attack animation.
        Vector2 target = player.transform.position;

        yield return new WaitForSeconds(chargeWarmup);
        Debug.Log("warmedUP");
        Vector2 startPosition = transform.position;
        float chargestart = Time.time; // records the start of the charge so that the sylph can be interpolated between the its pos and the players
        float fractionOfJourney = 0f;
        yield return 0;
        //animator.SetBool("isCharge",true);
        //Quaternion rotation = Quaternion.LookRotation(target - startPosition, Vector3.up);
        //Quaternion oldrotation = transform.rotation;
        //transform.rotation = rotation;
        while(fractionOfJourney < 1f)
        {
            Debug.Log("charging");
            float distCovered = (Time.time - chargestart) * speed;
            fractionOfJourney = distCovered / chargedistance;

            rb2d.MovePosition(Vector3.Lerp(startPosition, target, fractionOfJourney));
            yield return new WaitForFixedUpdate();
        }
        isCharging = false;
        //transform.rotation = oldrotation;
        // damage player if it hits
        //stop for a second before ReAqcuiring players location
    }
    IEnumerator HitShrink()
    {
        while(transform.localScale.x > (0.5f * scaleX ))
        {
            transform.localScale = transform.localScale - new Vector3(0.05f,0,0);
            yield return 0;
        }
        while(transform.localScale.x < (1.0f* scaleX ))
        {
            transform.localScale = transform.localScale + new Vector3(0.05f,0,0);
            yield return 0;
        }
        isShrinking = false;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player") && hittimer <= 0.1f)
        {
            playerscript.health = playerscript.health - 1;
            hittimer = 2f;
        }
    }
}
