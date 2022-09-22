using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    [Header("Dynamic")]
    public int score = 0;
    private TMPro.TextMeshProUGUI uiTextComponent;

    // Start is called before the first frame update
    void Start()
    {
        uiTextComponent = GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        uiTextComponent.text = score.ToString("#,0");    // Format with comma
    }
}
