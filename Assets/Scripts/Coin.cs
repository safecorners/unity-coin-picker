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
        Player player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            scoreManager.IncreaseScore();
            Destroy(this.gameObject);
        }

        Floor floor = other.gameObject.GetComponent<Floor>();
        if (floor != null)
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}
