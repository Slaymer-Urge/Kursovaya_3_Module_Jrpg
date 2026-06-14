using System;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class Get_Items : MonoBehaviour
{
    public GameObject Inventory_Object;
    public bool can_get_up = true;
    public int count_effect;
    public int number_effect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player" && can_get_up) 
        {
            Inventory_Object.GetComponent<Inventory>().New_Item(this.gameObject);
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
