using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Default_HUD : MonoBehaviour
{
    public GameObject HUD_Script_Empty;
    public Image Image_Char_1;
    public Image Image_Char_2;
    public TMP_Text HP_Count_1;
    public TMP_Text HP_Count_2;
    public GameObject character_list;
    public bool locked_scan;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Image_Char_1.sprite = character_list.GetComponent<Characters_List>().characters_list[0].GetComponent<SpriteRenderer>().sprite;
        if (character_list.GetComponent<Characters_List>().characters_list[1] != null) 
        {
            Image_Char_2.sprite = character_list.GetComponent<Characters_List>().characters_list[1].GetComponent<SpriteRenderer>().sprite;
        }
    }

    IEnumerator lock_skaned()
    {
        locked_scan = true;
        yield return new WaitForSeconds(1f);
        locked_scan = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (locked_scan == false) 
        {
            string hp_count = character_list.GetComponent<Characters_List>().characters_list[0].GetComponent<Character_Script>().HP + " / " + character_list.GetComponent<Characters_List>().characters_list[0].GetComponent<Character_Script>().MaxHP;
            HP_Count_1.SetText(hp_count);
            if (character_list.GetComponent<Characters_List>().characters_list[1] != null) {
                string hp_count_1 = character_list.GetComponent<Characters_List>().characters_list[1].GetComponent<Character_Script>().HP + " / " + character_list.GetComponent<Characters_List>().characters_list[1].GetComponent<Character_Script>().MaxHP;
                HP_Count_2.SetText(hp_count_1);            
            }
            StartCoroutine(lock_skaned());
        }
    }
}
