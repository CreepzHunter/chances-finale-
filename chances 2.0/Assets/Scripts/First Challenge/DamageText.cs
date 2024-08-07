// using UnityEngine;
// using TMPro;
// using System.Collections;

// public class DamageText : MonoBehaviour
// {
//     public void DamageTextFunction()
//     {
//         public TextMeshProUGUI damageText;
//     public HealthSystem Persuasion;
//     public HealthSystem Player;

//     private void Start()
//     {
//         damageText.gameObject.SetActive(true);
//         damageText.text = " ";
//     }

//     public void CheckLifeValue(float value)
//     {
//         // Retrieve the life value
//         float lifeValue = Persuasion.health;

//         // Check if the life value meets certain conditions (e.g., less than 50%)
//         if (lifeValue < 50)
//         {
//             Debug.Log("Checking life value with: " + value);
//             Player.TakeDamage(value);
//             damageText.text = "-" + value;

//             // Fade the text in and then delete it after 1.5 seconds
//             StartCoroutine(FadeTxt());
//         }
//         else
//         {
//             Debug.Log("Persuasion is above or equal to 50%!");
//         }
//     }

//     public void DamageText(float value)
//     {
//         Player.TakeDamage(value);
//         damageText.text = "-" + value;
//         StartCoroutine(FadeTxt());

//     }
//     public void PersuadeTexts(float value)
//     {
//         Persuasion.Persuasion(value);
//         damageText.text = "+" + value;
//         StartCoroutine(FadeTxt());

//     }


//     IEnumerator FadeTxt()
//     {
//         damageText.CrossFadeAlpha(1f, 1.5f, false); // Fade in over 1.5 seconds
//         yield return new WaitForSeconds(.3f);
//         damageText.CrossFadeAlpha(0f, 1.5f, false); // Fade out over 1.5 seconds
//         yield return new WaitForSeconds(.5f);
//         damageText.text = "-10"; // Set the text back to "-10" or any desired value
//         damageText.gameObject.SetActive(false);
//     }
// }

// }
