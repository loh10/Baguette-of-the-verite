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
    public AudioSource sourceCam;
    public AudioClip death, music;
    private void Awake()
    {
        sourceCam.volume = PlayerPrefs.GetFloat("Volume", 0)-0.3f;
        sourceCam.clip = music;
        Time.timeScale = 1.0f;
    }
    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        timertxt.text = ((int)timer).ToString();
        nbScore = (int)timer + nbEnnemi;
        if(screen.activeSelf)
        {
            sourceCam.clip = death;
            sourceCam.loop = false;
            sourceCam.Play();
            Time.timeScale = 0;
            score.text = nbScore.ToString();
        }

    }
}
