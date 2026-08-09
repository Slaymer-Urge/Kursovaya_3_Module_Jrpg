using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Lost_HUD_Script : MonoBehaviour
{
    public GameObject Fight_Script_Empty;
    public GameObject HUD_Script_Empty;
    public Image Image_Char_1;
    public Image Image_Char_2;
    public TMP_Text HP_Count_1;
    public TMP_Text HP_Count_2;
    public Image Image_Anim_Lose;
    float limit = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void Lose_Func()
    {
        HUD_Script_Empty.gameObject.SetActive(true);
        Image_Char_1.sprite = Fight_Script_Empty.GetComponent<Fight_Script>().characters_list[0].GetComponent<SpriteRenderer>().sprite;
        if (Fight_Script_Empty.GetComponent<Fight_Script>().characters_list[1] != null)
        {
            Image_Char_2.sprite = Fight_Script_Empty.GetComponent<Fight_Script>().characters_list[1].GetComponent<SpriteRenderer>().sprite;
            string HP_Count1 = Fight_Script_Empty.GetComponent<Fight_Script>().characters_list[1].GetComponent<Character_Script>().HP.ToString() + " / " + Fight_Script_Empty.GetComponent<Fight_Script>().characters_list[1].GetComponent<Character_Script>().MaxHP.ToString();
            HP_Count_2.SetText(HP_Count1);
        }
        string HP_Count = Fight_Script_Empty.GetComponent<Fight_Script>().characters_list[0].GetComponent<Character_Script>().HP.ToString() + " / " + Fight_Script_Empty.GetComponent<Fight_Script>().characters_list[0].GetComponent<Character_Script>().MaxHP.ToString();
        HP_Count_1.SetText(HP_Count);

    }

    public void Press_Button()
    {
        HUD_Script_Empty.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (HUD_Script_Empty.activeSelf == true && limit < 20)
        {
            Image_Anim_Lose.transform.localScale = new Vector3(Image_Anim_Lose.transform.localScale.x + 0.04f, Image_Anim_Lose.transform.localScale.y, Image_Anim_Lose.transform.localScale.z);
            limit += 0.04f;
        }
    }
}
