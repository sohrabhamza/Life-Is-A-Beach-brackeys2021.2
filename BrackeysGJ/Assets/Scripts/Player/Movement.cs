using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //public 
    [SerializeField] float speed = .5f;
    [SerializeField] float rotationSpeed = 10;
    [SerializeField] Transform body;
    //private
    CharacterController controller;
    Vector3 moveDir;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    private void Update()
    {
        moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        if (controller.velocity != Vector3.zero)
        {
            Vector3 dirToRot = transform.position - transform.position + controller.velocity;
            Quaternion angleToRot = Quaternion.LookRotation(dirToRot, Vector3.up);
            body.transform.rotation = Quaternion.Lerp(body.transform.rotation, angleToRot, Time.deltaTime * rotationSpeed);
        }
    }
    private void FixedUpdate()
    {
        controller.Move(moveDir * speed * Time.deltaTime);
    }
}
