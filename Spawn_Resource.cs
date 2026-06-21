using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class Spawn_Resource : MonoBehaviour
{
    public GameObject resourse;
    bool is_spawned = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Waiting_Spawn());
    }

    IEnumerator Waiting_Spawn()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("Ресурс заспавлен");
        is_spawned = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (is_spawned)
        {
            GameObject new_resource = Instantiate(resourse);
            float random_position = UnityEngine.Random.Range(-1f, 2f);
            new_resource.transform.position = new Vector3(this.transform.position.x-random_position, this.transform.position.y-random_position, this.transform.position.z);
            is_spawned=false;
            StartCoroutine(Waiting_Spawn());
        }
    }
}
