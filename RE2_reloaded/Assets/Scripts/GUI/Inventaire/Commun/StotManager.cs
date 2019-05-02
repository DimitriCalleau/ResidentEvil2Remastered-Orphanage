using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StotManager : MonoBehaviour
{
    //ca morche
    public GameObject Slot;
    private GameObject currentSlot;
    public bool sacoche;
    public int slotCount = 1;
    //jsp
    private int allSlots;
    private int enableSlots;
    private GameObject[]slots;
    public GameObject slotsHolder;
    public GameObject player;
       
    public void Start()
    {
        allSlots = 8;
        slots = new GameObject[allSlots];
        for(int i = 0; i < allSlots; i++)
        {
            slots[i] = slotsHolder.transform.GetChild(i).gameObject;
            if (slots[i].GetComponent<Slots>().item == null)
            {
                slots[i].GetComponent<Slots>().empty = true;
            }
        }
    }

    private void Update()
    {

        if (sacoche == true)
        {
            addSlot();
            sacoche = false;
        }

    }

    void addSlot()
    {
        for (int i = 0; i < 1; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                currentSlot = Instantiate(Slot, Vector3.zero, Quaternion.identity);
                currentSlot.transform.SetParent(slotsHolder.transform);
                allSlots += 2;
            }
        }
    }
    void AddItem(int itemID, string itemType, Sprite itemIcon, GameObject itemObject)
    {
        for(int i =0; i <  allSlots; i++)
        {
            if (slots[i].GetComponent<Slots>().empty)
            {
                itemObject.GetComponent<Item>().pickedUp = true;

                slots[i].GetComponent<Slots>().item = itemObject;
                slots[i].GetComponent<Slots>().icon = itemIcon;
                slots[i].GetComponent<Slots>().type = itemType;
                slots[i].GetComponent<Slots>().ID = itemID;

                itemObject.transform.parent = slots[i].transform;
                itemObject.SetActive(false);

                slots[i].GetComponent<Slots>().updateSlot();

                slots[i].GetComponent<Slots>().empty = false;

            }
            return;
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("Item"))
        {
            Debug.Log("prends l'object avec f ");
            if (Input.GetKey(KeyCode.F))
            { 
                GameObject pickable = other.gameObject;
                Item item = pickable.GetComponent<Item>();

                AddItem(item.ID, item.type, item.icon, pickable);
            }
        }
    }
}
