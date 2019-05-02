using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slots : MonoBehaviour , IPointerClickHandler
{
    //ouverture sous-menus
    public GameObject weaponOptions;
    public GameObject classicOptions;
    private GameObject weaponOp;
    private GameObject classicOp;
    public bool isWeapon;
    public Vector3 optionPosition;

    //Parametre Item
    public string type;
    public int ID;
    public bool empty;
    public Sprite icon;
    public GameObject item;
    
    public void OnPointerClick (PointerEventData pointerEventData)
    {
 
    }

    public void EchapWeapon()
    {
        Destroy(weaponOp.gameObject);
    }

    public void EchapClassic()
    {
        Destroy(classicOp.gameObject);
    }

    public void Combine()
    {
        Debug.Log("Combiner");
    }

    public void Throw()
    {
        Debug.Log("Jetter");
    }

    public void Use()
    {
    }

    public void Equip()
    {
        Debug.Log("Equiper");
    }

    public void OpenObjectMenu()
    {
        if (empty == false)
        {
            if (isWeapon == true)
            {
                Debug.Log("hihi");
                if (weaponOp != null) return;
                weaponOp = Instantiate(weaponOptions, Vector3.zero, Quaternion.identity) as GameObject;
                weaponOp.transform.SetParent(Global.inventoryMenu.transform);

                RectTransform weaponTranform = weaponOp.GetComponent<RectTransform>();
                weaponTranform.localPosition = transform.position + optionPosition;
            }
            else if (isWeapon == false)
            {
                Debug.Log("hihi");

                if (classicOp != null) return;
                classicOp = Instantiate(classicOptions, Vector3.zero, Quaternion.identity) as GameObject;
                classicOp.transform.SetParent(Global.inventoryMenu.transform);

                RectTransform classicTranform = classicOp.GetComponent<RectTransform>();
                classicTranform.localPosition = transform.position + optionPosition;
            }
        }
        else
        {
            Debug.Log("la case est vide");
            return;
        }
    }

    public void updateSlot()
    {
        this.GetComponent<Image>().sprite = icon;
    }

}
