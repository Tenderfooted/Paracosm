using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleEnemy : MonoBehaviour
{
     public float health ;
    public float speed ;
    // string[] abilities= {"HeavyAttack", "SlowAttack"};              //replacing the scripts names with delegates because they are WAAAAYY coolers
    public delegate void SelectedAbility();
    //public selectedAbility = New SelectedAbility selectedAbility;
    public SelectedAbility selectedAbility;
    public float casttime;                                  // the cast time for the ability
    public float currenttime;                               // the current time the enemy has accrued to its next cast
    public Slider Healthbar;

    public void Start()
    {
        Healthbar.maxValue = health;
        Healthbar.value = health;
    }
    public void HealthbarUpdate()
    {
        Healthbar.value = health;
    }
    public virtual void AbilityChoose()
    {
        Debug.Log(" oh noooooo!");
    }


}
