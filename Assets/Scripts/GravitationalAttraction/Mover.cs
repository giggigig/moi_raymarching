using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float mass = 3;

    public Vector3 _location;
    public Vector3 _velocity;
    public Vector3 _acceleration;

    public Mover(float m, Vector3 pos)
    {
        mass = m;
        _location = pos;

        _velocity = Vector3.zero;
        _acceleration = Vector3.zero;
        transform.localScale *= mass;
    }

    public void applyForce(Vector3 force)
    {
        Vector3 f = force / mass;
        f += _acceleration;
    }

    public void Update()
    {
        _velocity += _acceleration;
        _location += _velocity;
        _acceleration *= 0;

        transform.Translate(_location * Time.deltaTime);
    }


}
