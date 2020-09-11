using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldStaffSpin : MonoBehaviour
{
    /*public bool isVault = false;
    public Transform raycastOrigin;
    public float raycastDistance = 0.05f;
    Rigidbody2D _rigidbody;  
    float _V = 0.0f;
    float _Jump = 0.0f;
    public float MoveSpeed = 12.0f;
    public float JumpStrength = 10f;

        // values for the Vault slerp here
    Vector3 vaultStart;
    Vector3 vaultEnd;
    Vector3 relStart;
    Vector3 relEnd;
    public float vaultspeed = 1.0f;
    Vector3 centerPoint;
    public float vaultTime;
    public float vaultDistance;
    Vector2 oldPos;          //used for calculating direction during vaults for dashes
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _V = Input.GetAxis("Horizontal");
        _Jump = Input.GetAxis("Jump");
        gameObject.transform.position = new Vector3(transform.position.x + ((_V *MoveSpeed) * Time.deltaTime), transform.position.y, transform.position.z); 
        RaycastHit2D hit;
        hit = Physics2D.Raycast(raycastOrigin.position, -transform.up, raycastDistance);
        if (hit != null && hit.collider != null && Input.GetKeyDown("space") && isVault == false)    //checks that the player is on the ground, holding space and that they arent already vaulting
        {
            Debug.Log("Begin the vault!");
            isVault = true;
            vaultTime = Time.time;
            vaultStart = transform.position;
            vaultEnd = new Vector3 (transform.position.x + vaultDistance * _V,transform.position.y,transform.position.z);
            centerPoint = (vaultStart + vaultEnd) *.5f;
            centerPoint -= Vector3.up;
            relStart= vaultStart - centerPoint;
            relEnd = vaultEnd - centerPoint;
            _rigidbody.gravityScale = 0.0f;
        }  
       
    }
    void FixedUpdate()
    {
        if ( isVault == true && _Jump <= .5f)
        {                           // needs to be changed so that the hop off the vault will push the character upwards
            Vector2 newPos = transform.position;
            Vector2 direction = newPos - oldPos;
            isVault = false;
            _rigidbody.gravityScale = 1.0f;                     
            Debug.Log(direction);
            _rigidbody.AddForce(direction * 50,  ForceMode2D.Impulse);

        }
        if(isVault == true) 
        {
            Debug.Log("IsVaulting");

            float fracComplete = (Time.time - vaultTime) / 1.0f * vaultspeed;
            transform.position = Vector3.Slerp(relStart, relEnd, fracComplete * vaultspeed);
           _rigidbody.MovePosition(nextPos * Time.fixedDeltaTime);  //rb2D.MovePosition(rb2D.position + velocity * Time.fixedDeltaTime);
            transform.position += centerPoint;
            oldPos = transform.position;
            if (fracComplete >= 1)
            {
                Debug.Log("Vault Finished");
                _rigidbody.gravityScale = 3.0f;
                isVault = false;
            }
        }
    }*/
}
