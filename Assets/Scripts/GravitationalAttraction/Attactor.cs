using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attactor : MonoBehaviour
{
    public float mass = 20;
    Vector3 _location;
    float G;

    public Attactor()
    {
        _location = transform.position;
        G = 0.4f;
    }

    public Vector3 Attract(Mover m)
    {
        Vector3 force = _location - m._location;
        float distance = force.magnitude;

        force = force.normalized;
        float strength = (G * mass * m.mass) / distance * distance;
        force *= strength;
        return force;
    }

    public void Update()
    {
        
    }


}
