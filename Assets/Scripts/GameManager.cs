using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private int score = 0;

    void Start()
    {
        score = 0;
    }

    public void IncreaseScore()
    {
        score += 1;
    }

    public int GetScore()
    {
        return score;
    }

}
