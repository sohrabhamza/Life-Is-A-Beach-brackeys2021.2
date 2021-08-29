using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropsRandomizer : MonoBehaviour
{
    [SerializeField] GameObject[] pickables;

    private void Start()
    {
        foreach (GameObject thing in pickables)
        {
            thing.SetActive(false);
        }

        pickables[Random.Range(0, pickables.Length)].SetActive(true);
    }
}
