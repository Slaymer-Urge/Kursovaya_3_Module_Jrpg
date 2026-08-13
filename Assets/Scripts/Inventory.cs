using NUnit.Framework;
using System;
using System.Collections;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject empty_hud_inv;
    public GameObject[] Inventory_List = new GameObject[5];
    int[] Count_Item = new int[5];
    public Image[] slots_images = new Image[5];
    public TMP_Text[] counts_texts = new TMP_Text[5];
    public TMP_Text[] items_names = new TMP_Text[5];
    public TMP_Text[] items_buffs = new TMP_Text[5];
    public GameObject new_item;
    public bool Inv_Open = false;
    public bool can_use_inv = true;
    public GameObject Arrow;
    public bool use_item = false;
    public Image Icon_1;
    public Image HP_Bar_1;
    public GameObject choose_object;
    public GameObject HUD_Fight;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (int i in Count_Item)
        {
            Count_Item[i] = 0;
        }
    }
    IEnumerator Waiting_drop(GameObject obj)
    {
        yield return new WaitForSeconds(3f);
        obj.GetComponent<Get_Items>().can_get_up = true;
    }
    
    public void Drop_Item(int current_slot, Vector3 place_drop)
    {
        
        if (Count_Item[current_slot] != 0 && Count_Item[current_slot] != 1)
        {
            Count_Item[current_slot]--;
            counts_texts[current_slot].SetText(Count_Item[current_slot].ToString());    
            GameObject new_obj = Instantiate(Inventory_List[current_slot]);
            new_obj.transform.position = place_drop;
            Debug.Log("Груз сброшен");
            new_obj.GetComponent<Get_Items>().can_get_up = false;
            StartCoroutine(Waiting_drop(new_obj));
            return;
        }
        if (Count_Item[current_slot] == 1)
        {
            Count_Item[current_slot]--;
            counts_texts[current_slot].SetText("0");
            GameObject new_obj = Instantiate(Inventory_List[current_slot]);
            new_obj.transform.position = place_drop;
            new_obj.GetComponent<Get_Items>().can_get_up = false;
            StartCoroutine(Waiting_drop(new_obj));
            slots_images[current_slot].sprite = null;
            Inventory_List[current_slot] = null;
            items_buffs[current_slot].SetText("-");
            items_names[current_slot].SetText("-");
        }
    }

    public void Use_Item(int current_slot)
    {
        if (Count_Item[current_slot] != 0 && Count_Item[current_slot] != 1)
        {
            Count_Item[current_slot]--;
            counts_texts[current_slot].SetText(Count_Item[current_slot].ToString());
            return;
        }
        if (Count_Item[current_slot] == 1)
        {
            Count_Item[current_slot]--;
            counts_texts[current_slot].SetText("0");
            slots_images[current_slot].sprite = null;
            Inventory_List[current_slot] = null;
            items_buffs[current_slot].SetText("-");
            items_names[current_slot].SetText("-");
        }
    }

    public void New_Item(GameObject Item)
    {
        int i = 0;
        int[] thereisgameobj = new int[5];
        for (int j = 0; j < 5; j++) {
            if (Inventory_List[j] != null) 
            {
                if (Inventory_List[j].GetComponent<SpriteRenderer>().sprite == Item.GetComponent<SpriteRenderer>().sprite)
                {
                    Count_Item[j]++;
                    string new_num = Count_Item[j].ToString();
                    counts_texts[j].SetText(new_num);
                    return;
                }
            }
        }

        while (Count_Item[i] != 0)
        {
            i++;
            continue;
        }
        if (Count_Item[i] == 0) 
        {
            string Find_Item = "";
            for (int j = 0; j < Item.name.Length-7; j++) 
            {
                Find_Item += Item.name[j];
            }
            slots_images[i].sprite = GameObject.Find(Find_Item).GetComponent<SpriteRenderer>().sprite;
            Inventory_List[i] = GameObject.Find(Find_Item);
            Count_Item[i] += 1;
            string new_num = Count_Item[i].ToString();
            counts_texts[i].SetText(new_num);
            items_names[i].SetText(Inventory_List[i].name);
            string description_effect = "";
            description_effect += Inventory_List[i].GetComponent<Get_Items>().count_effect.ToString();
            description_effect += " ";
            description_effect += this.GetComponent<Effect_Script>().lists_effects[Inventory_List[i].GetComponent<Get_Items>().number_effect];
            items_buffs[i].SetText(description_effect);
            return;
        }
        
        
    }
    IEnumerator wait_inv_hud()
    {
        can_use_inv = false;
        yield return new WaitForSeconds(0.4f);
        can_use_inv = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (can_use_inv)
        {
            if (Keyboard.current.tKey.wasPressedThisFrame)
            {
                if (can_use_inv == true)
                {
                    if (Inv_Open == false)
                    {
                        Inv_Open = true;
                        empty_hud_inv.SetActive(true);
                        return;
                        //   StartCoroutine(wait_inv_hud());
                    }
                    if (Inv_Open == true)
                    {
                        Inv_Open = false;
                        empty_hud_inv.SetActive(false);
                        //    StartCoroutine(wait_inv_hud());
                    }
                }

            }
            if (Keyboard.current.eKey.wasPressedThisFrame && Inv_Open && Count_Item[choose_object.GetComponent<ChooseScriipt>().last_slot]>=1)
            {
                empty_hud_inv.SetActive(false);
                Inv_Open = false;
                use_item = true;
                choose_object.GetComponent<ChooseScriipt>().current_choose_char = 0; 
                Arrow.SetActive(true);
                Arrow.transform.position = new Vector2(Icon_1.transform.position.x - 90, Icon_1.transform.position.y);
                StartCoroutine(choose_object.GetComponent<ChooseScriipt>().Wait_Use_Item());
            }
            
        }
        if (Keyboard.current.eKey.wasPressedThisFrame && Inv_Open && Count_Item[choose_object.GetComponent<ChooseScriipt>().last_slot] >= 1)
        {
            empty_hud_inv.SetActive(false);
            Inv_Open = false;
            use_item = true;
            Arrow.SetActive(true);
            Arrow.transform.position = new Vector2(HP_Bar_1.transform.position.x + 110, HP_Bar_1.transform.position.y - 70);
            
            StartCoroutine(choose_object.GetComponent<ChooseScriipt>().Wait_Use_Item());
        }
        if (Keyboard.current.eKey.wasPressedThisFrame && Inv_Open && Count_Item[choose_object.GetComponent<ChooseScriipt>().last_slot] <= 0)
        {
            empty_hud_inv.SetActive(false);
            Inv_Open = false;
            use_item = false;
            HUD_Fight.GetComponent<HUD_Fight_Script>().Back_Def();
            StartCoroutine(choose_object.GetComponent<ChooseScriipt>().Wait_Use_Item());
        }
    }
}
