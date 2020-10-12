using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer _spriteRenderer;
    bool isFloat = false;
    bool reachGround = false;       //this exists so we can test if the bool is hiting the ground

    public Transform raycastOrigin;
    public int layerMask = 1 << 8;
    public float raycastDistance = 0.05f;
    Rigidbody2D _rigidbody;

    float _V = 0.0f;
    float _Jump = 0.0f;
    public float MoveSpeed = 12.0f;
    public float JumpStrength = 10f;
    float _Up = 0.0f;

    public int health;
    public int maxhealth;

    public Image[] healthsprites;
    public Sprite healthfull;
    public Sprite healthempty;


    public float defaultGravScale;

    [Range(0.0f, 1.0f)]
    public float floatGrav;
    [Range(0, 5)]
    public int airDashCount;        // the amount of dashes a player has in midair
    int currentDash;                // the amount of dashes a player has remaining
    public float groundDrag;        // the drag while the character is on the ground, allows them to avoid slipping.
    public float airDrag;           // drag while character is in the air. makes the character very floaty

    public float dashStrength;

    private bool pdCoRunning = false; //this is so that only one dying coroutine runs at a time.

        // values for the Vault slerp here

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody.drag = groundDrag;
        _rigidbody.gravityScale = defaultGravScale;
        for( int i = 0; i < healthsprites.Length; i++)
            {
                if( i < maxhealth)
                {
                    healthsprites[i].enabled = true;
                }
                else
                {
                    healthsprites[i].enabled = false;
                }
            };
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(_rigidbody.velocity);

        // stuff for hp 
        Debug.Log(animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
    

        for (int i = 0; i < healthsprites.Length; i++)              // this updates the players heart count
        {
            if (i < health)
            {
                healthsprites[i].sprite = healthfull;
            }
            else
            {
                healthsprites[i].sprite = healthempty;
            }
        }
        if( health <= 0 && pdCoRunning == false)
        {
            StartCoroutine(PlayerDeath());
        }
        _V = Input.GetAxis("Horizontal");
        _Jump = Input.GetAxis("Jump");
        _Up = Input.GetAxis("Vertical");

        if(_V < 0.0f)
        {
            _spriteRenderer.flipX = true;
        }
        else
        {
            _spriteRenderer.flipX = false;
        }



        gameObject.transform.position = new Vector3(transform.position.x + ((_V *MoveSpeed) * Time.deltaTime), transform.position.y, transform.position.z); // the current code that controls movement
        RaycastHit2D hit;
        hit = Physics2D.Raycast(raycastOrigin.position, -transform.up, raycastDistance);
        Debug.DrawRay(raycastOrigin.position, -transform.up);
        animator.SetFloat("Speed", _V); // sends the players V input to the animator for the run animation. used to include the movespeed variable

        if (hit != null && hit.collider != null)
        {
            //Debug.Log("GROUNDHIT");
            isFloat = false;
            animator.SetBool("IsJump", false);
            _rigidbody.gravityScale = defaultGravScale;
            animator.SetBool("IsDash", false);
            
        }
        else if (isFloat == false)
        {
            isFloat = true;
            animator.SetBool("IsJump", true);
        }
        if ( isFloat == true && Input.GetKeyDown("space") && currentDash > 0)   // this allows the player to jump, used to be with the code that makes players float but meant players could only dash at the apex of their jump
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
        if (hit != null && hit.collider != null && Input.GetKeyDown("space"))    //checks that the player is on the ground, holding space and that they arent already vaulting
        {
           //_rigidbody.AddForce(transform.right *(_V * MoveSpeed)) ;              //velocity based ground movement
           _rigidbody.AddForce(transform.up * (_Jump * JumpStrength), ForceMode2D.Impulse); 
            isFloat = true;
            reachGround = false;         
            currentDash = airDashCount;
            animator.SetBool("IsJump", true);

        }  
        if (isFloat == true && _rigidbody.velocity.y < 0.1f )               // this makes the character float at the apex of their jump
        {
            //Debug.Log("FLOATARGHHHHHHHHHHHHHHHHHHHH");
            _rigidbody.gravityScale = floatGrav;
            _rigidbody.drag = airDrag;
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
    IEnumerator PlayerDeath()
    {
        pdCoRunning = true;
        animator.SetTrigger("Dying");
        yield return 0;
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length+animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
        
        health = 3;
        GameManager.instance.LoadCheckpoint();
        pdCoRunning = false;
        yield break;
    }
    
    void Death()
    {
        
        health = 3;
        GameManager.instance.LoadCheckpoint();
    }
}
