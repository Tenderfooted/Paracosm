using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
    public Transform attackPointRight;
    public Transform attackPointLeft;
    public float attackRange;
    public LayerMask enemyLayers;
    public int damage;
 
    public Animator animator;
    public SpriteRenderer _spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Attack();
        } 
        if(_spriteRenderer.flipX == true)
        {
            attackPoint = attackPointLeft;
        }
        else
        {
            attackPoint = attackPointRight;
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attacking");

        Debug.Log("AttackMade");

        /* Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<HitboxCode>().holder.OnHit(this.transform.position, damage);
        }
        */
    }
    
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        return;

        Gizmos.DrawWireSphere(attackPointLeft.position, attackRange);
        Gizmos.DrawWireSphere(attackPointRight.position, attackRange);
    }
    public void Attacking()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<HitboxCode>().holder.OnHit(this.transform.position, damage);
        }
    }
}
