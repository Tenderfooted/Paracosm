using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiaMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (GameManager.instance.ispaused == false)
            {
                GameManager.instance.Pause();
            }
            else
            {
                GameManager.instance.Resume();
            }
        }
        if (Input.GetKeyDown("k"))
        {
            if (GameManager.instance.ispaused == false)
            {
                GameManager.instance.SkillMenuOpen();
            }
            else
            {
                GameManager.instance.Resume();
            }
        }
    }
}
