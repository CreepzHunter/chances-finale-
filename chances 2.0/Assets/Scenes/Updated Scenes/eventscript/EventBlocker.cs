using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EventBlocker : MonoBehaviour
{
    public GameObject FirstPath;
    public GameObject SecondPath;
    public GameObject ThirdPath;
    public GameObject FourthPath;
    public GameObject FifthPath;
    public GameObject sixthPath;

    public Image checkmark1;
    public Image checkmark2;
    public Image checkmark3;
    public Image checkmark4;
    public Image checkmark5;

    public TextMeshProUGUI task0;
    public TextMeshProUGUI task1;
    public TextMeshProUGUI task2;
    public TextMeshProUGUI task3;
    public TextMeshProUGUI task4;
    public TextMeshProUGUI task5;
    public TextMeshProUGUI task6;

    public int EventOccur = 0;

    private const string EventKey = "EventNumber";

    void Awake()
    {
        EventOccur = PlayerPrefs.GetInt(EventKey,0);
    }
    void Start()
    {
        events();
    }

    
    void Update()
    {
        
    }

    public void events()
    {
        switch(EventOccur)
        {
            case 0:
                FirstPath.gameObject.SetActive(true);
                SecondPath.gameObject.SetActive(true);
                ThirdPath.gameObject.SetActive(true);
                FourthPath.gameObject.SetActive(true);
                FifthPath.gameObject.SetActive(true);
                checkmark1.gameObject.SetActive(false);
                checkmark2.gameObject.SetActive(false);
                checkmark3.gameObject.SetActive(false);
                checkmark4.gameObject.SetActive(false);
                checkmark5.gameObject.SetActive(false);
                task0.gameObject.SetActive(true);
                break;
            
            case 1:
                FirstPath.gameObject.SetActive(false);
                task1.gameObject.SetActive(true);
                break;
            
            case 2:
                FirstPath.gameObject.SetActive(false);
                SecondPath.gameObject.SetActive(false);
                checkmark1.gameObject.SetActive(true);
                task2.gameObject.SetActive(true);
                break;
            
            case 3:
                FirstPath.gameObject.SetActive(false);
                SecondPath.gameObject.SetActive(false);
                ThirdPath.gameObject.SetActive(false);
                checkmark1.gameObject.SetActive(true);
                checkmark2.gameObject.SetActive(true);
                task3.gameObject.SetActive(true);
                break;

            case 4:
                FirstPath.gameObject.SetActive(false);
                SecondPath.gameObject.SetActive(false);
                ThirdPath.gameObject.SetActive(false);
                FourthPath.gameObject.SetActive(false);
                checkmark1.gameObject.SetActive(true);
                checkmark2.gameObject.SetActive(true);
                checkmark3.gameObject.SetActive(true);
                task4.gameObject.SetActive(true);
                break;
            
            case 5:
                FirstPath.gameObject.SetActive(false);
                SecondPath.gameObject.SetActive(false);
                ThirdPath.gameObject.SetActive(false);
                FourthPath.gameObject.SetActive(false);
                FifthPath.gameObject.SetActive(false);
                checkmark1.gameObject.SetActive(true);
                checkmark2.gameObject.SetActive(true);
                checkmark3.gameObject.SetActive(true);
                checkmark4.gameObject.SetActive(true);
                task5.gameObject.SetActive(true);
                break;

            case 6:
                FirstPath.gameObject.SetActive(false);
                SecondPath.gameObject.SetActive(false);
                ThirdPath.gameObject.SetActive(false);
                FourthPath.gameObject.SetActive(false);
                FifthPath.gameObject.SetActive(false);
                sixthPath.gameObject.SetActive(false);
                checkmark1.gameObject.SetActive(true);
                checkmark2.gameObject.SetActive(true);
                checkmark3.gameObject.SetActive(true);
                checkmark4.gameObject.SetActive(true);
                checkmark5.gameObject.SetActive(true);
                task6.gameObject.SetActive(true);
                break;
        }
    }

    public void EventAdder(int amount)
    {
        EventOccur += amount;
        PlayerPrefs.SetInt(EventKey,EventOccur);
        PlayerPrefs.Save();
    }
    
}
