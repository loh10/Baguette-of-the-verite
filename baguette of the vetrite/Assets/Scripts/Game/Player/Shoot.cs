using System.Collections;
using System.Threading;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject munition;
    public Transform parentBullet;
    int munitionIndex;
    string bonus;
    [SerializeField]float timer = 1.5f;
    public float maxTime;
    [SerializeField] int nbUseShield = 4;
    public AudioSource source,sourceSound;
    public AudioClip sound,nuke,shield;
    private void Awake()
    {
        source.volume = PlayerPrefs.GetFloat("Volume",0);
        source.clip = sound;
    }
    void Update()
    {
        bonus = GetComponent<Movement>().objet;
        timer -= Time.deltaTime;
        if(bonus!=null)
        {
            switch (bonus)
            {
                case "Shield":
                    maxTime = 1;
                    break;
                case "Rafale":
                    maxTime = 0.5f;
                    break;
                default:
                    maxTime = 1.5f;
                    break;
            }
        }
        checkObject();
        if (Input.GetKeyDown(KeyCode.Space)||Input.GetMouseButtonDown(0))
        {
            doShoot();
        }
        if ((Input.GetKey(KeyCode.LeftShift) || Input.GetMouseButton(1))&&bonus!=null)
        {
            if(bonus!=null && timer <=0)
            {
                UseObject();
            }
        }
        GetComponentInParent<Movement>().DisplayBonus(bonus);
    }
    void doShoot()
    {
        source.Play();
        GameObject bullet = Instantiate(munition,new Vector3(this.transform.position.x,0, this.transform.position.z+1),Quaternion.identity,parentBullet);
        bullet.name = "bullet "+munitionIndex;
        munitionIndex++;
    }
    void checkObject()
    {
        if(nbUseShield == 0)
        {
            GetComponent<Movement>().objet = null;
        }
    }
    void UseObject()
    {
        switch(bonus)
        {
            case "Shield":
                StartCoroutine(Shield());
                break;
            case "Rafale":
                StartCoroutine(Raffale());
                break;
            case "Nuke":
                StartCoroutine(Nuke());
                break;
            default:
                break;
        }
        timer = maxTime;
    }

    IEnumerator Shield()
    {
        nbUseShield--;
        this.gameObject.tag = "Shielded";
        sourceSound.clip = shield;
        sourceSound.Play();
        yield return new WaitForSeconds(2f);
        sourceSound.clip = null;
        this.gameObject.tag = "Player";
    }
    IEnumerator Raffale()
    {
        doShoot();
        yield return new WaitForSeconds(0.05f);
        doShoot();
        yield return new WaitForSeconds(0.05f);
        doShoot();
        yield return new WaitForSeconds(0.05f);
        doShoot();
    }
    IEnumerator Nuke()
    {
        GameObject bullet = GameObject.Find("EnnemiBullet");
        GameObject ennemi = GameObject.Find("Ennemis");
        for (int i = 0;i< bullet.transform.childCount;i++)
        {
            Destroy(bullet.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < ennemi.transform.childCount; i++)
        {
            ennemi.transform.GetChild(i).gameObject.GetComponent<ennemi>().vie = 0;
        }
        sourceSound.clip = nuke;
        sourceSound.Play();
        GetComponent<Movement>().objet = null;
        yield return new WaitForSeconds(2);
        sourceSound.clip = null;
        yield return null;
    }
}
