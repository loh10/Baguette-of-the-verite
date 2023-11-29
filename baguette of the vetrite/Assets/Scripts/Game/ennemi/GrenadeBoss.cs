 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBoss : MonoBehaviour
{
    public float baseTime;
    float timeBeforeExplosion;
    public GameObject rayon, nade;
    public AudioClip explode;
    AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        source.volume = PlayerPrefs.GetFloat("Volume", 0);
        source.clip = explode;
        timeBeforeExplosion = baseTime;
    }
    void FixedUpdate()
    {
        timeBeforeExplosion -= Time.deltaTime;
        if (timeBeforeExplosion < 0 )
        {
            StartCoroutine(Explosion());
            timeBeforeExplosion = baseTime;
        }
    }
    IEnumerator Explosion()
    {
        source.Play();
        this.GetComponent<Rigidbody>().velocity = Vector3.zero;
        rayon.SetActive(true);
        GameObject grenade1 = Instantiate(nade,this.transform.position,this.transform.rotation,GameObject.Find("EnnemiBullet").GetComponent<Transform>());
        grenade1.GetComponent<Rigidbody>().velocity = Vector3.back;
        GameObject grenade2 = Instantiate(nade, this.transform.position, this.transform.rotation,GameObject.Find("EnnemiBullet").GetComponent<Transform>());
        grenade2.GetComponent<Rigidbody>().velocity = Vector3.right;
        GameObject grenade3 = Instantiate(nade, this.transform.position, this.transform.rotation,GameObject.Find("EnnemiBullet").GetComponent<Transform>());
        grenade3.GetComponent<Rigidbody>().velocity = Vector3.left;
        GameObject grenade4 = Instantiate(nade, this.transform.position, this.transform.rotation,GameObject.Find("EnnemiBullet").GetComponent<Transform>());
        grenade4.GetComponent<Rigidbody>().velocity = Vector3.up;
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Shielded")
        {
            Destroy(this.gameObject);
        }        
    }
    
}
