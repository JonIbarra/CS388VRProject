using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionResolution : MonoBehaviour
{
    public GameObject mPlayer;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = new Vector3(0f, 0f, 0f);
        float dist;

        if (Physics.ComputePenetration(mPlayer.GetComponent<BoxCollider>(), mPlayer.transform.position, mPlayer.transform.rotation,
            GetComponent<Collider>(), transform.position, transform.rotation, out dir, out dist))
        {
            //Debug.Log("Dir: " + dir.x + ", " + dir.y + ", " + dir.z);
            //Debug.Log("Dist: " + dist);
            mPlayer.transform.position += new Vector3(dir.x * dist, dir.y * dist, dir.z * dist);
        }
    }
}
