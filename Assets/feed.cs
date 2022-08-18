using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class feed : MonoBehaviour
{
    public GameObject feedob;

    Vector3 randPos;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            randPos = new Vector3(Random.Range(-20, 30), Random.Range(-20, 30), Random.Range(-20, 30));
            Instantiate(feedob, randPos, Quaternion.identity);
        }
    }
}
