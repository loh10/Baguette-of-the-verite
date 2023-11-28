using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    CharacterController controller;
    Vector3 movement;
    public float speed;
    public string objet;
    public Image bonusFond;
    public List<Sprite> bonusImage;
    [SerializeField] private GameObject Finish;
    public AudioClip death;
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
    private void Update()
    {
        MovementPlayer();
    }
    private void MovementPlayer()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");
        movement.x *= speed;
        movement.z *= speed;
        float speedY = -1;
        movement.y = speedY;
        movement = movement.z * forward + movement.x * right;
        controller.Move(movement * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Shield" || other.gameObject.tag == "Rafale"|| other.gameObject.tag == "Nuke")
        {   objet = other.gameObject.tag;
            Destroy(other.gameObject);
        }
        if ((other.gameObject.tag == "Nade"|| other.gameObject.tag == "Ennemi"|| other.gameObject.tag == "Boss") && this.gameObject.tag !="Shielded")
        {
            Destroy(other.gameObject);
            StartCoroutine(Death());
        }
    }

    IEnumerator Death()
    {
        Finish.SetActive(true);
        GetComponent<Shoot>().source.clip = death;
        GetComponent<Shoot>().source.Play();
        GetComponent<Shoot>().source.clip = null;
        yield return null;
    }
    public void DisplayBonus(string bonus)
    {
        int choix = 0;
        switch (bonus)
        {
            case "Shield":
                choix = 0;
                break;
            case "Rafale":
                choix = 1;
                break;
            case "Nuke":
                choix = 2;
                break;
            default: 
                choix = 3;
                break;
        }
        bonusFond.sprite = bonusImage[choix];
    }
}
