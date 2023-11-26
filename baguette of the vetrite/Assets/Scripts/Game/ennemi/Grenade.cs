using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        
        if (collision.gameObject.tag == "Border")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Nade")
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), ForceMode.Impulse);
        }
        if (collision.gameObject.tag == "Shielded")
        {
            Destroy(this.gameObject);
        }
        //if(collision.gameObject.tag == "Bullet")
        //{
        //    this.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), ForceMode.Impulse);
        //}
    }
}
