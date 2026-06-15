using TMPro;
using UnityEngine;

public class Text_ : MonoBehaviour
{
    public TMP_Text current_item_text;
    bool flicked = false;
    public float speed_flick = 0.0025f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (current_item_text.color.a > 0.2 && flicked==false)
        {
            current_item_text.color = new Color(current_item_text.color.r, current_item_text.color.g, current_item_text.color.b, current_item_text.color.a-speed_flick);
        }
        if (current_item_text.color.a < 0.2)
        {
            flicked = true;
        }
        if (current_item_text.color.a <1 && flicked == true)
        {
            current_item_text.color = new Color(current_item_text.color.r, current_item_text.color.g, current_item_text.color.b, current_item_text.color.a + speed_flick);
        }
        if (current_item_text.color.a == 1)
        {
            flicked=false;
        }
    }
}
