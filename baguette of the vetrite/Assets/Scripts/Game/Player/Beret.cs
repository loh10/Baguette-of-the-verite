using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beret : MonoBehaviour
{
    GameObject player;
    public Material basic,shield;
    void Awake()
    {
        player = GameObject.Find("Player");
    }

    void FixedUpdate()
    {
        if(player.tag == "Player")
        {
            this.GetComponent<Renderer>().material = basic;
        }
        else
        {
            this.GetComponent<Renderer>().material = shield;
        }
    }
}
