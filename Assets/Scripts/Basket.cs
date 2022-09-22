using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    public ScoreCounter scoreCounterComponent;

    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreCounterObj = GameObject.Find("ScoreCounter");
        scoreCounterComponent = scoreCounterObj.GetComponent<ScoreCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;

        // The Camera’s z position sets how far to push the mouse into 3D
        mousePos2D.z = -Camera.main.transform.position.z;

        // Convert the point from screen space into world space
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        // Move the x position of this Basket to the x position of the Mouse
        Vector3 pos = transform.position;
        pos.x = mousePos3D.x;
        transform.position = pos;
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        // Find out what hit this basket
        GameObject collidedWith = collisionInfo.gameObject;
        if (collidedWith.CompareTag("Apple"))
        {
            Destroy(collidedWith);

            // Score
            scoreCounterComponent.score += 100;
        }
    }
}

