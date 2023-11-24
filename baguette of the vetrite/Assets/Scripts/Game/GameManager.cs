using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    GameObject screen;
    Text timertxt,score;
    float timer;
    public int nbEnnemi;
    private void Awake()
    {
        Time.timeScale = 1.0f;
    }
    private void Start()
    {
        timertxt = GameObject.Find("Timer").GetComponent<Text>();
    }
    private void Update()
    {
        timer += Time.deltaTime;
        timertxt.text = ((int)timer).ToString();
        try
        {
            screen = GameObject.Find("finish");                                                                                                                                                                                                                                                                                                
        }
        finally
        {
            
        }
        if(screen != null)
        {
            Time.timeScale = 0;
            score = GameObject.Find("nbScore").GetComponent<Text>();
            score.text = ((int)(((timer+nbEnnemi) * (nbEnnemi+1))/timer)).ToString();
        }

    }
}
