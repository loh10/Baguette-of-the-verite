using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetBonus : MonoBehaviour
{
    public List<Material> materials;
    public List<string> tagObject;
    string tagChoose;
    Material material;
    private void Awake()
    {
        tagChoose = tagObject[Random.Range(0,tagObject.Count)];
        this.gameObject.tag = tagChoose;
        switch(tagChoose)
        {
            case "Shield":
                material = materials[0];
                break;
            case "Rafale":
                material = materials[1];
                break;
            case "Nuke":
                material = materials[2];
                break;
        }
        this.GetComponent<MeshRenderer>().material = material;
    }
}
