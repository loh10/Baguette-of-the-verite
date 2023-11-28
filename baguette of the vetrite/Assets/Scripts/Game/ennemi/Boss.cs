using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField]public int vie = 500;
    public List<Transform> target;
    int targetChoose;
    public GameObject munition;
    int nbnade;
    public float firerate;
    public float rotaSpeed;
    float rota;
    Transform parent;
    public GameObject bonus;
    public int speed;
    AudioSource source;
    public AudioClip clip,death;
    bool alive = true;
    private void Awake()
    {
        
        source = GetComponent<AudioSource>();
        source.volume = PlayerPrefs.GetFloat("Volume", 0);
        source.clip = clip;
        parent = GameObject.Find("EnnemiBullet").GetComponent<Transform>();
    }
    private void Start()
    {
        StartCoroutine(Attack());
        StartCoroutine(Move());
    }

    void FixedUpdate()
    {
        if(vie <= 0 && alive)
        {
            StartCoroutine(Death());
        }
        this.gameObject.transform.position = Vector3.Lerp(this.transform.position, target[targetChoose].position, Time.deltaTime*speed);
        this.gameObject.transform.rotation = Quaternion.Euler(0, (rota += Time.deltaTime)*rotaSpeed, 0);
    }

    IEnumerator Attack()
    {
        source.Play();
        GameObject nade = Instantiate(munition,this.transform.position, Quaternion.Euler(Vector3.zero), parent);
        nade.name = "| munition " +nbnade;
        nbnade++;
        yield return new WaitForSeconds(firerate);
        StartCoroutine(Attack());
    }
    IEnumerator Move()
    {
        targetChoose = Random.Range(0, target.Count);
        yield return new WaitForSeconds(1f);
        StartCoroutine(Move());
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            vie -= 25;
        }
    }
    IEnumerator Death()
    {
        alive = false;
        source.clip = death;
        source.Play();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
        GameObject bonusObj = Instantiate(bonus, this.transform.position, Quaternion.identity, GameObject.Find("Object").transform);
        bonusObj.GetComponent<Rigidbody>().velocity = Vector3.back * 4;
        bonusObj.name = "BONUS";
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }
}
