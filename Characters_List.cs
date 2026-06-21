using UnityEngine;

public class Characters_List : MonoBehaviour
{
    public GameObject[] characters_list = new GameObject[2];
    public GameObject[] Spawn_Emptys = new GameObject[2];
    public GameObject Camera;
    public GameObject Player;
    public GameObject Inv_Empty;
    public GameObject Fight_Emp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
    }

    public void Start_Fight()
    {
        Camera.GetComponent<PlayerCamera>().enabled = false;
        Player.GetComponent<PlayerController>().enabled = false;
        Inv_Empty.GetComponent<Inventory>().can_use_inv = false;
        Camera.transform.position = (Spawn_Emptys[0].transform.position + Spawn_Emptys[1].transform.position)/2;
        Camera.transform.position = new Vector3(Camera.transform.position.x, Camera.transform.position.y, -10f);
        characters_list[0].transform.position = Spawn_Emptys[0].transform.position;
        characters_list[1].transform.position = Spawn_Emptys[1].transform.position;
        Fight_Emp.GetComponent<Fight_Script>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
