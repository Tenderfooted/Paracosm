using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushEnemy  : MonoBehaviour
{
    string name = "Mush Monster";               // so we can display the name in combat
    float health = 5;
    float speed= 5;
    string[] abilities= {HeavyAttack, SlowAttack};              //this is where names of ability methods are kept so they may be sent to the battelscene later
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
