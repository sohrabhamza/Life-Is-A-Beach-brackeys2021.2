using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowInteraction : MonoBehaviour
{
    bool isPlayer;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayer = true;
        }
    }

    private void Update()
    {
        if (isPlayer && Input.GetKeyDown(KeyCode.E))
        {
            FindObjectOfType<InventorySystemOneObject>().ThrowObject();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayer = false;
        }
    }
}
