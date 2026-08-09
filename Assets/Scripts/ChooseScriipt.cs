using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ChooseScriipt : MonoBehaviour
{
    public TMP_Text current_item;
    public GameObject Empty;
    public GameObject Empty_For_Choose;
    float normal_x_position;
    public int last_slot = 0;
    public GameObject Inventory_Object;
    bool blocked_drop = false;
    [SerializeField] GameObject Fight_Empty;
    bool blocked_fight = false;
    bool is_open_inv;
    public GameObject arrow;
    public Image icon_1;
    public Image icon_2;
    public Image HP_Bar_1;
    public Image HP_Bar_2;
    public int current_choose_char;
    public bool use_item;
    public GameObject Char_List;
    public bool block_use_item = true;
    public bool in_fight = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        normal_x_position = Empty_For_Choose.transform.position.y;
        is_open_inv = Inventory_Object.GetComponent<Inventory>().Inv_Open;
        use_item = Inventory_Object.GetComponent<Inventory>().use_item;
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            current_item.text = "Объект " + collision.gameObject.name;
            Empty.SetActive(true);
            return;
        }
        if (collision.gameObject.GetComponent<Character_Script>().Type_Character == "Враг" && blocked_fight == false)
        {
            Fight_Empty.GetComponent<Fight_Script>().Start_Fight(collision.gameObject.GetComponent<Enemy_Script>().list_enemys_for_fight, this.transform.position);
            this.gameObject.GetComponent<ChooseScriipt>().enabled = false;  
        }

    }

    

    public IEnumerator Wait_After_Fight()
    {
        blocked_fight = true;
        yield return new WaitForSeconds(2f);
        blocked_fight = false;
    }

    public IEnumerator Wait_Use_Item()
    {
        block_use_item = true;
        yield return new WaitForSeconds(0.5f);
        block_use_item = false;
    }
    public IEnumerator Waiting_drop()
    {
        yield return new WaitForSeconds(0.5f);
        this.gameObject.GetComponent<ChooseScriipt>().enabled = true;
        blocked_drop = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Empty.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        use_item = Inventory_Object.GetComponent<Inventory>().use_item;
        is_open_inv = Inventory_Object.GetComponent<Inventory>().Inv_Open;
        if (Keyboard.current.qKey.isPressed && blocked_drop==false)
        {
            Inventory_Object.GetComponent<Inventory>().Drop_Item(last_slot,this.gameObject.transform.position);
            blocked_drop = true;
            StartCoroutine(Waiting_drop());
        }
        if (Keyboard.current.digit1Key.isPressed)
        {
            if (is_open_inv == true)
            {
                Empty_For_Choose.transform.position = new Vector3(Empty_For_Choose.transform.position.x, normal_x_position, Empty_For_Choose.transform.position.z);
                last_slot = 0;
            }
            if (is_open_inv == false && use_item && in_fight == false)
            {
                arrow.transform.position = new Vector2(icon_1.transform.position.x-90,icon_1.transform.position.y);
                current_choose_char = 0;
            }
            if (is_open_inv == false && use_item && in_fight)
            {
                arrow.transform.position = new Vector2(HP_Bar_1.transform.position.x - 110, HP_Bar_1.transform.position.y +70);
                current_choose_char = 0;
            }
        }
        if (Keyboard.current.digit2Key.isPressed)
        {
            if (is_open_inv == true)
            {
                Empty_For_Choose.transform.position = new Vector3(Empty_For_Choose.transform.position.x, normal_x_position - (85 * 1), Empty_For_Choose.transform.position.z);
                last_slot = 1;
            }
            if (is_open_inv == false && use_item && in_fight == false)
            {
                arrow.transform.position = new Vector2(icon_2.transform.position.x-90, icon_2.transform.position.y);
                current_choose_char = 1;
            }
            if (is_open_inv == false && use_item && in_fight)
            {
                arrow.transform.position = new Vector2(HP_Bar_2.transform.position.x - 110, HP_Bar_2.transform.position.y + 70);
                current_choose_char = 1;
            }
        }
        if (Keyboard.current.eKey.isPressed && use_item && block_use_item == false)
        {
            Char_List.GetComponent<Characters_List>().Use_Item_On_Char(Inventory_Object.GetComponent<Inventory>().Inventory_List[last_slot], current_choose_char);
            Inventory_Object.GetComponent<Inventory>().Use_Item(last_slot);
            arrow.SetActive(false);
            Inventory_Object.GetComponent<Inventory>().use_item = false;
            StartCoroutine(Wait_Use_Item());
        }
        if (Keyboard.current.digit3Key.isPressed)
        {
            if (is_open_inv == true)
            {
                Empty_For_Choose.transform.position = new Vector3(Empty_For_Choose.transform.position.x, normal_x_position - (85 * 2), Empty_For_Choose.transform.position.z);
                last_slot = 2;
            }
        }
        if (Keyboard.current.digit4Key.isPressed)
        {
            if (is_open_inv == true)
            {
                Empty_For_Choose.transform.position = new Vector3(Empty_For_Choose.transform.position.x, normal_x_position - (85 * 3), Empty_For_Choose.transform.position.z);
                last_slot = 3;
            }
        }
        if (Keyboard.current.digit5Key.isPressed)
        {
            if (is_open_inv == true)
            {
                Empty_For_Choose.transform.position = new Vector3(Empty_For_Choose.transform.position.x, normal_x_position - (85 * 4), Empty_For_Choose.transform.position.z);
                last_slot = 4;
            }
            
        }
    }
}
