using System.Collections;
using UnityEngine;

public class ennemi : MonoBehaviour
{
    [SerializeField]int vie = 100;
    public Transform target;
    public GameObject munition;
    int nbnade;
    public float firerate;
    public float rotaSpeed;
    float rota;
    Transform parent;
    private void Awake()
    {

        parent = GameObject.Find("Bullet").GetComponent<Transform>();
    }
    private void Start()
    {
        StartCoroutine(Attack());
    }

    void Update()
    {
        if(vie == 0)
        {
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
        if (collision.gameObject.tag == "Ennemi")
        {
            print("&");
        }
    }
}
