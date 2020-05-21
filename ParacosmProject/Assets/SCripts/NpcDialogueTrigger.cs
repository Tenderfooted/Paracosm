using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcDialogueTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject dialogue;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {   
        Debug.Log("trigEntered");
        if(col.tag == "Player")
        {
            Debug.Log("PlayerEntered");
            GameManager.instance.DialogueOpen(dialogue);
            
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            dialogue.SetActive(false);
        }
        
    }
}
