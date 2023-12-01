using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int vague;
    public int ennemiSpawn;
    public float delaiSpawn;
    public List<Transform> targetsPosition;
    public Transform targetUltra;
    public GameObject ennemiPrefab,bossPrefab,Ultraprefab;
    [SerializeField] Transform parent,parentBoss,parentUltra;
    bool spawn = false;
    void Start()
    {
        StartCoroutine(Spawnning());
    }

    IEnumerator Spawnning()
    {
        if (GameObject.Find("Boss").transform.childCount == 0  && GameObject.Find("Ultra").transform.childCount == 0 && GameObject.Find("Ennemis").transform.childCount <= 3)
        {
            if (Random.Range(1, 12) == 4 && !spawn)
            {
                GameObject boss = Instantiate(bossPrefab, this.transform.position, Quaternion.identity, parentBoss);
                boss.name = "boss" + ennemiSpawn;
                ennemiSpawn++;
                boss.GetComponent<Boss>().target = targetsPosition;
                spawn = true;
            }
            if (Random.Range(1, 25) == 15 && !spawn)
            {
                GameObject ultra = Instantiate(Ultraprefab, this.transform.position, Quaternion.identity, parentUltra);
                ultra.name = "ultra" + ennemiSpawn;
                ennemiSpawn++;
                ultra.GetComponent<Ultra>().target = targetUltra;
                spawn = true;
            }
            if (!spawn)
            {
                for (int i = 0; i <= Random.Range(0, 0); i++)
                {
                    GameObject ennemi = Instantiate(ennemiPrefab, this.transform.position, Quaternion.identity, parent);
                    ennemi.name = "ennemi" + ennemiSpawn;
                    ennemiSpawn++;
                    ennemi.GetComponent<ennemi>().target = targetsPosition[Random.Range(0, targetsPosition.Count - 1)];
                    spawn = true;
                }
            }

        }
        vague++;
        yield return new WaitForSeconds(delaiSpawn);
        spawn = false;
        StartCoroutine(Spawnning());
    }
}
