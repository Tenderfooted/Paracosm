using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    bool isFloat = false;
    bool reachGround = false;       //this exists so we can test if the bool is hiting the ground
    public Transform raycastOrigin;
    public float raycastDistance = 0.05f;
    Rigidbody2D _rigidbody;  
    float _V = 0.0f;
    float _Jump = 0.0f;
    public float MoveSpeed = 12.0f;
    public float JumpStrength = 10f;
    float _Up = 0.0f;

    public float defaultGravScale;

    [Range(0.0f, 1.0f)]
    public float floatGrav;
    [Range(0, 5)]
    public int airDashCount;        // the amount of dashes a player has in midair
    int currentDash;                // the amount of dashes a player has remaining
    public float groundDrag;        // the drag while the character is on the ground, allows them to avoid slipping.
    public float airDrag;           // drag while character is in the air. makes the character very floaty

    public float dashStrength;

        // values for the Vault slerp here

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.drag = groundDrag;
        _rigidbody.gravityScale = defaultGravScale;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(_rigidbody.velocity);
        _V = Input.GetAxis("Horizontal");
        _Jump = Input.GetAxis("Jump");
        _Up = Input.GetAxis("Vertical");
        gameObject.transform.position = new Vector3(transform.position.x + ((_V *MoveSpeed) * Time.deltaTime), transform.position.y, transform.position.z); // the current code that controls movement
        RaycastHit2D hit;
        hit = Physics2D.Raycast(raycastOrigin.position, -transform.up, raycastDistance);
        animator.SetFloat("Speed", _V * MoveSpeed);
        if (hit != null && hit.collider != null && reachGround == true)
        {
            //Debug.Log("GROUNDHIT");
            isFloat = false;
            animator.SetBool("IsJump", false);
            _rigidbody.gravityScale = defaultGravScale;
            animator.SetBool("IsDash", false);
            
        }
        if (hit != null && hit.collider != null && Input.GetKeyDown("space"))    //checks that the player is on the ground, holding space and that they arent already vaulting
        {
           //_rigidbody.AddForce(transform.right *(_V * MoveSpeed)) ;              //velocity based ground movement
           _rigidbody.AddForce(transform.up * (_Jump * JumpStrength), ForceMode2D.Impulse); 
            isFloat = true;
            reachGround = false;         
            currentDash = airDashCount;
            animator.SetBool("IsJump", true);

        }  
        if (hit != null && hit.collider == null)
        {
            reachGround = true;    // set to true so that the next animation can be called when the player hits the ground
        }
        if (isFloat == true && _rigidbody.velocity.y < 0.1f )               // this makes the character float at the apex of their jump
        {
            //Debug.Log("FLOATARGHHHHHHHHHHHHHHHHHHHH");
            _rigidbody.gravityScale = floatGrav;
            _rigidbody.drag = airDrag;
            if ( Input.GetKeyDown("space") && currentDash > 0)
            {
                _rigidbody.AddForce(new Vector2(_V, _Up) * dashStrength, ForceMode2D.Impulse);
                currentDash--; 
                if( currentDash <= 0)
                {
                    isFloat = false; 
                    animator.SetBool("IsDash", true);
                    _rigidbody.gravityScale = defaultGravScale;
                }
            }
        }
       
    }
    void FixedUpdate()
    {
        RaycastHit2D hit;
        hit = Physics2D.Raycast(raycastOrigin.position, -transform.up, raycastDistance);
        if(hit != null && hit.collider != null)
        {
            _rigidbody.drag = groundDrag;
        }
        else
        {
            _rigidbody.drag = airDrag;
        }
    }
}
