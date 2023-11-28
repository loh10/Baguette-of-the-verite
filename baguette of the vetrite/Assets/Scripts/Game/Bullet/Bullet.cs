using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    GameManager bulletManager;
    private void Awake()
    {
        bulletManager = GameObject.Find("BulletManager").GetComponent< GameManager>();
    }
    void Update()
    {
        GetComponent<Rigidbody>().velocity = Vector3.forward * 20;
    }
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Ennemi")
        {
            Destroy(this.gameObject);
            bulletManager.nbEnnemi++;
        }
        if (collision.gameObject.tag == "Boss")
        {
            Destroy(this.gameObject);
            bulletManager.nbEnnemi++;
        }
        if (collision.gameObject.tag == "Border")
        {
            Destroy(this.gameObject);
        }
    }
}
