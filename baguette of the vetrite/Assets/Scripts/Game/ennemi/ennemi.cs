using System.Collections;
using UnityEngine;

public class ennemi : MonoBehaviour
{
    [SerializeField]public int vie = 100;
    public Transform target;
    public GameObject munition;
    int nbnade;
    public float firerate;
    public float rotaSpeed;
    float rota;
    Transform parent;
    public GameObject bonus;
    private void Awake()
    {
        parent = GameObject.Find("EnnemiBullet").GetComponent<Transform>();
        StartCoroutine(Attack());
    }

    void Update()
    {
        if(vie <= 0)
        {
            int rndm = Random.Range(0, 5);
            if (rndm == 4)
            {
                GameObject bonusObj = Instantiate(bonus,this.transform.position,Quaternion.identity,GameObject.Find("Object").transform);
                bonusObj.GetComponent<Rigidbody>().velocity = Vector3.back*4;
                bonusObj.name = "BONUS";
            }
            Destroy(this.gameObject);
        }
        this.gameObject.transform.position = Vector3.Lerp(this.transform.position, target.transform.position, Time.deltaTime);
        this.gameObject.transform.rotation = Quaternion.Euler(0, (rota += Time.deltaTime)*rotaSpeed, 0);
    }

    IEnumerator Attack()
    {
        GameObject nade = Instantiate(munition, this.transform.position, transform.rotation, parent);
        nade.name = "| munition " +nbnade;
        nbnade++;
        nade.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-10,10),0, Random.Range(-10, 10)));
        yield return new WaitForSeconds(firerate);
        StartCoroutine(Attack());
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            vie -= 25;
        }
    }
}
