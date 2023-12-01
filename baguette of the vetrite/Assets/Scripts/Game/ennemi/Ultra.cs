using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Ultra : MonoBehaviour
{
    [SerializeField]public int vie = 1000;
    public Transform target;
    public GameObject BG, BD,barredevie;
    public float firerate;
    public float rotaSpeed;
    float rota;
    public GameObject bonus;
    public Slider life;
    [SerializeField] Vector3 posHp;
    private void Awake()
    {
        target = GameObject.Find("TUltra").GetComponent<Transform>();
        GameObject hp = Instantiate(barredevie, GameObject.Find("Life").transform.position, GameObject.Find("Life").transform.rotation, GameObject.Find("Life").transform);
        life = hp.GetComponent<Slider>();
        life.maxValue = vie;
    }
    private void Start()
    {
        StartCoroutine(Attack());
    }
    void Update()
    {
        life.value = vie;
        if(vie <= 0)
        {
            Destroy(life.gameObject);
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
