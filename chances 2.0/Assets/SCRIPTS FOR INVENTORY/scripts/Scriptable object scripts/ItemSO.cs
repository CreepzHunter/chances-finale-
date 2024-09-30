using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public statToChange statTC = statToChange.none; // Default value
    public int amountTochangeStat;

        public bool UseItem(PlayerHealth playerHealth) 
    {
        if (statTC == statToChange.health)
        {
            Debug.Log("Attempting to heal...");

            // Check if the player's health is already at max
            if (playerHealth != null)
            {
                if (playerHealth.currentHealth < playerHealth.maxHealth)
                {
                    playerHealth.Heal(amountTochangeStat);
                    return true; // Successful healing
                }
                else
                {
                    Debug.Log("Player health is already at maximum.");
                    return false; // Healing not performed
                }
            }
            else
            {
                Debug.LogError("PlayerHealth reference is null!");
                return false; // Unable to perform healing
            }
        }
        
        else if (statTC == statToChange.skill)
            {
                Debug.Log("Attempting to change skill...");

                if (playerHealth != null)
                {
                    // Assume amountTochangeStat represents how many skill points to increase
                    playerHealth.currentSkillpoint += amountTochangeStat;

                    // Ensure current skill points do not exceed maximum
                    if (playerHealth.currentSkillpoint > playerHealth.maxskillpoint)
                    {
                        playerHealth.currentSkillpoint = playerHealth.maxskillpoint;
                    }

                    // Call method to activate game objects based on the updated skill points
                    playerHealth.SetActiveGameObjectsBasedOnSkillPoints();

                    Debug.Log($"Updated skill points to {playerHealth.currentSkillpoint}");
                    return true; // Successful skill activation
                }
                else
                {
                    Debug.LogError("PlayerHealth reference is null!");
                    return false; // Unable to activate skill
                }
            }


        return false; // If statTC is not health or skill
    }


    public enum statToChange
    {
        none,
        health,
        skill
    };
}
