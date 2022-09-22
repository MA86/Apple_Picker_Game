using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// THIS IS GAME MANAGEMENT SCRIPT
// Runs the entire game
public class ApplePicker : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;
    // Start is called before the first frame update
    void Start()
    {
        // Create a stack of three baskets
        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }

    public void AppleMissed()
    {
        // Destroy all of the falling Apples
        GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tempGO in appleArray)
        {
            Destroy(tempGO);
        }

        // Destroy one of the baskets
        int basketIndex = basketList.Count - 1;         // Last basket
        GameObject basketGO = basketList[basketIndex];  // Reference to last basket
        basketList.RemoveAt(basketIndex);               // Remove basket
        Destroy(basketGO);                              // Destroy basket

        // If there are no Baskets left, restart the game 
        if (basketList.Count == 0)
        {
            SceneManager.LoadScene("_Scene_0");
        }
    }
}
