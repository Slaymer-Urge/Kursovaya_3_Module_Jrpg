using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] GameObject player;
    bool IsYClosed = false;
    bool IsXClosed = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, this.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y < 11.75 && player.transform.position.y > -11)
        {
            IsYClosed = false;
        }
        else
        {
            IsYClosed= true;
        }
        if (player.transform.position.x < 4.75 && player.transform.position.x > -5.5)
        {
            IsXClosed = false;
        }
        else
        {
            IsXClosed = true;
        }
        if (IsYClosed)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        }
        else
        {
            this.transform.position = new Vector3(this.transform.position.x, player.transform.position.y, this.transform.position.z);
        }
        if (IsXClosed)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        }
        else
        {
            this.transform.position = new Vector3(player.transform.position.x, this.transform.position.y, this.transform.position.z);
        }
    }
}
