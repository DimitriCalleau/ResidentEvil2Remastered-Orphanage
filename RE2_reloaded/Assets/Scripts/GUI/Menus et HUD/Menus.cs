using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menus : MonoBehaviour
{
    //Les différents menus.
    public GameObject Map;
    public GameObject Inventory;
    public GameObject InventoryMenu;
    public GameObject List;
    public GameObject MenuEchap;

    //Quel menu est actif
    public bool echap = false;
    public bool inventorymenu = false;
    public bool inventory = false;
    public bool map = false;
    public bool list = false;

   
    void Start()
    {
        //On desactive tous les menus
        Map.SetActive(false);
        Inventory.SetActive(false);
        InventoryMenu.SetActive(false);
        List.SetActive(false);
        MenuEchap.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Sur quelle touche on a appuyé
        if (Input.GetKeyDown(KeyCode.Tab) && map == false && list == false && echap == false)
        {
            inventorymenu = !inventorymenu;
        }
        if (Input.GetKeyDown(KeyCode.LeftControl) && inventorymenu == false && list == false && echap == false)
        {
            map = !map;
        }
        if (Input.GetKeyDown(KeyCode.J) && map == false && inventorymenu == false && echap == false)
        {
            list = !list;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && map == false && inventorymenu == false && list == false)
        {
            echap = !echap;
        }

        //Ouverture des menus
        if (echap == true)
        {
            Time.timeScale = 0;
            MenuEchap.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
        if (inventorymenu == true)
        {
            Time.timeScale = 0;
            InventoryMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
        if (inventory == true)
        {
            Time.timeScale = 0;
            Inventory.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
        if (list == true)
        {
            Time.timeScale = 0;
            List.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
        if (map == true)
        {
            Time.timeScale = 0;
            Map.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
        //Fermeture des menus
        if ( (map == false && inventorymenu == false && list == false && echap == false && inventory == false))
        {
            Time.timeScale = 1;
            Map.SetActive(false);
            Inventory.SetActive(false);
            InventoryMenu.SetActive(false);
            List.SetActive(false);
            MenuEchap.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (Input.GetMouseButtonDown(1) && (map == true || inventorymenu == true || list == true || inventory == true))
        {
            Time.timeScale = 1;
            Map.SetActive(false);
            Inventory.SetActive(false);
            InventoryMenu.SetActive(false);
            List.SetActive(false);
            map = false;
            inventorymenu = false;
            list = false;
            inventory = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    /*public void RightArrow()
    {
        if (map == true)
        {
            map = !map;
            Map.SetActive(false);
            inventorymenu = !inventorymenu;
            InventoryMenu.SetActive(true);
        }
        if (inventorymenu == true)
        {
            inventorymenu = !inventorymenu;
            InventoryMenu.SetActive(false);
            list = !list;
            List.SetActive(true);
        }
        if (list == true)
        {
            list = !list;
            List.SetActive(false);
            map = !map;
            Map.SetActive(true);
        }
    }
    public void LeftArrow()
    {
        if (map == true)
        {
            map = !map;
            Map.SetActive(false);
            list = !list;
            List.SetActive(true);
        }
        if (list == true)
        {
            list = !list;
            List.SetActive(false);
            inventorymenu = !inventorymenu;
            InventoryMenu.SetActive(true);
        }
        if (inventorymenu == true)
        {
            inventorymenu = !inventorymenu;
            InventoryMenu.SetActive(false);
            map = !map;
            Map.SetActive(true);
        }
    }*/


}
