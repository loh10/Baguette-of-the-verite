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
    public GameObject ennemiPrefab,bossPrefab;
    [SerializeField] Transform parent,parentBoss;
    void Start()
    {
        StartCoroutine(Spawnning());
    }

    IEnumerator Spawnning()
    {
        if (GameObject.Find("Boss").transform.childCount == 0)
        {
            for (int i = 0; i <= Random.Range(0,0); i++)
            {
                GameObject ennemi = Instantiate(ennemiPrefab, this.transform.position, Quaternion.identity, parent);
                ennemi.name = "ennemi" + ennemiSpawn;
                ennemiSpawn++;
                ennemi.GetComponent<ennemi>().target = targetsPosition[Random.Range(0, targetsPosition.Count-1)];
            }
            if (Random.Range(1, 12) == 4)
            {
                GameObject boss = Instantiate(bossPrefab, this.transform.position, Quaternion.identity, parentBoss);
                boss.name = "boss" + ennemiSpawn;
                ennemiSpawn++;
                boss.GetComponent<Boss>().target = targetsPosition;
            }
        }
        vague++;
        yield return new WaitForSeconds(delaiSpawn);
        StartCoroutine(Spawnning());
    }
}
