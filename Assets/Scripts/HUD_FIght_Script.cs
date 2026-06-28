using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class HUD_FIght_Script : MonoBehaviour
{
    public GameObject Empty_HUD_Def;
    public GameObject Empty_HUD_Attack;
    public GameObject Empty_HUD_Skills;
    public GameObject Empty_HUD_Items;
    public GameObject Fight_Master;
    public TMP_Text Current_Empty;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.qKey.isPressed)
        {
            Empty_HUD_Def.SetActive(false);
            Empty_HUD_Attack.SetActive(true);
        }
        string current_enemy = "Выбранный Враг: " + Fight_Master.GetComponent<Fight_Script>().current_enemy.ToString();
        Current_Empty.SetText(current_enemy);
    }
}
