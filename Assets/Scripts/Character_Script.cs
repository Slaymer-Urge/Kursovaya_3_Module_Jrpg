using UnityEngine;

public class Character_Script : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float HP;
    public float MaxHP;
    public float DMG_Hand;
    public int Mana;
    public bool Died = false;
    public string Type_Character;
    public GameObject Skill_Lists_Empty;
    public Skills_Script_List.Skill[] Skills_Character = new Skills_Script_List.Skill[4];
    public GameObject object_attack;
    
    void Start()
    {
        Skills_Character[0] = Skill_Lists_Empty.GetComponent<Skills_Script_List>().Slide_Light;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Use_Skill(GameObject target,Skills_Script_List.Skill skill)
    {
        target.GetComponent<Character_Script>().HP -= skill.DMG;
        this.Mana -= skill.Mana_Cost;
    }
}
