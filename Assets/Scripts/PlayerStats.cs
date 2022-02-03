using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int currentLevel;
    public int currentExp;
    public int currentHP;
    public int currentAttack;
    public int currentDefense;

    public int[] toLevelUp; //Array of integers to signify exp to reach the next level
    public int[] HPLevels;
    public int[] attackLevels;
    public int[] defenseLevels;

    private PlayerHealthManager thePlayerHealth;


    // Start is called before the first frame update
    void Start()
    {
        currentHP = HPLevels[1];
        currentAttack = attackLevels[1];
        currentDefense = defenseLevels[1];

        thePlayerHealth = FindObjectOfType<PlayerHealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //If exp meets level threshhold, level up
        if(currentExp >= toLevelUp[currentLevel]){
            //currentLevel++;
            LevelUp();
        }
    }

    public void AddExperience(int experienceToAdd)
    {
        currentExp += experienceToAdd;
    }

    public void LevelUp()
    {
        currentLevel++;

        currentHP = HPLevels[currentLevel];
        thePlayerHealth.playerMaxHealth = currentHP;
        thePlayerHealth.playerCurrentHealth += currentHP - HPLevels[currentLevel-1];
        
        currentAttack = attackLevels[currentLevel];

        currentDefense = defenseLevels[currentLevel];
    }
}
