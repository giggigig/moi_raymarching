using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubemoving : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(transform.position.x, transform.position.y + 3f * Mathf.Sin(Time.deltaTime), transform.position.y) * Time.deltaTime );
    }
}
