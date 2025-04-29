using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Finish : MonoBehaviour
{
    // GameObject references
    public GameObject slothCharacter;

    // Component references
    public Movement playerMovement;
    public HealthSystem enemyHealth;
    public Enemy enemyController;
    public CameraSwitch cameraController;
    public GameManagerSloth gameManager;
    public SkillOption skillOption;
    public StartBlinkingAnim startBlinkingAnim;

    public GameObject[] boxHide;

    public GameObject[] destroyBoxAfterWin;
    private Vector2 startLocation;

    private void Start()
    {
        StartingLocation();
    }

    public void StartingLocation()
    {
        startLocation = enemyController.initialStartLocation1;
        startLocation = enemyController.initialStartLocation2;
        startLocation = enemyController.initialStartLocation3;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            HandlePlayerCollision();
        }
    }

    private void HandlePlayerCollision()
    {
        // Deal damage to the enemy
        enemyHealth.TakeDamage(15);
        int rndatt = Random.Range(5, 15);
        enemyHealth.TakeDamage(rndatt);
        if (skillOption.attack == true)//activate more damage when skill
        {
            enemyHealth.TakeDamage(25);
            skillOption.attack = false;
        }
        // Disable sloth-related GameObjects
        slothCharacter.SetActive(false);
        // slothLifeBar.SetActive(false);
        gameManager.slothAttack.SetActive(false);
        startBlinkingAnim.StartBlinking(0);

        // Reset game statea
        gameManager.check = false;
        cameraController.FightScene();
        enemyController.SetEnemyStateAsleep();
        enemyController.Move1();
        enemyController.Move2();
        enemyController.Move3();
        enemyController.ResetLocation();

        gameManager.slothGameplay.ToList().ForEach(button =>
         {
             button.SetActive(false);
         });
        boxHide.ToList().ForEach(button =>
        {
            button.SetActive(false);
        });
        destroyBoxAfterWin.ToList().ForEach(item =>
        {
            Destroy(item);
        });

        gameManager.ReturnAll();
        gameManager.SlothEnable();

        // Reset player position
        playerMovement.transform.position = startLocation;
    }
}
