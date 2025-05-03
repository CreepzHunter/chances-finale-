using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
                break;
            
            case 1:
                FirstPath.gameObject.SetActive(false);
                
                break;
            
            case 2:
                SecondPath.gameObject.SetActive(false);
                checkmark1.gameObject.SetActive(true);
                break;
            
            case 3:
                ThirdPath.gameObject.SetActive(false);
                checkmark2.gameObject.SetActive(true);
                break;

            case 4:
                FourthPath.gameObject.SetActive(false);
                checkmark3.gameObject.SetActive(true);
                break;
            
            case 5:
                FifthPath.gameObject.SetActive(false);
                checkmark4.gameObject.SetActive(true);
                break;

            case 6:
                sixthPath.gameObject.SetActive(false);
                checkmark5.gameObject.SetActive(true);
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
