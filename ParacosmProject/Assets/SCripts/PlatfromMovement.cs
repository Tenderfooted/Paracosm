using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfromMovement : MonoBehaviour
{
    private Vector3 startPos;
    public Vector3 endPos;
    public Transform endingPosTransform;    //is here so its eeasier to choose the end in the editor
    public bool traveltoend = true;
    public bool movestarting = true;
    public float chargestart;
    public float speed = 3;
    private float distance;
    private float fractionOfJourney;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        endPos = endingPosTransform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        // here will be a 
    }
    void FixedUpdate()
    {
        //here will be a 2 lerp scripts for moving between the two positions;
        // it will use a boolean for determining what stretch of the journey it is on
        if(traveltoend == true)
        {
            // the platform moves to end here
            
            
            if(movestarting == true)
            {
                distance = Vector2.Distance( transform.position, endPos);
                chargestart = Time.time; // records the start of the charge so that the platform can be interpolated between the its pos and the players
                fractionOfJourney = 0f;
                movestarting = false;
                //Debug.Log("charging");
            }
            //animator.SetBool("isCharge",true);
            //Quaternion rotation = Quaternion.LookRotation(target - startPosition, Vector3.up);
            //Quaternion oldrotation = transform.rotation;
            //transform.rotation = rotation;
            

            float distCovered = (Time.time - chargestart) * speed;
            fractionOfJourney = distCovered / distance;
            transform.position = Vector3.Lerp(startPos, endPos, fractionOfJourney);
            if(fractionOfJourney > 0.98f)
            {
                traveltoend= false;
                movestarting =true;
                Debug.Log("finishedMove");
        }
            }
        else
        {
            if(movestarting == true)
            {
                distance = Vector2.Distance( transform.position, startPos);
                chargestart = Time.time; // records the start of the charge so that the platform can be interpolated between the its pos and the players
                fractionOfJourney = 0f;
                movestarting = false;
            }
            float distCovered = (Time.time - chargestart) * speed;
            fractionOfJourney = distCovered / distance;
            transform.position = Vector3.Lerp(endPos, startPos, fractionOfJourney);
            if(fractionOfJourney > .98f)
            {
                traveltoend= true;
                movestarting =true;
                Debug.Log("finishedMove");
            }
        }
    }
}
