using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class novelscene : MonoBehaviour
{
    
    public GameObject novel;
    public GameObject UI;
    public Animator scene;
    public GameObject Closeoption;


    public static bool IsActive = false;
    
    

    void openscenenovel()
    {   
        IsActive = true;
        novel.SetActive(true);
        //UI.SetActive(false);
        scene.SetBool("IsLoad", true);
        
        
    }

    public void closecenenovel()
    {   
        IsActive = false;
        scene.SetBool("IsLoad", false);
        novel.SetActive(false);
        //UI.SetActive(true);
        
        
    }

    private void OnMouseDown()
    {
        openscenenovel();
    }

    
}
