using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int currentLevel;
    public int currentExp;
    public int[] toLevelUp; //Array of integers to signify exp to reach the next level

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //If exp meets level threshhold, level up
        if(currentExp >= toLevelUp[currentLevel]){
            currentLevel++;
        }
    }

    public void AddExperience(int experienceToAdd)
    {
        currentExp += experienceToAdd;
    }
}
