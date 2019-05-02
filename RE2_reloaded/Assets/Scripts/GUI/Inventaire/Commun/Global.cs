using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{
    public static GameObject inventoryMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        inventoryMenu = GameObject.Find("MenuInventory");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
