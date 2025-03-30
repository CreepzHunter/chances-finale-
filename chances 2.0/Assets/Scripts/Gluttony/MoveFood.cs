using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFood : MonoBehaviour
{
    [Header("Speed Variables")]
    [SerializeField] private float minXSpeed;
    [SerializeField] private float maxXSpeed;
    [SerializeField] private float minYSpeed;
    [SerializeField] private float maxYSpeed;
    //gameplay
    [SerializeField] private float lifetime;
    [SerializeField] private Rigidbody2D rb2d;
    private bool wasCut = false;

    void Start()
    {
        //throw the objects upwards
        rb2d.velocity = new Vector2(
            Random.Range(minXSpeed, maxXSpeed),
            Random.Range(minYSpeed, maxYSpeed)
        );
        Destroy(gameObject, lifetime);

    }

    public void MarkAsCut()
    {
        wasCut = true;
    }

    void OnDestroy()
    {
        if (!wasCut && gameObject.CompareTag("Fruits"))
        {
            GameplayHealth health = FindObjectOfType<GameplayHealth>();

            float rnd = Random.Range(10f, 20f);
            if (health != null)
                health.TakeDamage(rnd);
        }
    }
}
