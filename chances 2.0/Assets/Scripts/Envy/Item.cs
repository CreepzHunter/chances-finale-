using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;


public class Item : MonoBehaviour
{
    public CameraSwitch cameraSwitch;
    public HealthSystem EnvyLife;
    public SkillManager skillManager;
    public GameManagerEnvyNew gameManagerEnvyNew;
    public GameManagerSloth gameManagerSloth;
    public GameFlowManagerLust gameFlowManagerLust;
    public GameManagerGreedPride gameManagerGreedPride;
    public AttackGluttony attackGluttony;
    public GameManagerWrath gameManagerWrath;
    public HealthSystem cockroachLife;
    public Button[] buttons;

    public TextMeshProUGUI skillS;
    public TextMeshProUGUI skillM;
    public TextMeshProUGUI healthS;
    public TextMeshProUGUI healthM;



    [SerializeField] private GameObject playerBack;
    [SerializeField] private GameObject playerItem;
    [SerializeField] private GameObject inventory;
    [SerializeField] private GameObject back;

    public GameObject[] btnsToShow;
    public GameObject[] ToHide;

    public void OnClickItem()
    {
        if (EnvyLife.health != 0)
        {
            HideAttack();
            Invoke("Inventory", 0.4f);
        }
    }
    void Start()
    {
        // Assign listeners to buttons
        buttons[0].onClick.AddListener(() => UseSmallBottle());
        buttons[1].onClick.AddListener(() => UseMidBottle());
        buttons[4].onClick.AddListener(() => EatChocolate());
        buttons[5].onClick.AddListener(() => UseMedkit());


        ItemStats.Instance.smallBottle = PlayerPrefs.GetInt("SmallBottle", ItemStats.Instance.smallBottle);
        ItemStats.Instance.largeBottle = PlayerPrefs.GetInt("LargeBottle", ItemStats.Instance.largeBottle);
        ItemStats.Instance.smallMedkit = PlayerPrefs.GetInt("SmallMedkit", ItemStats.Instance.smallMedkit);
        ItemStats.Instance.largeMedkit = PlayerPrefs.GetInt("LargeMedkit", ItemStats.Instance.largeMedkit);


        // Initialize button states
        UpdateButtonStates();
    }

    void Update()
    {
        UpdateItemValue();
    }

    void UpdateItemValue()
    {
        int small = PlayerPrefs.GetInt("SmallBottle", ItemStats.Instance.smallBottle);
        int large = PlayerPrefs.GetInt("LargeBottle", ItemStats.Instance.largeBottle);
        int medS = PlayerPrefs.GetInt("SmallMedkit", ItemStats.Instance.smallMedkit);
        int medL = PlayerPrefs.GetInt("LargeMedkit", ItemStats.Instance.largeMedkit);

        ItemStats.Instance.smallBottle = small;
        ItemStats.Instance.largeBottle = large;
        ItemStats.Instance.smallMedkit = medS;
        ItemStats.Instance.largeMedkit = medL;

        skillS.text = small.ToString();
        skillM.text = large.ToString();
        healthS.text = medS.ToString();
        healthM.text = medL.ToString();
    }


    #region skill animation
    private void AnimatePlayer()
    {
        cameraSwitch.PlayerView();

        HideAttack();

        playerBack.SetActive(false);
        playerItem.SetActive(true);
    }
    private void ReturnAnimate()
    {
        cameraSwitch.FightScene();
        playerBack.SetActive(true);
        playerItem.SetActive(false);
    }

    private void Inventory()
    {
        inventory.SetActive(true);
        back.SetActive(true);
    }

    public void ReturnAll()
    {
        btnsToShow.ToList().ForEach(button =>
        {
            button.SetActive(true);
        });
    }
    private void DoneItem()
    {
        ToHide.ToList().ForEach(button =>
        {
            button.SetActive(true);
        });
        AnimatePlayer();
        Invoke("ReturnAnimate", 1.2f);
        Invoke("EnemyTurnGameplay", 1.5f);
    }

    private void HideAttack()
    {
        ToHide.ToList().ForEach(objToHide =>
        {
            objToHide.SetActive(false);
        });
    }
    #endregion

    #region attack
    private void EnemyTurnGameplay()
    {
        if (gameManagerEnvyNew != null)
        {
            gameManagerEnvyNew.EAnimatePlayer();

            gameManagerEnvyNew.EnvyAttack();
        }
        if (gameManagerSloth != null)
        {
            if (cockroachLife.health != 0)
            {
                gameManagerSloth.AnimateCKAttack();
            }
            else
            {
                gameManagerSloth.SlothAttack();
            }
        }
        if (gameFlowManagerLust != null)
        {
            gameFlowManagerLust.PlayGame();
        }
        if (gameManagerGreedPride != null)
        {
            gameManagerGreedPride.ReturnAnimation();
        }
        if (attackGluttony != null)
        {
            attackGluttony.EnemyAnimAttack();

            Invoke("GluttonyPlayGame", 1f);

            // ItemStats.Instance.smallBottle += 10;
            // ItemStats.Instance.largeBottle += 10;
            // ItemStats.Instance.smallMedkit += 10;
            // ItemStats.Instance.largeMedkit += 10;
            // PlayerPrefs.SetInt("SmallBottle", ItemStats.Instance.smallBottle);
            // PlayerPrefs.SetInt("LargeBottle", ItemStats.Instance.largeBottle);
            // PlayerPrefs.SetInt("SmallMedkit", ItemStats.Instance.smallMedkit);
            // PlayerPrefs.SetInt("LargeMedkit", ItemStats.Instance.largeMedkit);
            // PlayerPrefs.Save();
        }
        if (gameManagerWrath != null)
        {
            gameManagerWrath.OnClickAttack();
        }
    }

    private void GluttonyPlayGame()
    {
        attackGluttony.PlayGame();
    }

    #endregion

    #region inventory system


    void UpdateButtonStates()
    {
        buttons[0].interactable = ItemStats.Instance.smallBottle > 0;
        buttons[1].interactable = ItemStats.Instance.largeBottle > 0;
        buttons[4].interactable = ItemStats.Instance.smallMedkit > 0;
        buttons[5].interactable = ItemStats.Instance.smallBottle > 0;
    }

    void UseSmallBottle()
    {
        if (ItemStats.Instance.smallBottle > 0)
        {
            PlayerStats.Instance.PSkill++;
            PlayerPrefs.SetInt("PSkill", PlayerStats.Instance.PSkill);
            ItemStats.Instance.smallBottle--;
            PlayerPrefs.SetInt("SmallBottle", ItemStats.Instance.smallBottle);
            PlayerPrefs.Save();

            UpdateButtonStates();
            DoneItem();
        }
    }

    void UseMidBottle()
    {
        if (ItemStats.Instance.largeBottle > 0)
        {
            PlayerStats.Instance.PSkill += 2;
            PlayerPrefs.SetInt("PSkill", PlayerStats.Instance.PSkill);
            ItemStats.Instance.largeBottle--;
            PlayerPrefs.SetInt("LargeBottle", ItemStats.Instance.largeBottle);
            PlayerPrefs.Save();
            UpdateButtonStates();
            DoneItem();
        }
    }

    void EatChocolate()
    {
        if (ItemStats.Instance.smallMedkit > 0)
        {
            PlayerStats.Instance.PHealth += 15;
            PlayerPrefs.SetInt("PHealth", PlayerStats.Instance.PHealth);
            ItemStats.Instance.smallMedkit--;
            PlayerPrefs.SetInt("SmallMedkit", ItemStats.Instance.smallMedkit);
            PlayerPrefs.Save();
            DoneItem();
            UpdateButtonStates();
        }
    }

    void UseMedkit()
    {
        if (ItemStats.Instance.largeMedkit > 0)
        {
            PlayerStats.Instance.PHealth += 40;
            PlayerPrefs.SetInt("PHealth", PlayerStats.Instance.PHealth);
            ItemStats.Instance.largeMedkit--;
            PlayerPrefs.SetInt("LargeMedkit", ItemStats.Instance.largeMedkit);
            PlayerPrefs.Save();
            DoneItem();
            UpdateButtonStates();
        }
        #endregion
    }
}