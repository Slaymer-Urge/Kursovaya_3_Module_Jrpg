using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    GameObject player;
    [SerializeField] float speed = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.aKey.isPressed)
        {
            player.transform.position = new Vector3( player.transform.position.x - speed, player.transform.position.y, player.transform.position.z);
        }
        if (Keyboard.current.dKey.isPressed)
        {
            player.transform.position = new Vector3(player.transform.position.x + speed, player.transform.position.y, player.transform.position.z);
        }
        if (Keyboard.current.wKey.isPressed)
        {
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + speed, player.transform.position.z);
        }
        if (Keyboard.current.sKey.isPressed)
        {
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - speed, player.transform.position.z);
        }
    }
}
