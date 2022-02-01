using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider healthBar;
    public Text HPText;
    public PlayerHealthManager playerHealth;
    public Text levelText;
    
    private static bool UIExists;
    private PlayerStats thePS;

    // Start is called before the first frame update
    void Start()
    {
        if(!UIExists)
        {
            UIExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        thePS = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {   
        //Update health
        healthBar.maxValue = playerHealth.playerMaxHealth;
        healthBar.value = playerHealth.playerCurrentHealth;
        HPText.text = "HP: " + playerHealth.playerCurrentHealth + "/" + playerHealth.playerMaxHealth;

        //Update level
        levelText.text = "Lvl: " + thePS.currentLevel;
    }
}
