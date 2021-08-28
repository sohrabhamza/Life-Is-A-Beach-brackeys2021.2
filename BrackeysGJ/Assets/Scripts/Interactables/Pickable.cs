using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    [SerializeField] GameObject icon;
    bool isPlayer;
    [SerializeField] bool canAlertGuard;[SerializeField] bool canAlertNPC;

    [SerializeField] GameObject prompt;
    bool isPicked = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayer = true;
            if (!isPicked)
            { prompt.SetActive(true); }
        }
    }

    private void Update()
    {
        if (isPlayer && Input.GetKeyDown(KeyCode.E))
        {
            FindObjectOfType<InventorySystemOneObject>().PickUpObject(this.gameObject, icon, canAlertGuard, canAlertNPC);
            isPicked = true;
            prompt.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayer = false;
            prompt.SetActive(false);
            isPicked = false;
        }
    }
}
