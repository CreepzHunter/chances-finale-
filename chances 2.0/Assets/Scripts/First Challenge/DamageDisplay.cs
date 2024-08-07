using UnityEngine;
using TMPro;
using System.Collections;

public class DamageDisplay : MonoBehaviour
{

    public TextMeshProUGUI damageText;
    public TextMeshProUGUI persuadeText;
    public HealthSystem Persuasion;
    public HealthSystem Player;

    private void Start()
    {
        //damageText.gameObject.SetActive(true);
        //damageText.text = " ";
    }

    public void CheckLifeValue(float value)
    {
        // Retrieve the life value
        float lifeValue = Persuasion.health;
        float life = Player.health;
        // Check if the life value meets certain conditions (e.g., less than 50%)

        if (life > 0)
        {
            if (lifeValue < 50)
            {
                Debug.Log("lifeValue:" + lifeValue);
                Player.TakeDamage(value);
                damageText.text = "-" + value;
                StartCoroutine(FadeTxtD(value));
            }
            else
            {
                Debug.Log("last");
                persuadeText.text = "safe";
                StartCoroutine(FadeTxtP(value));
            }
        }
        else
        {

        }

    }

    public void Damage(float value)
    {
        //Player.TakeDamage(value);
        damageText.text = "-" + value;
        StartCoroutine(FadeTxtD(value));

    }
    public void Persuade(float value)
    {
        //Persuasion.Persuasion(value);
        persuadeText.text = "+" + value;
        StartCoroutine(FadeTxtP(value));

    }


    IEnumerator FadeTxtD(float value)
    {
        damageText.CrossFadeAlpha(1f, 1.5f, false); // Fade in over 1.5 seconds
        yield return new WaitForSeconds(.3f);
        damageText.CrossFadeAlpha(0f, 1.5f, false); // Fade out over 1.5 seconds
        yield return new WaitForSeconds(.5f);
        damageText.text = ""; // Set the text back to "-10" or any desired value
        damageText.gameObject.SetActive(false);
    }
    IEnumerator FadeTxtP(float value)
    {
        persuadeText.CrossFadeAlpha(1f, 1.5f, false); // Fade in over 1.5 seconds
        yield return new WaitForSeconds(.3f);
        persuadeText.CrossFadeAlpha(0f, 1.5f, false); // Fade out over 1.5 seconds
        yield return new WaitForSeconds(.5f);
        persuadeText.text = "";// Set the text back to "-10" or any desired value
        persuadeText.gameObject.SetActive(false);
    }
}
