using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowInteraction : MonoBehaviour
{
    bool isPlayer;
    AudioSource source;
    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
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
            source.Play();
            FailState.IncreaseChaos();
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
