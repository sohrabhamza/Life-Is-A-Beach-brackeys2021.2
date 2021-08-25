using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    [System.Serializable]
    public class inventorySlotInfo
    {
        public Transform slotLocation;
        public GameObject item;
        public GameObject Inicon;
    }

    [SerializeField] inventorySlotInfo[] slotInfos;

    [SerializeField] Transform cursor;
    int slotActive = 0;
    int cursorLocation = 0;
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        if (cursorLocation != slotActive)
        {
            cursor.position = slotInfos[slotActive].slotLocation.position;
            cursorLocation = slotActive;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            slotInfos[slotActive].item.SetActive(true);
            slotInfos[slotActive].item.transform.position = player.transform.position;

            Destroy(slotInfos[slotActive].Inicon);
            slotInfos[slotActive].Inicon = null;
            slotInfos[slotActive].item = null;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            slotActive = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            slotActive = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            slotActive = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            slotActive = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            slotActive = 4;
        }
    }

    public void AddToInventory(GameObject item, GameObject icon)
    {
        if (slotInfos[slotActive].item != null)
        {
            slotInfos[slotActive].item.SetActive(true);
            slotInfos[slotActive].item.transform.position = player.transform.position;

            slotInfos[slotActive].item = item;

            Destroy(slotInfos[slotActive].Inicon);
            GameObject Spawnedicon = Instantiate(icon, slotInfos[slotActive].slotLocation.position, slotInfos[slotActive].slotLocation.rotation);
            Spawnedicon.transform.SetParent(transform);
            slotInfos[slotActive].Inicon = Spawnedicon;
        }
        else
        {
            slotInfos[slotActive].item = item;

            GameObject Spawnedicon = Instantiate(icon, slotInfos[slotActive].slotLocation.position, slotInfos[slotActive].slotLocation.rotation);
            Spawnedicon.transform.SetParent(transform);
            slotInfos[slotActive].Inicon = Spawnedicon;
        }
    }
}
