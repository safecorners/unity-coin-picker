using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Coin : MonoBehaviour
{
    private GameManager scoreManager;
    void Start()
    {
        scoreManager = GameObject.FindObjectOfType<GameManager>();
    }
    void OnCollisionEnter2D(Collision2D other)
    { 
        if (other.gameObject.CompareTag("Player"))
        {
            scoreManager.IncreaseScore();
            Destroy(this.gameObject);
        }
    
        if (other.gameObject.CompareTag("Floor"))
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}
