using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClass : MonoBehaviour
{
    public  GameObject player;
    public PlayerMovement playerscript;
    public Animator animator;
    public float speed;
    public int health = 1;
    public Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        HealthCheck();
    }
    void FixedUpdate()
    {
        Movement();
    }
    public virtual void Movement()      // this controls the characters Movement
    {

    }
    public virtual void HealthCheck() // this controls the health system for the Enemy
    {

    }
    public virtual void OnHit(Vector3 hitpos, int damage)
    {

    }
    public virtual void DealDamage()
    {
        
    }
  
}
