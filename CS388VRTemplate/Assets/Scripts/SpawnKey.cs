using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKey : MonoBehaviour
{
    public GameObject[] keySpawns;
    // Start is called before the first frame update

    public GameObject keyPrefab;
    void Start()
    {
        int length = keySpawns.Length;
        int keySpawnsIn = Random.Range(0, length);

        Transform T = keySpawns[keySpawnsIn].transform;

        Instantiate(keyPrefab, T.position, T.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
