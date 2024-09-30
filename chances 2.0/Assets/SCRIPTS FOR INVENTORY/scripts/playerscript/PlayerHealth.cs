using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Slider slider;

    //====SKILL SCRIPT====//
    public GameObject[] skill;
    public int maxskillpoint;
    public int currentSkillpoint;

    void Start()
    {
        currentHealth = maxHealth;
        setMaxHealth(maxHealth);
    }

    public void setMaxHealth(int health)
        {
            slider.maxValue = health;
            slider.value = health;
        }

    public void setHealth(int health)
        {
            slider.value = health;
        }


    public void Heal(int healAmount)
    {   
        Debug.Log("heal");

        Debug.Log($"Current Health Before Healing: {currentHealth}");

        if (currentHealth < maxHealth)
        {
            currentHealth += healAmount;
            if (currentHealth > maxHealth) // Ensure health doesn't exceed max
            {
                currentHealth = maxHealth;
            }
            setHealth(currentHealth); // Update slider with new health value
            Debug.Log($"Current Health After Healing: {currentHealth}");
        }
        else
        {
            Debug.Log("Health is already at maximum.");
        }
    }

    public void SetActiveGameObjectsBasedOnSkillPoints()
    {
        // Disable all skill game objects
        for (int i = 0; i < skill.Length; i++)
        {
            skill[i].SetActive(false);
        }

        // Limit current skill points to not exceed max skill points
        if (currentSkillpoint > maxskillpoint)
        {
            currentSkillpoint = maxskillpoint;
        }

        // Activate game objects based on current skill points
        for (int i = 0; i < currentSkillpoint && i < skill.Length; i++)
        {
            skill[i].SetActive(true);
        }

        Debug.Log($"Activated {currentSkillpoint} skill(s) out of {skill.Length} available skills.");
    }

    public bool CanDeductSkillPoint()
    {
        // Check if the current skill point is less than max
        return currentSkillpoint < maxskillpoint;
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            takeDamage(20);

        }
    }

     void takeDamage(int damage)
    {
        currentHealth -= damage;
        setHealth(currentHealth);
    }

}
