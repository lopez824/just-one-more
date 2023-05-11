using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollisionTracker : MonoBehaviour
{
    private TextMeshProUGUI highScore;
    private TextMeshProUGUI score;
    private bool fellDown = false;

    private void Awake()
    {
        highScore = GameObject.FindGameObjectWithTag("HighScore").GetComponent<TextMeshProUGUI>();
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<TextMeshProUGUI>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (fellDown == false)
        {
            if (collision.gameObject.tag == "Ground")
            {
                highScore.text = score.text;
                fellDown = true;
                PlayerPrefs.SetString("HighScore", highScore.text);
            }
        }
    }
}
