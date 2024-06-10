using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    private Text textComponent;

    public GameManager scoreManager;
    
    void Start()
    {
        textComponent = GetComponent<Text>();
    }

    void Update()
    {
        textComponent.text = scoreManager.GetScore().ToString();
    }
}
