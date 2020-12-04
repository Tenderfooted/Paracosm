using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeTutorial : EnemyClass
{
    // Start is called before the first frame update
    private Vector3 orpos; // original position
    public float wobblemount;
    public bool HitWobblerunning;
    Rigidbody2D rbd;
    
    void Start()
    {
        orpos =transform.position;
        rbd = GetComponent<Rigidbody2D>();
    }
    public override void OnHit(Vector3 hitpos, int damage)
    {
        health = health - 1;
        Debug.Log("TreeHits");
        if(HitWobblerunning == false)
        {
            Debug.Log("wobbleTree");
            StartCoroutine(HitWobble());
            HitWobblerunning = true;
        } 

    }
    public override void HealthCheck()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
    IEnumerator HitWobble()
    {
        while(transform.position.x < (orpos.x + wobblemount) )
        {
            transform.position = new Vector3 (transform.position.x + 0.1f, transform.position.y, transform.position.z);
            yield return 0;
        }
        while(transform.position.x > (orpos.x - wobblemount) )
        {
            transform.position = new Vector3 (transform.position.x - 0.1f, transform.position.y, transform.position.z);
            yield return 0;
        }
        while(transform.position.x < (orpos.x + wobblemount / 2) )
        {
            transform.position = new Vector3 (transform.position.x + 0.1f, transform.position.y, transform.position.z);
            yield return 0;
        }
        while(transform.position.x > (orpos.x - wobblemount/2) )
        {
            transform.position = new Vector3 (transform.position.x - 0.1f, transform.position.y, transform.position.z);
            yield return 0;
        }
        while (transform.position.x < orpos.x)
        {
            transform.position = new Vector3 (transform.position.x + 0.1f, transform.position.y, transform.position.z);
            yield return 0;
        }
        transform.position = orpos;
        HitWobblerunning = false;
    } 
}
