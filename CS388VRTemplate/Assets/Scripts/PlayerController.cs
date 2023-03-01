using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;
    public GameObject door;

    public GameObject laberynth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.W))
            gameObject.transform.position += new Vector3(0f,0f, playerSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.A))
            gameObject.transform.position -= new Vector3(playerSpeed * Time.deltaTime,0f, 0f);
        if (Input.GetKey(KeyCode.S))
            gameObject.transform.position -= new Vector3(0f, 0f, playerSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            gameObject.transform.position += new Vector3(playerSpeed * Time.deltaTime, 0f, 0f);
        if (Input.GetKey(KeyCode.E))
            gameObject.transform.Rotate(new Vector3(0f, playerSpeed, 0f) * Time.deltaTime);
        if (Input.GetKey(KeyCode.Q))
            gameObject.transform.Rotate(new Vector3(0f, -playerSpeed, 0f) * Time.deltaTime);
#endif
        Vector3 dir = new Vector3(0f, 0f, 0f);
        float dist;

        if (Physics.ComputePenetration(laberynth.GetComponent<MeshCollider>(), laberynth.transform.position, laberynth.transform.rotation,
            GetComponent<BoxCollider>(), transform.position, transform.rotation, out dir, out dist))
        {
            //Debug.Log("Dir: " + dir.x + ", " + dir.y + ", " + dir.z);
            //Debug.Log("Dist: " + dist);
            gameObject.transform.position += new Vector3(-dir.x * dist, -dir.y * dist, -dir.z * dist);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Key(Clone)")
        {
            Destroy(other.gameObject);
            Destroy(door);
        }
    }

}
