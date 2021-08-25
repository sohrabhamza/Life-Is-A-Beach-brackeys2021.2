using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystemOneObject : MonoBehaviour
{
    [System.Serializable]
    class inventorySlotInfo
    {
        public GameObject item;
        public GameObject icon;
        public Transform slotLocation;
    }

    [SerializeField] inventorySlotInfo slotInfo;
    public bool alertGuard;
    public bool alertNPC;

    //private
    GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))    //Yeet the object but safely (without destroying it)
        {
            slotInfo.item.SetActive(true);
            slotInfo.item.transform.position = player.transform.position;
            slotInfo.item.transform.SetParent(null);

            Destroy(slotInfo.icon);
            slotInfo.icon = null;
            slotInfo.item = null;

            alertNPC = false;
            alertGuard = false;
        }
    }

    public void PickUpObject(GameObject item, GameObject icon, bool canAlertGuard, bool canAlertNPC)
    {
        if (slotInfo.item != null)
        {
            slotInfo.item.transform.position = player.transform.position;       //Teleport item in hand to ground
            slotInfo.item.transform.SetParent(null);        //Revert partent

            slotInfo.item = item;   //Set the new item as the one in hand
            //ik this sucks but this was the easiest way. Setting position and parent
            item.transform.position = player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).position;
            item.transform.SetParent(player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform);

            Destroy(slotInfo.icon);     //Destroy current icon on screen
            GameObject Spawnedicon = Instantiate(icon, slotInfo.slotLocation.position, slotInfo.slotLocation.rotation);     //Spawn Icon
            Spawnedicon.transform.SetParent(transform);     //Set it so that its under canvas
            slotInfo.icon = Spawnedicon;    //Set the current icon as the icon spawned

            alertGuard = canAlertGuard;
            alertNPC = canAlertNPC;
        }
        else
        {
            slotInfo.item = item;
            //ik this sucks but this was the easiest way
            item.transform.position = player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).position;
            item.transform.SetParent(player.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform);

            GameObject Spawnedicon = Instantiate(icon, slotInfo.slotLocation.position, slotInfo.slotLocation.rotation);
            Spawnedicon.transform.SetParent(transform);
            slotInfo.icon = Spawnedicon;

            alertGuard = canAlertGuard;
            alertNPC = canAlertNPC;
        }
    }

    public void ThrowObject()   //Yeet the object
    {
        Destroy(slotInfo.item);
        Destroy(slotInfo.icon);
        slotInfo.icon = null;
        slotInfo.item = null;

        alertNPC = false;
        alertGuard = false;
    }
}
