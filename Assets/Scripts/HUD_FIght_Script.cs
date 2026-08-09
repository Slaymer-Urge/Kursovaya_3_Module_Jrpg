using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class HUD_Fight_Script : MonoBehaviour
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
    public Image Bar_HP_4;
    public Image Bar_HP_5;
    public GameObject[] HP_Bars_Emptys = new GameObject[5];
    public GameObject Inv_obj;
    public GameObject Inv_HUD_Empty;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }


    public void Start_Fight(int count_enemys)
    {
        HP_Bars_Emptys[3].SetActive(true);
        HP_Bars_Emptys[4].SetActive(true);
        if (count_enemys == 1)
        {
            HP_Bars_Emptys[0].SetActive(true);

        }
        if (count_enemys == 2)
        {

            HP_Bars_Emptys[0].SetActive(true);
            HP_Bars_Emptys[1].SetActive(true);
        }
        if (count_enemys == 3)
        {
            HP_Bars_Emptys[0].SetActive(true);
            HP_Bars_Emptys[1].SetActive(true);
            HP_Bars_Emptys[2].SetActive(true);
        }
    }

    public IEnumerator Get_DMG_Enemys(float scalee,int numberr)
    {
        yield return new WaitForSeconds(1f);
        if (numberr == 4)
        {
            Bar_HP_4.transform.localScale = new Vector3(scalee, Bar_HP_4.transform.localScale.y, Bar_HP_4.transform.localScale.z);
        }
        if (numberr == 5)
        {
            Bar_HP_5.transform.localScale = new Vector3(scalee, Bar_HP_5.transform.localScale.y, Bar_HP_4.transform.localScale.z);
        }
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
        if (scalee == 0 && numberr == 1)
        {
            HP_Bars_Emptys[0].SetActive(false);
        }
        if (scalee == 0 && numberr == 2)
        {
            HP_Bars_Emptys[1].SetActive(false);
        }
        if (scalee == 0 && numberr == 3)
        {
            HP_Bars_Emptys[2].SetActive(false);
        }
        if (scalee == 0 && numberr == 4)
        {
            HP_Bars_Emptys[3].SetActive(false);
        }
        if (scalee == 0 && numberr == 5)
        {
            HP_Bars_Emptys[4].SetActive(false);
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
        Button_Attack.SetText("1");
    }

    public void TPressed()
    {
        Empty_HUD_Items.SetActive(true);
        Empty_HUD_Def.SetActive(false);
        Inv_obj.GetComponent<Inventory>().Inv_Open = true;

        Inv_HUD_Empty.SetActive(true);
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
