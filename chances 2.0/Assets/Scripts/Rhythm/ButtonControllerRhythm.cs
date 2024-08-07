using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControllerRhythm : MonoBehaviour
{
    //to animate when presed
    private SpriteRenderer theSR;
    public Sprite defaultImage;
    public Sprite pressedImage;
    public KeyCode keyCode;

    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(keyCode))
        {
            theSR.sprite = pressedImage;
        }
        if (Input.GetKeyUp(keyCode))
        {
            theSR.sprite = defaultImage;
        }
    }
}
