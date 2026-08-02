using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChooseScriipt : MonoBehaviour
{
    public TMP_Text current_item;
    public GameObject Empty;
    public GameObject Empty_For_Choose;
    float normal_x_position;
    int last_slot = 0;
    public GameObject Inventory_Object;
    bool blocked_drop = false;
    [SerializeField] GameObject Fight_Empty;
    bool blocked_fight = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        normal_x_position = Empty_For_Choose.transform.position.y;
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
        if (Keyboard.current.qKey.isPressed && blocked_drop==false)
        {
            Inventory_Object.GetComponent<Inventory>().Drop_Item(last_slot,this.gameObject.transform.position);
            blocked_drop = true;
            StartCoroutine(Waiting_drop());
        }
        if (Keyboard.current.digit1Key.isPressed)
        {
            Empty_For_Choose.transform.position = new Vector3(Empty_For_Choose.transform.position.x, normal_x_position, Empty_For_Choose.transform.position.z);
            last_slot = 0;
        }
        if (Keyboard.current.digit2Key.isPressed)
        {
            Empty_For_Choose.transform.position = new Vector3(Empty_For_Choose.transform.position.x, normal_x_position - (85 * 1), Empty_For_Choose.transform.position.z);
            last_slot = 1;
        }
        if (Keyboard.current.digit3Key.isPressed)
        {
            Empty_For_Choose.transform.position = new Vector3(Empty_For_Choose.transform.position.x, normal_x_position - (85 * 2), Empty_For_Choose.transform.position.z);
            last_slot = 2;
        }
        if (Keyboard.current.digit4Key.isPressed)
        {
            Empty_For_Choose.transform.position = new Vector3(Empty_For_Choose.transform.position.x, normal_x_position - (85 *3), Empty_For_Choose.transform.position.z);
            last_slot = 3;
        }
        if (Keyboard.current.digit5Key.isPressed)
        {
            Empty_For_Choose.transform.position = new Vector3(Empty_For_Choose.transform.position.x, normal_x_position - (85 * 4), Empty_For_Choose.transform.position.z);
            last_slot = 4;
        }
    }
}
