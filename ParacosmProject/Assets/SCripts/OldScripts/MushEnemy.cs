using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MushEnemy : BattleEnemy 
{ 
            // Enemies now inherit certain variables and methods from the BattleEnemy Class!

    public override void AbilityChoose( )
    {
        selectedAbility = HeavyAttack;           // puts a method into the delegate Selected ability (+which is inherited) so that it can be executed from the battleScene later
        casttime = 4;                           // at the moment cast time has to be set when the ability is chosen. hopefully Ill think of a more elegant way to do this but it probably wont matter that much
        Debug.Log("ability chosen!");
        //return SelectedAbility;
    } 
    public  void HeavyAttack()
    {
        Debug.Log("HEVYATTACK");
        PlayerBattle.health -= 1f;

        //heavy attack
    }
    public  void SlowAttack()
    {
        // well then lmao
    }
}
