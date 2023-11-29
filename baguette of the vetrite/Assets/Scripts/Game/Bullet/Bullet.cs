using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    GameManager bulletManager;
    public Vector3 dir;
    Vector3 velocity;
    private void Awake()
    {
        dir = new Vector3 (0, 0, 1);
        bulletManager = GameObject.Find("BulletManager").GetComponent< GameManager>();
    }
    void Update()
    {
        GetComponent<Rigidbody>().velocity = dir * 20;
        velocity = GetComponent<Rigidbody>().velocity;
        transform.rotation = Quaternion.LookRotation(velocity);
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
