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
    [SerializeField] private GameObject enemyLife;
    [SerializeField] private GameObject item;
    [SerializeField] private GameObject back;

    public GameObject[] BtnsToShow;
    public GameObject[] ToHide;

    public void OnClickItem()
    {
        if (EnvyLife.health != 0)
        {
            cameraSwitch.PlayerView();

            HideAttack();

            playerBack.SetActive(false);
            playerItem.SetActive(true);
            enemyLife.SetActive(false);

            Invoke("AnimatePlayer", 1.2f);
            Invoke("ReturnAll", 1.5f);
        }
    }

    #region skill animation
    private void AnimatePlayer()
    {
        Invoke("Inventory", 0.4f);
        cameraSwitch.FightScene();
        playerBack.SetActive(true);
        playerItem.SetActive(false);
        enemyLife.SetActive(true);
    }

    private void Inventory()
    {
        item.SetActive(true);
        back.SetActive(true);
    }

    public void ReturnAll()
    {
        BtnsToShow.ToList().ForEach(button =>
        {
            button.SetActive(true);
        });
    }

    private void HideAttack()
    {
        ToHide.ToList().ForEach(objToHide =>
        {
            objToHide.SetActive(false);
        });
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
            UpdateButtonStates();
            Debug.Log("Used Medkit. Remaining: " + medkitCount);
        }
    }
    #endregion 
}