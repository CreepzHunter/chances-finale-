using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class Skill : MonoBehaviour
{
    #region Dependencies
    public CameraSwitch cameraSwitch;
    public HealthSystem cockroachLife;
    public StartBlinkingAnim startBlinking;
    public GameManagerSloth gameManagerSloth;
    public GameManagerEnvyNew gameManagerEnvyNew;
    public GameFlowManagerLust gameFlowManagerLust;
    public GameManagerGreedPride gameManagerGreedPride;
    public AttackGluttony attackGluttony;
    public GameManagerWrath gameManagerWrath;
    public SkillManager skillManager;
    #endregion
    #region Serialized Fields
    [SerializeField] private GameObject playerBack;
    [SerializeField] private GameObject playerSkill;
    [SerializeField] private GameObject playerShield;
    [SerializeField] private GameObject enemyLife;
    [SerializeField] private GameObject ckenemyLife;
    [SerializeField] private GameObject skillOpt;
    public GameObject[] PSkills;
    public GameObject[] BtnsToShow;
    public GameObject[] ToHide;
    #endregion


    #region Skill Logic
    void Start()
    {
        PlayerStats.Instance.PSkill = PlayerPrefs.GetInt("PSkill", PlayerStats.Instance.PSkill);
    }

    public void OnClickSkill()
    {
        if (PlayerStats.Instance.PHealth != 0 && PlayerStats.Instance.PSkill != 0)
        {
            HideAttack();
            PlayerStats.Instance.PSkill--;
            PlayerPrefs.SetInt("PSkill", PlayerStats.Instance.PSkill);
            skillOpt.SetActive(true);
        }
    }

    public void AnimateSkill()
    {
        PSkills[0].SetActive(true);
        enemyLife.SetActive(false);
        ToHide[3].SetActive(false);
    }

    public void AnimateShield()
    {
        PSkills[1].SetActive(true);
        enemyLife.SetActive(false);
        ToHide[3].SetActive(false);
    }

    public void SkillAttack()
    {
        playerBack.SetActive(true);
        PSkills[0].SetActive(false);
        enemyLife.SetActive(true);

        ExecuteManagerActions();
        // ReturnAll();
    }

    public void SkillShield()
    {
        playerBack.SetActive(true);
        PSkills[1].SetActive(false);
        enemyLife.SetActive(true);

        ExecuteManagerActions();
        // ReturnAll();
    }
    #endregion

    #region Helper Methods
    private void ExecuteManagerActions()
    {
        if (gameFlowManagerLust != null)
        {
            gameFlowManagerLust.PlayGame();
        }
        if (gameManagerEnvyNew != null)
        {
            gameManagerEnvyNew.EAnimatePlayer();
            gameManagerEnvyNew.EnvyAttack();
        }

        if (gameManagerSloth != null)
        {
            if (cockroachLife.health != 0)
            {
                gameManagerSloth.OnClickAttack();
            }
            else
            {
                gameManagerSloth.SlothAttack();
            }
        }
        if (gameManagerGreedPride != null)
        {
            gameManagerGreedPride.ReturnAnimation();
        }
        if (attackGluttony != null)
        {
            attackGluttony.PlayGame();
            cameraSwitch.SlothGame();
            Camera.main.orthographic = true;
        }
        if (gameManagerWrath != null)
        {
            gameManagerWrath.ReturnAnimation();
        }

    }

    public void ReturnAll()
    {
        ckenemyLife?.SetActive(true);

        BtnsToShow.ToList().ForEach(button => button.SetActive(true));
    }

    public void HideAttack()
    {
        ToHide.ToList().ForEach(objToHide => objToHide.SetActive(false));
    }
    #endregion
}
