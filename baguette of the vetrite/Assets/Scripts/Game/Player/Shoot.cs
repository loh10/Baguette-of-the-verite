using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject munition;
    public Transform parentBullet;
    int munitionIndex;
    string bonus;
    [SerializeField]float timer = 1.5f;
    public float maxTime;
    [SerializeField] int use;
    public AudioSource source,sourceSound;
    public AudioClip sound,nuke,shield;
    Movement movement;
    public List<Vector3> direction;
    public Vector3 chooseDir;
    private void Awake()
    {
        movement = GetComponent<Movement>();
        source.volume = PlayerPrefs.GetFloat("Volume",0);
        sourceSound.volume = PlayerPrefs.GetFloat("Volume", 0);
        source.clip = sound;
    }
    void Update()
    {
        if(movement.newObj)
        {
            bonus = movement.objet;
            use = movement.nbUse;
            movement.newObj = false;
        }
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
                case "Shotgun":
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
            doShoot(direction[0]);
        }
        if ((Input.GetKey(KeyCode.LeftShift) || Input.GetMouseButton(1))&&bonus!=null)
        {
            if(bonus!=null && timer <=0)
            {
                UseObject();
            }
        }
        movement.DisplayBonus(bonus);
    }
    void doShoot(Vector3 direction)
    {
        source.Play();
        GameObject bullet = Instantiate(munition,new Vector3(this.transform.position.x,0, this.transform.position.z+1),Quaternion.identity,parentBullet);
        bullet.GetComponent<Bullet>().dir = direction;
        bullet.name = "bullet "+munitionIndex;
        munitionIndex++;
    }
    void checkObject()
    {
        if(use == 0)
        {
            movement.objet = null;
            bonus = null;
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
            case "Shotgun":
                StartCoroutine(Shotgun());
                break;
            default:
                break;
        }
        timer = maxTime;
    }

    IEnumerator Shield()
    {
        use--;
        this.gameObject.tag = "Shielded";
        sourceSound.clip = shield;
        sourceSound.Play();
        yield return new WaitForSeconds(2f);
        sourceSound.clip = null;
        this.gameObject.tag = "Player";
    }
    IEnumerator Raffale()
    {
        doShoot(direction[0]);
        yield return new WaitForSeconds(0.05f);
        doShoot(direction[0]);
        yield return new WaitForSeconds(0.05f);
        doShoot(direction[0]);
        yield return new WaitForSeconds(0.05f);
        doShoot(direction[0]);
    }
    IEnumerator Shotgun()
    {
        use--;
        doShoot(direction[0]);
        doShoot(direction[1]);
        doShoot(direction[2]);
        doShoot(direction[3]);
        doShoot(direction[4]);
        yield return new WaitForSeconds(0.05f);
    }
    IEnumerator Nuke()
    {
        use--;
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
        yield return new WaitForSeconds(2);
        sourceSound.clip = null;
        yield return null;
    }
}
