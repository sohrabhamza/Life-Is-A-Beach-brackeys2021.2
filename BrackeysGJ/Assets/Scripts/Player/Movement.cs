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
    Animator animator;
    Vector3 moveDir;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        animator.SetFloat("Horizontal", Mathf.Clamp(controller.velocity.magnitude, 0, 1));
        if (controller.velocity != Vector3.zero)
        {
            Vector3 dirToRot = transform.position - transform.position + controller.velocity;
            Quaternion angleToRot = Quaternion.LookRotation(dirToRot, Vector3.up);
            body.transform.rotation = Quaternion.Lerp(body.transform.rotation, angleToRot, Time.deltaTime * rotationSpeed);
            body.transform.eulerAngles = new Vector3(0, body.transform.eulerAngles.y, 0);
        }
    }
    private void FixedUpdate()
    {
        controller.Move(moveDir * speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, 0.4f, transform.position.z);
    }
}
