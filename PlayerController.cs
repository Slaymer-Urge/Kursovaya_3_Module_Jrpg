using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    GameObject player;
    [SerializeField] float speed = 0.02f;
    public bool in_fight = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = this.gameObject;
    }

    IEnumerator Waiting_drop()
    {
        yield return new WaitForSeconds(0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (in_fight == false)
        {
            if (Keyboard.current.aKey.isPressed)
            {
                player.transform.position = new Vector3(player.transform.position.x - speed, player.transform.position.y, player.transform.position.z);
                player.transform.rotation = Quaternion.Euler(0, 0, 90f);
            }
            if (Keyboard.current.dKey.isPressed)
            {
                player.transform.position = new Vector3(player.transform.position.x + speed, player.transform.position.y, player.transform.position.z);
                player.transform.rotation = Quaternion.Euler(0, 0, -90f);

            }
            if (Keyboard.current.wKey.isPressed)
            {
                player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + speed, player.transform.position.z);
                player.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            if (Keyboard.current.sKey.isPressed)
            {
                player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - speed, player.transform.position.z);
                player.transform.rotation = Quaternion.Euler(0, 0, 180f);

            }
        }
        
        
    }
}
