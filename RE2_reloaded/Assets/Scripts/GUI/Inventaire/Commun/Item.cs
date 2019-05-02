using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string type;
    public int ID;
    public Sprite icon;
    public bool pickedUp;

    // Weapons;
    public bool equipped;
    public bool playersWeapon;
    public GameObject weapon;
    public GameObject weaponManager;
    private void Start()
    {  
    }
    private void Update()
    {

    }

}
