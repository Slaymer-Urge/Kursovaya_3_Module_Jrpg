using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class Fight_Script : MonoBehaviour
{
    public GameObject[] characters_list;
    public GameObject HUD_Lose;
    public GameObject[] Spawn_Emptys = new GameObject[5];
    public GameObject Camera;
    public GameObject Player;
    public GameObject Inv_Empty;
    public GameObject HUD_Fight_Empty;
    public GameObject HUD_Fight;
    int current_queue = 0;
    bool wait_player_motion_attack;
    public int current_enemy;
    GameObject Enemy_1;
    GameObject Enemy_2;
    GameObject Enemy_3;
    GameObject[] Enemys_List_Here = new GameObject[3];
    bool can_use_buttons = false;
    GameObject anim_obj_attack;
    bool animation_attack = false;
    Vector3 final_place;
    float move_speed_x;
    float move_speed_y;
    Vector3 last_position_player;
    public GameObject choose_go;
    public GameObject def_hud;
    public GameObject choose_item;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characters_list = GameObject.Find("Characters_Lists_Empty").GetComponent<Characters_List>().characters_list;
    }

    public void End_Fight()
    {
        Camera.GetComponent<PlayerCamera>().enabled = true;
        Player.GetComponent<PlayerController>().enabled = true;
        Inv_Empty.GetComponent<Inventory>().can_use_inv = true;
        Player.transform.position = last_position_player;
        def_hud.SetActive(true);
        characters_list[0].GetComponent<Character_Script>().Died = false;
        characters_list[0].gameObject.SetActive(true);
        characters_list[0].GetComponent<Character_Script>().HP = 1;
        choose_item.GetComponent<ChooseScriipt>().enabled = true;
        if (characters_list[1] != null)
        {
            characters_list[1].GetComponent<Character_Script>().Died = false;
            characters_list[1].gameObject.SetActive(true);
            characters_list[1].GetComponent<Character_Script>().HP = 1;
        }
        StartCoroutine(choose_go.GetComponent<ChooseScriipt>().Wait_After_Fight()); 
        def_hud.GetComponent<Default_HUD>().locked_scan = false;
    }

    void Lost_Fight()
    {
        HUD_Lose.GetComponent<Lost_HUD_Script>().Lose_Func();
        HUD_Fight_Empty.SetActive(false);
        StartCoroutine(HUD_Fight.GetComponent<HUD_Fight_Script>().Get_DMG_Enemys(characters_list[0].GetComponent<Character_Script>().HP / characters_list[0].GetComponent<Character_Script>().MaxHP, 4));
        StartCoroutine(HUD_Fight.GetComponent<HUD_Fight_Script>().Get_DMG_Enemys(characters_list[0].GetComponent<Character_Script>().HP / characters_list[0].GetComponent<Character_Script>().MaxHP, 5));
        

    }


    public void Start_Fight(GameObject[] enemys_list, Vector3 last_pos)
    {
        last_position_player = last_pos;
        Camera.GetComponent<PlayerCamera>().enabled = false;
        Player.GetComponent<PlayerController>().enabled = false;
        Inv_Empty.GetComponent<Inventory>().can_use_inv = false;
        Camera.transform.position = (Spawn_Emptys[0].transform.position + Spawn_Emptys[2].transform.position) / 2;
        Camera.transform.position = new Vector3(Camera.transform.position.x, Camera.transform.position.y - 3.25f, -10f);
        def_hud.SetActive(false);
        HUD_Fight_Empty.SetActive(true);
        current_queue = 0;
        if (enemys_list[2] == null)
        {
            HUD_Fight.GetComponent<HUD_Fight_Script>().Start_Fight(2);
        }
        if (enemys_list[1] == null)
        {
            HUD_Fight.GetComponent<HUD_Fight_Script>().Start_Fight(1);
        }
        if (enemys_list[2] != null) 
        {
            HUD_Fight.GetComponent<HUD_Fight_Script>().Start_Fight(3);
        }


        characters_list[0].transform.position = Spawn_Emptys[0].transform.position;
        if (characters_list[1] != null)
        {
            characters_list[1].transform.position = Spawn_Emptys[1].transform.position;
        }
        if (enemys_list[0] != null)
        {
            Enemy_1 = Instantiate(enemys_list[0]);
            Enemy_1.transform.position = Spawn_Emptys[2].transform.position;
            Enemys_List_Here[0] = Enemy_1;
            
        }

        if (enemys_list[1] != null)
        {
            Enemy_2 = Instantiate(enemys_list[1]);
            Enemy_2.transform.position = Spawn_Emptys[3].transform.position;
            Enemys_List_Here[1] = Enemy_2;
        }
        if (enemys_list[2] != null)
        {
            Enemy_3 = Instantiate(enemys_list[2]);
            Enemy_3.transform.position = Spawn_Emptys[4].transform.position;
            Enemys_List_Here[2] = Enemy_3;
        }
        can_use_buttons = true;
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

    IEnumerator Enemy_Attack_Default()
    {
        if (Enemys_List_Here[current_queue-2] != null)
        {
            
            can_use_buttons = false;
            yield return new WaitForSeconds(1.5f);
            int current_target = Random.Range(0, 2);
            Debug.Log(characters_list[0].GetComponent<Character_Script>().Died);
            Debug.Log(characters_list[1].GetComponent<Character_Script>().Died);
            Debug.Log(characters_list[0].GetComponent<Character_Script>().Died == true && (characters_list[1] == null || characters_list[1].GetComponent<Character_Script>().Died == true));
            while (characters_list[current_target].GetComponent<Character_Script>().Died == true)
            {
                
                current_target = Random.Range(0, 2);
            }
            
            
            
            characters_list[current_target].GetComponent<Character_Script>().HP -= Enemys_List_Here[current_queue - 2].GetComponent<Character_Script>().DMG_Hand;
            if (characters_list[current_target].GetComponent<Character_Script>().HP <= 0)
            {
                StartCoroutine(Death_Character(current_target, false));
                StartCoroutine(HUD_Fight.GetComponent<HUD_Fight_Script>().Get_DMG_Enemys(0, current_target + 4));
            }
            StartCoroutine(HUD_Fight.GetComponent<HUD_Fight_Script>().Get_DMG_Enemys(characters_list[current_target].GetComponent<Character_Script>().HP / characters_list[current_target].GetComponent<Character_Script>().MaxHP, current_target + 4));
            anim_obj_attack = Instantiate(Enemys_List_Here[current_queue - 2].GetComponent<Character_Script>().object_attack);
            anim_obj_attack.transform.position = Enemys_List_Here[current_queue - 2].transform.position;
            final_place = characters_list[current_target].transform.position;
            move_speed_x = (final_place.x - anim_obj_attack.transform.position.x) / 500;
            move_speed_y = (final_place.y - anim_obj_attack.transform.position.y) / 500;
            anim_tick = 0;
            can_use_buttons = false;
            StartCoroutine(Next_Queue());
            StartCoroutine(Courine_Wait());
            animation_attack = true;
            yield return new WaitForSeconds(1f);
            
        }
        else { current_queue += 1; }

    }

    IEnumerator Death_Character(int target,bool is_enemy)
    {
        yield return new WaitForSeconds(1f);
        if (is_enemy)
        { 
            Enemys_List_Here[current_enemy-1].gameObject.SetActive(false);
            Enemys_List_Here[current_enemy-1].GetComponent<Character_Script>().HP = 0;
            Enemys_List_Here[current_enemy-1].GetComponent<Character_Script>().Died = true;
            

        }
        if (is_enemy == false) 
        {
            characters_list[target].GetComponent<Character_Script>().Died = true;
            characters_list[target].gameObject.SetActive(false);
            characters_list[target].GetComponent<Character_Script>().HP = 0;
            
        }

    }

    
    IEnumerator Next_Queue()
    {
        Debug.Log("Проверка на проигрыш, раунд");
        Debug.Log(current_queue);
        
        yield return new WaitForSeconds(1f);
        
        current_queue += 1;
    }

    int anim_tick = 0;

    // Update is called once per frame
    void Update()
    {
        if (current_queue == 5)
        {
            current_queue = 0;
        }
        if (animation_attack && anim_tick <=500)
        {
            anim_obj_attack.transform.position = new Vector3(anim_obj_attack.transform.position.x + move_speed_x, anim_obj_attack.transform.position.y + move_speed_y, anim_obj_attack.transform.position.z);
            anim_tick += 1;
        }
        if (anim_tick >= 500)
        {
            animation_attack = false;
            Destroy(anim_obj_attack);
        }
   
        if (wait_player_motion_attack && Keyboard.current.digit1Key.isPressed && can_use_buttons)
        {
            HUD_Fight.GetComponent<HUD_Fight_Script>().Pressed1();
            StartCoroutine(Courine_Wait());
            if (current_enemy == 1 && Enemys_List_Here[0].GetComponent<Character_Script>().Died == false)
            {
                
                Enemy_1.GetComponent<Character_Script>().HP -= characters_list[current_queue].GetComponent<Character_Script>().DMG_Hand;
                if (Enemys_List_Here[current_enemy-1].GetComponent<Character_Script>().HP <= 0)
                {
                    StartCoroutine(Death_Character(1,true));
                    StartCoroutine(HUD_Fight.GetComponent<HUD_Fight_Script>().Get_DMG_Enemys(0, current_enemy));
                }
                StartCoroutine(HUD_Fight.GetComponent<HUD_Fight_Script>().Get_DMG_Enemys(Enemy_1.GetComponent<Character_Script>().HP / Enemy_1.GetComponent<Character_Script>().MaxHP, 1));
                HUD_Fight.GetComponent<HUD_Fight_Script>().Back_Def();
                wait_player_motion_attack = false;
                anim_obj_attack = Instantiate(characters_list[current_queue].GetComponent<Character_Script>().object_attack);
                anim_obj_attack.transform.position = characters_list[current_queue].transform.position;
                final_place = Enemy_1.transform.position;
                move_speed_x = (final_place.x - anim_obj_attack.transform.position.x) / 500;
                move_speed_y = (final_place.y - anim_obj_attack.transform.position.y) / 500;
                anim_tick = 0;
                StartCoroutine(Next_Queue());
                animation_attack = true;
            }
            else
            {
                current_enemy = 1;
            }
        }
        if (wait_player_motion_attack && Keyboard.current.digit2Key.isPressed && can_use_buttons)
        {
            HUD_Fight.GetComponent<HUD_Fight_Script>().Pressed2();
            StartCoroutine(Courine_Wait());
            if (current_enemy == 2 && Enemys_List_Here[1].GetComponent<Character_Script>().Died == false)
            {
                Enemy_2.GetComponent<Character_Script>().HP -= characters_list[current_queue].GetComponent<Character_Script>().DMG_Hand;
                if (Enemys_List_Here[current_enemy-1].GetComponent<Character_Script>().HP <= 0)
                {
                    StartCoroutine(Death_Character(2, true));
                    StartCoroutine(HUD_Fight.GetComponent<HUD_Fight_Script>().Get_DMG_Enemys(0, current_enemy));
                }
                StartCoroutine(HUD_Fight.GetComponent<HUD_Fight_Script>().Get_DMG_Enemys(Enemy_2.GetComponent<Character_Script>().HP / Enemy_2.GetComponent<Character_Script>().MaxHP, 2));
                HUD_Fight.GetComponent<HUD_Fight_Script>().Back_Def();
                wait_player_motion_attack = false;
                anim_obj_attack = Instantiate(characters_list[current_queue].GetComponent<Character_Script>().object_attack);
                anim_obj_attack.transform.position = characters_list[current_queue].transform.position;
                final_place = Enemy_2.transform.position;
                move_speed_x = (final_place.x - anim_obj_attack.transform.position.x) / 500;
                move_speed_y = (final_place.y - anim_obj_attack.transform.position.y) / 500;
                anim_tick = 0;
                StartCoroutine(Next_Queue());
                animation_attack = true;
            }
            else
            {
                current_enemy = 2;
            }
        }
        if (wait_player_motion_attack && Keyboard.current.digit3Key.isPressed && can_use_buttons)
        {
            HUD_Fight.GetComponent<HUD_Fight_Script>().Pressed3();
            StartCoroutine(Courine_Wait());
            if (current_enemy == 3 && Enemys_List_Here[2].GetComponent<Character_Script>().Died == false)
            {
                Enemy_3.GetComponent<Character_Script>().HP -= characters_list[current_queue].GetComponent<Character_Script>().DMG_Hand;
                if (Enemys_List_Here[current_enemy-1].GetComponent<Character_Script>().HP <= 0)
                {
                    StartCoroutine(Death_Character(3, true));
                    StartCoroutine(HUD_Fight.GetComponent<HUD_Fight_Script>().Get_DMG_Enemys(0, current_enemy));
                }
                StartCoroutine(HUD_Fight.GetComponent<HUD_Fight_Script>().Get_DMG_Enemys(Enemy_3.GetComponent<Character_Script>().HP / Enemy_3.GetComponent<Character_Script>().MaxHP, 3));
                HUD_Fight.GetComponent<HUD_Fight_Script>().Back_Def();
                wait_player_motion_attack = false;
                anim_obj_attack = Instantiate(characters_list[current_queue].GetComponent<Character_Script>().object_attack);
                anim_obj_attack.transform.position = characters_list[current_queue].transform.position;
                final_place = Enemy_3.transform.position;
                move_speed_x = (final_place.x - anim_obj_attack.transform.position.x) / 500;
                move_speed_y = (final_place.y - anim_obj_attack.transform.position.y) / 500;
                anim_tick = 0;
                StartCoroutine(Next_Queue());
                animation_attack = true;
            }
            else
            {
                current_enemy = 3;
            }
        }
        if (current_queue <=1 && characters_list[current_queue].GetComponent<Character_Script>().Died)
        {
            current_queue += 1;
            return;
        }
        if ((current_queue == 0 || current_queue == 1) && Keyboard.current.qKey.isPressed && can_use_buttons)
        {
            HUD_Fight.GetComponent<HUD_Fight_Script>().QPressed();
            current_enemy = 1;
            Player_Motion_Attack(current_queue);
        }
        if ((current_queue == 0 || current_queue == 1) && Keyboard.current.tKey.isPressed && can_use_buttons)
        {
            HUD_Fight.GetComponent<HUD_Fight_Script>().TPressed();
            choose_item.GetComponent<ChooseScriipt>().enabled = true;
            current_enemy = 1;
            
        }
        if ((current_queue == 2 || current_queue == 3 || current_queue == 4) && can_use_buttons)
        {
            if (Enemys_List_Here[current_queue -2] == null || Enemys_List_Here[current_queue - 2].GetComponent<Character_Script>().Died)
            {
                current_queue += 1;
                return;
            }
            if (characters_list[0].GetComponent<Character_Script>().Died == true && (characters_list[1] == null || characters_list[1].GetComponent<Character_Script>().Died == true))
            {
                current_queue = 6;
                Lost_Fight();
                return;
            }
            StartCoroutine(Enemy_Attack_Default());
            
        }
    }
}
