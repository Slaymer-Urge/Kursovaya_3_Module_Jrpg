using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class HUD_FIght_Script : MonoBehaviour
{
    public GameObject Empty_HUD_Def;
    public GameObject Empty_HUD_Attack;
    public GameObject Empty_HUD_Skills;
    public GameObject Empty_HUD_Items;
    public GameObject Fight_Master;
    public TMP_Text Current_Empty;
    public TMP_Text Button_Attack;
    public Image Bar_HP_1;
    public Image Bar_HP_2;
    public Image Bar_HP_3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    public void Get_DMG_Enemys(float scalee,int numberr)
    {
        if (numberr == 1) {
            Bar_HP_1.transform.localScale = new Vector3(scalee, Bar_HP_1.transform.localScale.y, Bar_HP_1.transform.localScale.z);
                }
        if (numberr == 2)
        {
            Bar_HP_2.transform.localScale = new Vector3(scalee, Bar_HP_2.transform.localScale.y, Bar_HP_2.transform.localScale.z);
        }
        if (numberr == 3)
        {
            Bar_HP_3.transform.localScale = new Vector3(scalee, Bar_HP_3.transform.localScale.y, Bar_HP_3.transform.localScale.z);
        }
    }

    public void Back_Def()
    {
        Empty_HUD_Skills.SetActive(false);
        Empty_HUD_Attack.SetActive(false);
        Empty_HUD_Items.SetActive(false);
        Empty_HUD_Def.SetActive(true);
    }

    public void QPressed()
    {
        Empty_HUD_Attack.SetActive(true);
        Empty_HUD_Def.SetActive(false);
    }

    public void Pressed1()
    {
        Button_Attack.SetText("1");
    }

    public void Pressed2()
    {
        Button_Attack.SetText("2");
    }

    public void Pressed3()
    {
        Button_Attack.SetText("3");
    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
