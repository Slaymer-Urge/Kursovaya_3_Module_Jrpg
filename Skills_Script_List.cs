using UnityEngine;

public class Skills_Script_List : MonoBehaviour
{


    public class Skill
    {
        public int DMG;
        public int Mana_Cost;
        public Skill(int DMG, int Mana_Cost)
        {
            this.DMG = DMG;
            this.Mana_Cost = Mana_Cost;
        }
    }

    public Skill Slide_Light = new Skill(50, 20);

    public Skill[] Skill_List = new Skill[5 ];

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Skill_List[0] = Slide_Light;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    
}
