using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject screen;
    public Text timertxt,score;
    float timer;
    public int nbEnnemi;
    int nbScore;
    private void Awake()
    {
        Time.timeScale = 1.0f;
    }
    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        timertxt.text = ((int)timer).ToString();
        nbScore = (int)timer + nbEnnemi;
        if(screen.activeSelf)
        {
            Time.timeScale = 0;
            score.text = nbScore.ToString();
        }

    }
}
