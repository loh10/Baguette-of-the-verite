using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int vague;
    public int ennemiSpawn;
    public float delaiSpawn;
    public List<Transform> targetsPosition;
    public GameObject ennemiPrefab;
    [SerializeField] Transform parent;
    void Start()
    {
        StartCoroutine(Spawnning());
    }

    IEnumerator Spawnning()
    {
        for(int i = 0; i < Random.Range(1,4); i++)
        {
            GameObject ennemi = Instantiate(ennemiPrefab, this.transform.position, Quaternion.identity, parent);
            ennemi.name = "ennemi"+ennemiSpawn;
            ennemiSpawn++;
            ennemi.GetComponent<ennemi>().target = targetsPosition[Random.Range(0, targetsPosition.Count)];
        }
        vague++;
        yield return new WaitForSeconds(delaiSpawn);
        StartCoroutine(Spawnning());
    }
}
