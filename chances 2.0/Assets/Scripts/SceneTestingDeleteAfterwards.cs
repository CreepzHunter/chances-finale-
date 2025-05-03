using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTestingDeleteAfterwards : MonoBehaviour
{
    public void ToSloth()
    {
        SceneManager.LoadScene(12);
    }

    public void ToLust()
    {
        SceneManager.LoadScene(13);
    }

    public void ToGandP()
    {
        SceneManager.LoadScene(14);
    }

    public void ToGluttony()
    {
        SceneManager.LoadScene(15);
    }

    public void ToWrath()
    {
        SceneManager.LoadScene(16);
    }

    public void Overworld()
    {
        SceneManager.LoadScene(1);

    }
}
