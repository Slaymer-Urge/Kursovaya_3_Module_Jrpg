using UnityEngine;

public class Character_Script : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int HP;
    public int DMG_Hand;
    public int Mana;
    public bool Died = false;
    public string Type_Character;
    public GameObject Skill_Lists_Empty;
    Skills_Script_List.Skill[] Skills_Character = new Skills_Script_List.Skill[4];
    
    void Start()
    {
        Skills_Character[0] = Skill_Lists_Empty.GetComponent<Skills_Script_List>().Slide_Light;
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            Died = true;
        }
    }

    void Use_Skill(GameObject target,Skills_Script_List.Skill skill)
    {
        target.GetComponent<Character_Script>().HP -= skill.DMG;
        this.Mana -= skill.Mana_Cost;
    }
}
