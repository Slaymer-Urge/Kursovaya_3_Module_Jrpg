using UnityEngine;

public class Characters_List : MonoBehaviour
{
    public GameObject[] characters_list = new GameObject[2];
    public GameObject[] Spawn_Emptys = new GameObject[2];
    public GameObject Camera;
    public GameObject Player;
    public GameObject Inv_Empty;
    public GameObject Fight_Emp;
    string effects = "0 - хилл, 1 - мана";
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
                }
                else
                {
                    characters_list[number_char].GetComponent<Character_Script>().HP += item.GetComponent<Get_Items>().count_effect;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
