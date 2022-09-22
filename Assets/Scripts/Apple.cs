using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    // This CLASS variable is available for all instances!
    public static float bottomY = -20f;
    // Update is called once per frame
    void Update()
    {   // Missed apple
        if (transform.position.y <= bottomY)
        {
            Destroy(this.gameObject);
            ApplePicker applePickerComponent = Camera.main.GetComponent<ApplePicker>();
            applePickerComponent.AppleMissed();
        }
    }
}
