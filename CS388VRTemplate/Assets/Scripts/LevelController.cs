using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public GameObject mCamMobile;
    //public GameObject mCamPC;
    
    // Start is called before the first frame update
    void Start()
    {
#if UNITY_EDITOR
        mCamMobile.SetActive(false);
        //mCamPC.SetActive(true);
#endif
#if UNITY_ANDROID
        mCamMobile.SetActive(true);
        //mCamPC.SetActive(false);
#endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
