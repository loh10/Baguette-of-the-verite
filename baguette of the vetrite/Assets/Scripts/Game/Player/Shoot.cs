using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject munition;
    public Transform parentBullet;
    int munitionIndex;
    string bonus;

    void Update()
    {
        bonus = GetComponent<Movement>().objet;
        if (Input.GetKeyDown(KeyCode.Space)||Input.GetMouseButtonDown(0))
        {
            doShoot();
        }
        if ((Input.GetKeyDown(KeyCode.LeftShift) || Input.GetMouseButtonDown(1))&&bonus!=null)
        {
            if(bonus!=null)
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
    void UseObject()
    {
        switch(bonus)
        {
            case "Shield":
                print("use");
                break;
            default:
                break;
        }
    }
}
