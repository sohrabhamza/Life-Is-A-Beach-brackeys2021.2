using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignInteraction : MonoBehaviour
{
    [SerializeField] Transform signBody;

    //private 
    bool playerNear;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = true;
        }
    }
    private void Update()
    {
        if (playerNear)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                signBody.eulerAngles = new Vector3(0, 0, signBody.eulerAngles.z == 0 ? 180 : 0);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        playerNear = false;
    }
}
