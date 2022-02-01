using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int MaxHealth;
    public int CurrentHealth;
    public int expToGive;

    private PlayerStats thePlayerStats;

    // Start is called before the first frame update
    void Start()
    {
        //At the beginning of the game, player has max health
        CurrentHealth = MaxHealth;

        thePlayerStats = FindObjectOfType<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        //If player health falls to 0, respawn
        if(CurrentHealth <= 0)
        {
            Destroy(gameObject);
            thePlayerStats.AddExperience(expToGive);
        }
    }

    public void HurtEnemy(int damageToGive)
    {
        CurrentHealth -= damageToGive;
    }

    public void SetMaxHealth()
    {
        CurrentHealth = MaxHealth;
    }
}
