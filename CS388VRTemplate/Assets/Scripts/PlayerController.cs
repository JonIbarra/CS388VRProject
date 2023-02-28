using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;
    public GameObject door;

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
