using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillMenu : MonoBehaviour
{
    public static SkillMenu instance;
    // Start is called before the first frame update\
    void Awake()						
    {
        if (instance != null)
        {
            Destroy (gameObject);
        }
        else
        {
            instance = this;
			Debug.Log("SkillMenu instance set");
        }
        gameObject.SetActive(false);
	}
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
