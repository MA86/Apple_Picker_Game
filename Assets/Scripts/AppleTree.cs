using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    // Custom attribute to add header to fields in inspector
    [Header("Inscribed")]
    public GameObject applePrefab = null;
    public float speed = 1f;
    public float turnAroundDistance = 10f;
    public float dirChangeChance = 0.1f;
    public float appleDropDelay = 1f;

    // Start is called before the first frame update
    void Start()
    {
        // Start dropping apples
        Invoke("DropApple", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        Vector3 pos = transform.position;   // Current pos
        pos.x += speed * Time.deltaTime;    // New pos
        transform.position = pos;           // Assign new pos

        // Direction normal
        if (pos.x < -turnAroundDistance)
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > turnAroundDistance)
        {
            speed = -Mathf.Abs(speed);
        }
    }

    // FixedUpdate is called exactly 50 times per second
    void FixedUpdate()
    {
        // Direction random
        if (Random.value < dirChangeChance)
        {
            speed *= -1;
        }
    }

    // Drop an apple
    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", appleDropDelay);
    }
}
