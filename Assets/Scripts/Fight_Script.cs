using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Fight_Script : MonoBehaviour
{
    GameObject[] characters_list;
    
    public GameObject[] Spawn_Emptys = new GameObject[5];
    public GameObject Camera;
    public GameObject Player;
    public GameObject Inv_Empty;
    public GameObject HUD_Fight_Empty;
    int current_queue = 0;
    bool wait_player_motion_attack;
    public int current_enemy;
    GameObject Enemy_1;
    GameObject Enemy_2;
    GameObject Enemy_3;
    bool can_use_buttons = true;
    GameObject anim_obj_attack;
    bool animation_attack = false;
    Vector3 final_place;
    float move_speed_x;
    float move_speed_y;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characters_list = GameObject.Find("Characters_Lists_Empty").GetComponent<Characters_List>().characters_list;
    }

    public void Start_Fight(GameObject[] enemys_list)
    {
        Camera.GetComponent<PlayerCamera>().enabled = false;
        Player.GetComponent<PlayerController>().enabled = false;
        Inv_Empty.GetComponent<Inventory>().can_use_inv = false;
        Camera.transform.position = (Spawn_Emptys[0].transform.position + Spawn_Emptys[2].transform.position) / 2;
        Camera.transform.position = new Vector3(Camera.transform.position.x, Camera.transform.position.y - 3.25f, -10f);
        HUD_Fight_Empty.SetActive(true);
        characters_list[0].transform.position = Spawn_Emptys[0].transform.position;
        if (characters_list[1] != null)
        {
            characters_list[1].transform.position = Spawn_Emptys[1].transform.position;
        }
        if (enemys_list[0] != null)
        {
            Enemy_1 = Instantiate(enemys_list[0]);
            Enemy_1.transform.position = Spawn_Emptys[2].transform.position;
        }

        if (enemys_list[1] != null)
        {
            Enemy_2 = Instantiate(enemys_list[1]);
            Enemy_2.transform.position = Spawn_Emptys[3].transform.position;
        }
        if (enemys_list[2] != null)
        {
            Enemy_3 = Instantiate(enemys_list[2]);
            Enemy_3.transform.position = Spawn_Emptys[4].transform.position;
        }
    }

    public void Player_Motion_Attack(int queue)
    {
        wait_player_motion_attack = true;
    }

    IEnumerator Courine_Wait ()
    {
        can_use_buttons = false;
        yield return new WaitForSeconds(1f);
        can_use_buttons = true;
    }

    int anim_tick = 0;

    // Update is called once per frame
    void Update()
    {
        if (animation_attack && anim_tick <=500)
        {
            anim_obj_attack.transform.position = new Vector3(anim_obj_attack.transform.position.x + move_speed_x, anim_obj_attack.transform.position.y + move_speed_y, anim_obj_attack.transform.position.z);
            anim_tick += 1;
            if (anim_tick == 500)
            {
                animation_attack = false;
                Destroy(anim_obj_attack);
                
            }
        }
        
        if (wait_player_motion_attack && Keyboard.current.digit1Key.isPressed && can_use_buttons)
        {
            StartCoroutine(Courine_Wait());
            if (current_enemy == 1)
            {
               Enemy_1.GetComponent<Character_Script>().HP -= characters_list[current_queue].GetComponent<Character_Script>().DMG_Hand;
               wait_player_motion_attack = false;
                anim_obj_attack = Instantiate(characters_list[current_queue].GetComponent<Character_Script>().object_attack);
                anim_obj_attack.transform.position = characters_list[current_queue].transform.position;
                final_place = Enemy_1.transform.position;
                move_speed_x = (final_place.x - anim_obj_attack.transform.position.x) / 500;
                move_speed_y = (final_place.y - anim_obj_attack.transform.position.y) / 500;
                anim_tick = 0;
                current_queue += 1;
                animation_attack = true;
            }
            else
            {
                current_enemy = 1;
            }
        }
        if (wait_player_motion_attack && Keyboard.current.digit2Key.isPressed && can_use_buttons)
        {
            StartCoroutine(Courine_Wait());
            if (current_enemy == 2)
            {
                Enemy_2.GetComponent<Character_Script>().HP -= characters_list[current_queue].GetComponent<Character_Script>().DMG_Hand;
                wait_player_motion_attack = false;
                anim_obj_attack = Instantiate(characters_list[current_queue].GetComponent<Character_Script>().object_attack);
                anim_obj_attack.transform.position = characters_list[current_queue].transform.position;
                final_place = Enemy_2.transform.position;
                move_speed_x = (final_place.x - anim_obj_attack.transform.position.x) / 500;
                move_speed_y = (final_place.y - anim_obj_attack.transform.position.y) / 500;
                anim_tick = 0;
                current_queue += 1;
                animation_attack = true;
            }
            else
            {
                current_enemy = 2;
            }
        }
        if (wait_player_motion_attack && Keyboard.current.digit3Key.isPressed && can_use_buttons)
        {
            StartCoroutine(Courine_Wait());
            if (current_enemy == 3)
            {
                Enemy_3.GetComponent<Character_Script>().HP -= characters_list[current_queue].GetComponent<Character_Script>().DMG_Hand;
                wait_player_motion_attack = false;
                anim_obj_attack = Instantiate(characters_list[current_queue].GetComponent<Character_Script>().object_attack);
                anim_obj_attack.transform.position = characters_list[current_queue].transform.position;
                final_place = Enemy_3.transform.position;
                move_speed_x = (final_place.x - anim_obj_attack.transform.position.x) / 500;
                move_speed_y = (final_place.y - anim_obj_attack.transform.position.y) / 500;
                anim_tick = 0;
                current_queue += 1;
                animation_attack = true;
            }
            else
            {
                current_enemy = 3;
            }
        }
        if ((current_queue == 0 || current_queue == 1) && Keyboard.current.qKey.isPressed)
        {
            current_enemy = 1;
            Player_Motion_Attack(current_queue);
        } 
    }
}
