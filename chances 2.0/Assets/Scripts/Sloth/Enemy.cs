using UnityEngine;

public class Enemy : MonoBehaviour
{

    private enum EnemyState { Asleep, Awakening, Awake }

    private EnemyState currentState = EnemyState.Asleep;

    [Header("Timing Settings")]
    [SerializeField] private float initialAwakeningTime = 10f;
    [SerializeField] private float orangeLightDuration = 3f;
    [SerializeField] private float redLightDuration = 2f;
    private float timer = 0f;

    private SpriteRenderer spriteRenderer;
    private Color initialColor = Color.grey;
    private Color orangeColor = new Color(1f, 0.5f, 0f);
    private Color redColor = Color.red;

    public Collectable collectable;
    public Movement playerMovement1;
    public Movement playerMovement2;
    public Movement playerMovement3;
    public GameManagerSloth gameManagerSloth;
    public HealthSystem healthSystem;
    //parent's Vector3(2.25,-1.29797363,-3.72000003)
    // public Vector3 initialStartLocation1 = new Vector3(0.23f, 3.53f, 0f);
    public Vector3 initialStartLocation1;
    public Vector3 initialStartLocation2 = new Vector3(1.67299998f, 1.95099998f, 0f);
    public Vector3 initialStartLocation3 = new Vector3(1.15999997f, -1.05999994f, 0f);


    public GameObject[] gameplay;
    public GameObject[] key;
    public GameObject[] doorClose;
    public GameObject[] doorOpen;

    public GameObject doorB;
    public GameObject doorC;



    public bool isDead = false;

    public void Awake()
    {

        playerMovement1.transform.localPosition = initialStartLocation1;
        playerMovement2.transform.localPosition = initialStartLocation2;
        playerMovement3.transform.localPosition = initialStartLocation3;

    }
    void Start()
    {
        //playerMovement = GameObject.FindWithTag("Player").GetComponent<Movement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        initialColor = spriteRenderer.color;
        currentState = EnemyState.Asleep;
        timer = initialAwakeningTime;

    }
    public void ResetLocation()
    {
        if (gameplay[0].activeSelf)
        {
            key[0].SetActive(true);
            doorClose[0].SetActive(true);
            doorOpen[0].SetActive(false);
            playerMovement1.transform.localPosition = initialStartLocation1;
        }
        else if (gameplay[1].activeSelf)
        {
            key[1].SetActive(true);
            doorB.SetActive(true);
            doorClose[1].SetActive(true);
            doorOpen[1].SetActive(false);
            playerMovement2.transform.localPosition = initialStartLocation2;
        }
        else if (gameplay[2].activeSelf)
        {
            key[2].SetActive(true);
            doorClose[2].SetActive(true);
            doorOpen[2].SetActive(false);
            playerMovement3.transform.localPosition = initialStartLocation3;
        }
    }
    public void SetEnemyStateAsleep()
    {
        spriteRenderer.color = initialColor;

    }

    void Update()
    {
        if (healthSystem.health <= 0)
        {
            //slothLife.SetActive(false);
            isDead = true;

        }
        else if (gameManagerSloth.check)
        {
            switch (currentState)
            {
                case EnemyState.Asleep:
                    timer -= Time.deltaTime;
                    if (timer <= 0)
                    {
                        currentState = EnemyState.Awakening;
                        timer = orangeLightDuration;
                        spriteRenderer.color = orangeColor;
                    }
                    break;

                case EnemyState.Awakening:
                    timer -= Time.deltaTime;
                    if (timer <= 0)
                    {
                        currentState = EnemyState.Awake;
                        spriteRenderer.color = redColor;
                        Debug.Log("Attack State");
                        timer = redLightDuration;
                    }
                    break;

                case EnemyState.Awake:
                    timer -= Time.deltaTime;
                    if (timer <= 0)
                    {
                        currentState = EnemyState.Asleep;
                        spriteRenderer.color = initialColor;
                        timer = initialAwakeningTime;
                    }
                    break;

                default:
                    break;
            }

            if ((currentState == EnemyState.Awake) && (playerMovement1.isMoving || playerMovement2.isMoving || playerMovement3.isMoving))
            {
                Debug.Log("Player detected");

                if (gameplay[0].activeSelf)
                {
                    key[0].SetActive(true);
                    doorClose[0].SetActive(true);
                    doorOpen[0].SetActive(false);
                    playerMovement1.transform.localPosition = initialStartLocation1;
                }
                else if (gameplay[1].activeSelf)
                {
                    key[1].SetActive(true);
                    doorB.SetActive(true);
                    doorClose[1].SetActive(true);
                    doorOpen[1].SetActive(false);
                    playerMovement2.transform.localPosition = initialStartLocation2;
                }
                else if (gameplay[2].activeSelf)
                {
                    key[2].SetActive(true);
                    doorClose[2].SetActive(true);
                    doorOpen[2].SetActive(false);
                    playerMovement3.transform.localPosition = initialStartLocation3;
                }
            }
        }
    }


    public void Move1()
    {
        playerMovement1.isMoving = false;
    }
    public void Move2()
    {
        playerMovement2.isMoving = false;
    }
    public void Move3()
    {
        playerMovement3.isMoving = false;
    }
}
