using UnityEngine;

public class Characters_List : MonoBehaviour
{
    public GameObject[] characters_list = new GameObject[2];
    public GameObject[] Spawn_Emptys = new GameObject[2];
    public GameObject Camera;
    public GameObject Player;
    public GameObject Inv_Empty;
    public GameObject Fight_Emp;
    public GameObject HUD_Fight;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 

    }

    public void Use_Item_On_Char(GameObject item, int number_char)
    {
        if (item != null)
        {
            if (item.GetComponent<Get_Items>().number_effect == 0)
            {
                if (characters_list[number_char].GetComponent<Character_Script>().HP + item.GetComponent<Get_Items>().count_effect >= characters_list[number_char].GetComponent<Character_Script>().MaxHP)
                {
                    characters_list[number_char].GetComponent<Character_Script>().HP = characters_list[number_char].GetComponent<Character_Script>().MaxHP;
                    StartCoroutine(HUD_Fight.GetComponent<HUD_Fight_Script>().Get_DMG_Enemys(1, number_char + 4));
                }
                else
                {
                    characters_list[number_char].GetComponent<Character_Script>().HP += item.GetComponent<Get_Items>().count_effect;
                    
                    StartCoroutine(HUD_Fight.GetComponent<HUD_Fight_Script>().Get_DMG_Enemys(characters_list[number_char].GetComponent<Character_Script>().HP / characters_list[number_char].GetComponent<Character_Script>().MaxHP, number_char + 4));
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
