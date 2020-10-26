using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxCode : MonoBehaviour
{
    public EnemyGhost holder;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            holder.DealDamage();
        }
    }
}
