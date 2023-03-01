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

    public GameObject laberynth;
    public UnityEngine.UI.Text doorText;
    public UnityEngine.UI.Text endText;
    public Animator anim;

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

        cam.rotation = transform.rotation;
        cam.position = transform.position;
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
            doorText.text = "Door: Open";
        }
        if (other.name == "End")
        {
            endText.color = new Color(50, 50, 50, 255);
            Invoke("EndSequence", 1);
        }
    }

    private void EndSequence()
    {
        anim.Play("FadeOut");
        Invoke("Finish", 1);
    }

    private void Finish()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

}
