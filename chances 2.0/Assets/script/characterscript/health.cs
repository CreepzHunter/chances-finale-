using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    public int maxhealth = 3;
    public int currenthealth;

    public healthstatusscript healthscript;

    void Start()
    {
        currenthealth = maxhealth;
        healthscript.setMaxHealth(maxhealth);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            takeDamage(1);
        }
    }

    void takeDamage(int damage)
    {
        currenthealth -= damage;
        healthscript.setHealth(currenthealth);
    }

    public void healPlayer(int heal)
    {
        if(currenthealth < maxhealth)
        {
            currenthealth += heal;
            healthscript.setHealth(currenthealth);
        }
    }
}
