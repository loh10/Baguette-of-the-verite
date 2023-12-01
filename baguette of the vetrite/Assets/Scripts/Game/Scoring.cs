using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    public Text highscore,nbScore;
    public int high;
    public int scoreAct = 0;
    [SerializeField]GameObject finish;
    private void Awake()
    {
        high = PlayerPrefs.GetInt("high");
    }
    private void Update()
    {
        if (finish.activeSelf)
        {
            scoreAct = int.Parse(nbScore.text);
            if(scoreAct > high)
            {
                high = scoreAct;
            }
            highscore.text = high.ToString();
            PlayerPrefs.SetInt("high", high);
        }
    }
}
