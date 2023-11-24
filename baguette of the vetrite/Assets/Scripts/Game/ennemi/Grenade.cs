using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    [SerializeField] private GameObject Finish;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            GameObject screen = Instantiate(Finish,Vector3.zero,Quaternion.Euler(90,0,0),GameObject.Find("Canvas").transform);
            screen.transform.localPosition = new Vector3(0,0,0);
            screen.name = "finish";
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Border")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Nade")
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), ForceMode.Impulse);
        }
        //if(collision.gameObject.tag == "Bullet")
        //{
        //    this.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), ForceMode.Impulse);
        //}
    }
}
