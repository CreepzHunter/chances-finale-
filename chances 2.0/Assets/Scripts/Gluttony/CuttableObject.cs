using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttableObject : MonoBehaviour
{

    public virtual void OnCut()
    {
        Debug.Log("Object cut!");
    }
}
