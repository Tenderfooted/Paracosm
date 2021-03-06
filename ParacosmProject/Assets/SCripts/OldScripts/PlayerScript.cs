﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public enum Movetype{
        rcaddforce,
        movepos
    } 
    public Movetype CurrentMovetype;
    Rigidbody2D _rigidbody; 
    float _Jump = 0.0f;
    float _V = 0.0f;
    public float MoveSpeed = 12.0f;

    public Transform raycastOrigin;
    public float raycastDistance = 0.05f;
    public float JumpForce;
    //public LayerMask raycastMask;
    public static int health = 3;
    public static int mana = 5;
    public static int strength = 2;
    public PlayerBattle battleCharacter;
    // Start is called before the first frame update


    // pole script changes begin here.

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        if(GameManager.instance.Isload == true)
        {
            transform.position = GameManager.instance.savedata.playerloc;
            GameManager.instance.Isload = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        _V = Input.GetAxis("Horizontal");
        _Jump = Input.GetAxis("Jump"); 
        gameObject.transform.position = new Vector3(transform.position.x + ((_V *MoveSpeed) * Time.deltaTime), transform.position.y, transform.position.z); 
        RaycastHit2D hit;
        hit = Physics2D.Raycast(raycastOrigin.position, -transform.up, raycastDistance);
        if (hit != null && hit.collider != null)                                                    //if they are
        {
            //Debug.Log("FloorTouched");
            //_rigidbody.velocity += new Vector2(_V,_rigidbody.velocity.y) * MoveSpeed * Time.deltaTime ;  //allow them to move
            _rigidbody.AddForce(transform.right *(_V * MoveSpeed)) ;              //velocity based ground movement
            _rigidbody.AddForce(transform.up * (_Jump * JumpForce), ForceMode2D.Impulse);  									//allow them to jump
        }         
    }




    /*switch (CurrentMovetype)
        {
            case Movetype.rcaddforce:
                RaycastHit2D hit;
                hit = Physics2D.Raycast(raycastOrigin.position, -transform.up, raycastDistance);            //draws a raycast from the transform at the bottom of the player to see if they are touching ground

                Vector3 RayVisPos = transform.TransformDirection(-Vector3.up);
                Debug.DrawRay(raycastOrigin.position, RayVisPos, Color.green );

                if (hit != null && hit.collider != null)                                                    //if they are
                {
                    //Debug.Log("FloorTouched");
                    //_rigidbody.velocity += new Vector2(_V,_rigidbody.velocity.y) * MoveSpeed * Time.deltaTime ;  //allow them to move
                    _rigidbody.AddForce(transform.right *(_V * MoveSpeed)) ;              //velocity based ground movement
                    _rigidbody.AddForce(transform.up * (_Jump * JumpForce), ForceMode2D.Impulse);  									//allow them to jump
                }
                else
                {
                _rigidbody.AddForce(transform.right *(_V * (MoveSpeed* .75f)));
                }
                break;
            /*case Movetype.movepos:

                RaycastHit2D hit2;
                hit2 = Physics2D.Raycast(raycastOrigin.position, -transform.up, raycastDistance);            //draws a raycast from the transform at the bottom of the player to see if they are touching ground

                Vector3 RayVisPos2 = transform.TransformDirection(-Vector3.up);
                Debug.DrawRay(raycastOrigin.position, RayVisPos2, Color.green );
                Vector3 movement = new Vector3(_V, 0f,0f);
                transform.position += movement * Time.deltaTime * (MoveSpeed *.25f) ;

                if (hit2 != null && hit2.collider != null)                                                    //if they are
                {
                    _rigidbody.AddForce(transform.up * (_Jump * (JumpForce * 1.25f)), ForceMode2D.Impulse);								//allow them to jump
                }
                break;
            
        } */
}
