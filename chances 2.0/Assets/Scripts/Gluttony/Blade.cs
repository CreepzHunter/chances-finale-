using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    [Header("Gameplay")]
    [SerializeField] private GameObject cutPrefab;
    [SerializeField] private float cutLifetime;

    [SerializeField] private bool dragging;
    private Vector3 swipeStart;
    private Vector3 swipeEnd;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Record start position
        {
            dragging = true;
            swipeStart = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
        }
        else if (Input.GetMouseButtonUp(0) && dragging) // Record end position
        {
            dragging = false;
            swipeEnd = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
            SpawnCut(); // Trigger cut
        }
    }
    private void SpawnCut()
    {
        //Identified where the swipe ended.
        GameObject cutInstance = Instantiate(cutPrefab, swipeStart, Quaternion.identity);

        //Spwaned the cut object
        cutInstance.GetComponent<LineRenderer>().SetPosition(0, swipeStart);
        // Debug.Log(swipeStart + "-" + swipeEnd);
        cutInstance.GetComponent<LineRenderer>().SetPosition(1, swipeEnd);

        //Adjusted the edge collider
        Vector2[] colliderPoints = new Vector2[2];
        colliderPoints[0] = Vector2.zero;
        colliderPoints[1] = swipeEnd - swipeStart;
        cutInstance.GetComponent<EdgeCollider2D>().points = colliderPoints;

        //Scheduled the destruction of the cut object
        Destroy(cutInstance, cutLifetime);
    }
}
