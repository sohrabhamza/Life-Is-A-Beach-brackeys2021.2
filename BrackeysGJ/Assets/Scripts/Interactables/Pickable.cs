using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    [SerializeField] GameObject icon;
    bool isPlayer;
    [SerializeField] bool canAlertGuard;[SerializeField] bool canAlertNPC;

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
            FindObjectOfType<InventorySystemOneObject>().PickUpObject(this.gameObject, icon, canAlertGuard, canAlertNPC);
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
