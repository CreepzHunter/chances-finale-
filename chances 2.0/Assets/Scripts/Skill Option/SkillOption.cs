using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SkillOption : MonoBehaviour
{
    public Skill skill;
    public bool attack = false;
    public bool shield = false;

    [SerializeField] private GameObject[] shieldIcon;
    public void SkillAttackButton()
    {
        attack = true;

        skill.AnimateSkill();

        Invoke("DelaySkill", 2.0f);
    }

    public void SkillShieldButton()
    {
        shield = true;

        skill.AnimateShield();
        shieldIcon.ToList().ForEach(elements =>
        {
            elements.SetActive(true);
        });
        Invoke("DelayShield", 1.1f);

    }

    private void DelaySkill()
    {
        skill.SkillAttack();
    }
    private void DelayShield()
    {
        skill.SkillShield();
    }

    public void HideShield()
    {
        shieldIcon.ToList().ForEach(elements =>
        {
            elements.SetActive(false);
        });
    }

}
