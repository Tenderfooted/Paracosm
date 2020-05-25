using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum hotkeys {none,q,w,e,r};
public class PlayerBattle : MonoBehaviour
{
    public static float health = 10;                        //this is a static for testing so enemy damage can be implemented    // will probably make the player battle class inherit from the BattleEnemy class later so enemies can target whatevs instead of just the player.
    public float speed;
    // string[] abilities= {"HeavyAttack", "SlowAttack"};              //replacing the scripts names with delegates because they are WAAAAYY coolers
    public delegate void SelectedAbility(BattleEnemy x);
    //public selectedAbility = New SelectedAbility selectedAbility;
    public SelectedAbility selectedAbility;
    public float casttime;                                  // the cast time for the ability
    public float currenttime;                               // the current time the enemy has accrued to its next cast
    public Slider Healthbar;
    public static hotkeys abilityselected;
    public void Start()
    {
    

    }
    public void Update()
    {
        if(Time.timeScale == 0.0f)                   // checks if time is paused before letting the player use an ability. could be better
        {
            if(Input.GetKeyDown("q"))
            {
                abilityselected = hotkeys.q;
                Debug.Log("hotkey pressed");
            }
            if (Input.GetKeyDown("w") && Input.GetKeyDown("q") == false)
            {
                abilityselected = hotkeys.w;
            }
            switch (abilityselected)
            {
                case hotkeys.q:
                    Debug.Log("q weeer");
                    break;
                case hotkeys.w:
                    Debug.Log("w");
                    break;
                case hotkeys.e:
                    Debug.Log("e");
                    break;
                case hotkeys.r:
                    Debug.Log("r");
                    break; 
            }
        }
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
    public void NormalAttack(BattleEnemy Target)
    {
        Target.health -= 2;                                 // removes the health of the target
        Target.HealthbarUpdate();                              //atm this needs to be called to refresh the targets healthbar
        Debug.Log("Normal Attack Cast");
    }
    public void SpeedUP(BattleEnemy Target)
    {
        PlayerBattle.health += 2f;
        HealthbarUpdate();
    }
    public void Ability3(BattleEnemy Target)
    {

    }
    public void Ability4(BattleEnemy Target)
    {

    }
    public void AbilityClear()
    {
        selectedAbility = null;
        Debug.Log("Ability Cleared");
        abilityselected = hotkeys.none;


    }
    public void AbilityChoose()
    {
        switch(abilityselected)
        {
                case hotkeys.q:
                    selectedAbility = NormalAttack;
                    casttime = 3.0f;
                    break;
                case hotkeys.w:
                    selectedAbility = SpeedUP;
                    casttime = 1.0f;
                    break;
                case hotkeys.e:
                    selectedAbility = Ability3;
                    break;
                case hotkeys.r:
                    selectedAbility = Ability4;
                    break; 
        }
    }

}

