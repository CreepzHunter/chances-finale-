using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class Item : MonoBehaviour
{
    public CameraSwitch cameraSwitch;
    public HealthSystem EnvyLife;
    public HealthSystemPlayer healthSystemPlayer;
    public SkillManager skillManager;
    public GameManagerEnvyNew gameManagerEnvyNew;
    public GameManagerSloth gameManagerSloth;
    public GameFlowManagerLust gameFlowManagerLust;
    public GameManagerGreedPride gameManagerGreedPride;
    public HealthSystem cockroachLife;
    public Button[] buttons;

    // Inventory counts
    private int smallBottleCount = 3;  // Example count, set based on your needs
    private int midBottleCount = 2;
    private int largeBottleCount = 1;
    private int appleCount = 5;
    private int chocolateCount = 3;
    private int medkitCount = 1;

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

            // Invoke("AnimatePlayer", 1.2f);
            // Invoke("ReturnAll", 1.5f);
        }
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
            button.SetActive(false);
        });
        AnimatePlayer();
        Invoke("ReturnAnimate", 1.2f);
        Invoke("EnemyTurnGameplay", 1.5f);
        //Invoke("ReturnAll", 1.5f);
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
                gameManagerSloth.AnimateAttack();
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
    }

    #endregion

    #region inventory system
    void Start()
    {
        // Assign listeners to buttons
        buttons[0].onClick.AddListener(() => UseSmallBottle());
        buttons[1].onClick.AddListener(() => UseMidBottle());
        buttons[2].onClick.AddListener(() => UseLargeBottle());
        buttons[3].onClick.AddListener(() => EatApple());
        buttons[4].onClick.AddListener(() => EatChocolate());
        buttons[5].onClick.AddListener(() => UseMedkit());

        // Initialize button states
        UpdateButtonStates();
    }

    void UpdateButtonStates()
    {
        buttons[0].interactable = smallBottleCount > 0;
        buttons[1].interactable = midBottleCount > 0;
        buttons[2].interactable = largeBottleCount > 0;
        buttons[3].interactable = appleCount > 0;
        buttons[4].interactable = chocolateCount > 0;
        buttons[5].interactable = medkitCount > 0;
    }

    void UseSmallBottle()
    {
        if (smallBottleCount > 0)
        {
            skillManager.diamond += 1;
            smallBottleCount--;
            UpdateButtonStates();
            DoneItem();
            Debug.Log("Used Small Bottle. Remaining: " + smallBottleCount);
        }
    }

    void UseMidBottle()
    {
        if (midBottleCount > 0)
        {
            skillManager.diamond += 2;
            midBottleCount--;
            UpdateButtonStates();
            DoneItem();
            Debug.Log("Used Mid Bottle. Remaining: " + midBottleCount);
        }
    }

    void UseLargeBottle()
    {
        if (largeBottleCount > 0)
        {
            skillManager.diamond += 2;
            healthSystemPlayer.Heal(5);
            largeBottleCount--;
            DoneItem();
            UpdateButtonStates();
            Debug.Log("Used Large Bottle. Remaining: " + largeBottleCount);
        }
    }

    void EatApple()
    {
        if (appleCount > 0)
        {
            healthSystemPlayer.Heal(5);
            appleCount--;
            DoneItem();
            UpdateButtonStates();
            Debug.Log("Ate Apple. Remaining: " + appleCount);
        }
    }

    void EatChocolate()
    {
        if (chocolateCount > 0)
        {
            healthSystemPlayer.Heal(10);
            chocolateCount--;
            DoneItem();
            UpdateButtonStates();
            Debug.Log("Ate Chocolate. Remaining: " + chocolateCount);
        }
    }

    void UseMedkit()
    {
        if (medkitCount > 0)
        {
            healthSystemPlayer.Heal(20);
            medkitCount--;
            DoneItem();
            UpdateButtonStates();
            Debug.Log("Used Medkit. Remaining: " + medkitCount);
        }
    }
    #endregion 
}