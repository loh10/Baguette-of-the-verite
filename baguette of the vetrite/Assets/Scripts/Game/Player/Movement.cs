using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Movement : MonoBehaviour
{
    CharacterController controller;
    Vector3 movement;
    public float speed;
    public string objet;
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
        if (other.gameObject.tag == "Shield")
        {   objet = other.gameObject.tag;
            Destroy(other.gameObject);
        }
    }
}
