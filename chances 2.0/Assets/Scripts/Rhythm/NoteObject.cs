using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    // to check if the arrow meets the box

    public bool canBePressed;
    public KeyCode keyCode;

    public GameObject hitEffect, goodEffect, perfectEffect, missEffect;
    Vector3 offset = new Vector3(0.3f, 0f, 0f);
    private int missCount = 0;
    private int hitCount = 0;
    private int goodCount = 0;
    private int perfectCount = 0;

    public GameManagerRhythm gameManagerRhythm;
    void Start()
    {

    }

    void Update()
    {
        if (GameManagerRhythm.instance.stopGame)
        {
            return;
        }

        if (Input.GetKeyDown(keyCode))
        {
            if (canBePressed)
            {
                // gameObject.SetActive(false);
                Destroy(gameObject, 0.02f);


                //Normal Hit
                if (Mathf.Abs(transform.position.y) > 0.25f)
                {
                    hitCount++;
                    Debug.Log("Normal hit: " + hitCount);
                    GameManagerRhythm.instance.NormalHit();
                    Instantiate(hitEffect, transform.position + offset, hitEffect.transform.rotation);
                }
                //Good Hit
                else if (Mathf.Abs(transform.position.y) > 0.05f)
                {
                    goodCount++;
                    Debug.Log("Good hit: " + goodCount);
                    GameManagerRhythm.instance.GoodHit();
                    Instantiate(goodEffect, transform.position + offset, goodEffect.transform.rotation);
                }
                //Perfect Hit
                else
                {
                    perfectCount++;
                    Debug.Log("Perfect hit: " + perfectCount);
                    GameManagerRhythm.instance.PerfectHit();
                    Instantiate(perfectEffect, transform.position + offset, perfectEffect.transform.rotation);
                }
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator" && gameObject.activeSelf)
        {
            missCount++;
            Debug.Log("Mised: " + missCount);
            canBePressed = false;
            GameManagerRhythm.instance.NoteMissed();
            Instantiate(missEffect, transform.position + offset, missEffect.transform.rotation);
            Destroy(gameObject);
        }
    }
}
