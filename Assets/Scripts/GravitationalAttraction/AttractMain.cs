using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractMain : MonoBehaviour
{
    public Attactor a;
    public Mover m;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 force = a.Attract(m);
        m.applyForce(force);
        m.Update();


        m.transform.Translate(m._location * Time.deltaTime);
    }
}
