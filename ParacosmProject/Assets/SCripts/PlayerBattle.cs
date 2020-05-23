using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerBattle : MonoBehaviour
{
    public float health;                            // will probably make the player battle class inherit from the BattleEnemy class later so enemies can target whatevs instead of just the player.
    public float speed;
    // string[] abilities= {"HeavyAttack", "SlowAttack"};              //replacing the scripts names with delegates because they are WAAAAYY coolers
    public delegate void SelectedAbility();
    //public selectedAbility = New SelectedAbility selectedAbility;
    public SelectedAbility selectedAbility;
    public float casttime;                                  // the cast time for the ability
    public float currenttime;                               // the current time the enemy has accrued to its next cast
    public Slider Healthbar;

    public void Start()
    {
    

    }

    // Update is called once per frame
    public void BattleInitiate()
    {
        Healthbar = GameObject.FindWithTag("PlayerHealthBar").GetComponent(typeof(Slider)) as Slider;       // searches for the slider component on the game object of the tag so the players health will work
        if (Healthbar != null )                                                                             // this is here to check that the find worked
        {
            Debug.Log("the players healthbar has been found! Congratulations friends!");
        }
        Healthbar.maxValue = health;
        Healthbar.value = health;

    }
    public void HealthbarUpdate()
    {
        Healthbar.value = health;
    }

}
