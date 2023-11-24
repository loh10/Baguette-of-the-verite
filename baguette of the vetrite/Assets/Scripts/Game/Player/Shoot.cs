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
    }
    void doShoot()
    {
        GameObject bullet = Instantiate(munition,this.transform.position,Quaternion.identity,parentBullet);
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
                print("use"); 
                GetComponent<Movement>().objet = null;
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
        yield return new WaitForSeconds(2f);
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
}
