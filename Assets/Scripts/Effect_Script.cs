using UnityEngine;

public class Effect_Script : MonoBehaviour
{
    public string[] lists_effects = new string[3];
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lists_effects[0] = "ХП";
        lists_effects[1] = "Мана";
        lists_effects[2] = "Усиление";
    }

    void use_item(int number_effect, GameObject item)
    {
        if (number_effect == 0)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
