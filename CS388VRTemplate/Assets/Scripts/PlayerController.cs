using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;
    public float rotationSpeed;
    public GameObject door;
    public Transform cam;

    CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * playerSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.E))
            gameObject.transform.Rotate(new Vector3(0f, rotationSpeed, 0f) * Time.deltaTime);
        if (Input.GetKey(KeyCode.Q))
            gameObject.transform.Rotate(new Vector3(0f, -rotationSpeed, 0f) * Time.deltaTime);

        cam.position = transform.position;
        cam.rotation = transform.rotation;
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
