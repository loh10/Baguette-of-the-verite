using System.Collections;
using UnityEngine;

public class Ultra : MonoBehaviour
{
    [SerializeField]public int vie = 1000;
    public Transform target;
    public GameObject BG,BD;
    public float firerate;
    public float rotaSpeed;
    float rota;
    public GameObject bonus;
    private void Awake()
    {
        target = GameObject.Find("TUltra").GetComponent<Transform>();
    }
    private void Start()
    {
        StartCoroutine(Attack());
    }
    void Update()
    {
        if(vie <= 0)
        {
            Destroy(this.gameObject);
        }
        this.gameObject.transform.position = Vector3.Lerp(this.transform.position, target.transform.position, Time.deltaTime);
        this.gameObject.transform.rotation = Quaternion.Euler(0, (rota += Time.deltaTime)*rotaSpeed, 0);
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(firerate);
        BG.SetActive(true);
        BD.SetActive(true);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            vie -= 25;
        }
    }
}
