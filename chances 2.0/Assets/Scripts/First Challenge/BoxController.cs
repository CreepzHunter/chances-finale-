using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BoxController : MonoBehaviour
{
    public TextMeshProUGUI textA;
    public TextMeshProUGUI textB;
    public TextMeshProUGUI textC;
    public TextMeshProUGUI takedmg;
    public TextMeshProUGUI persuade;
    public HealthSystem HSPersuasion;
    public HealthSystem HSDamage;
    int highestNumber, lowestNumber;
    private bool numbersRevealed = false;
    public DamageDisplay damageDisplay;

    public GameObject enemy;
    void Start()
    {
        textA.text = " ";
        textB.text = " ";
        textC.text = " ";
    }

    public void OnButtonClick(TextMeshProUGUI button)
    {
        if (!numbersRevealed || HSPersuasion.health == 100)
        {
            Debug.Log("work");
            enemy.gameObject.SetActive(false);

            int numberA = Random.Range(1, 100);
            int numberB = Random.Range(1, 100 - numberA);
            int numberC = 100 - numberA - numberB;

            textA.text = numberA.ToString() + "%";
            textB.text = numberB.ToString() + "%";
            textC.text = numberC.ToString() + "%";

            highestNumber = Mathf.Max(numberA, numberB, numberC);
            lowestNumber = Mathf.Min(numberA, numberB, numberC);

            if ((button.text == "A" && highestNumber == numberA) ||
            (button.text == "B" && highestNumber == numberB) ||
            (button.text == "C" && highestNumber == numberC))
            {
                if (HSPersuasion.health < 100)
                {
                    damageDisplay.Persuade(20);
                    HSPersuasion.Heal(20);
                    Debug.Log("Persausion Level: " + HSPersuasion.health);
                }

            }
            else if ((button.text == "A" && lowestNumber == numberA) ||
            (button.text == "B" && lowestNumber == numberB) ||
            (button.text == "C" && lowestNumber == numberC))
            {
                damageDisplay.Damage(10);
                HSDamage.TakeDamage(10);
            }
            else
            {
                damageDisplay.Persuade(10);
                HSPersuasion.Heal(10);
            }
            numbersRevealed = true;
        }

    }

    public void ResetNumbers()
    {
        textA.text = " ";
        textB.text = " ";
        textC.text = " ";
        persuade.text = " ";
        takedmg.text = " ";
        highestNumber = 0;
        persuade.gameObject.SetActive(true);
        takedmg.gameObject.SetActive(true);
        numbersRevealed = false;
    }
}
