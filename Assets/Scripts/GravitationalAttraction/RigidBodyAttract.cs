using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyAttract : MonoBehaviour
{
    public const float G = 50;
    public Rigidbody rb;

    private void FixedUpdate()
    {
        RBMover[] movers = FindObjectsOfType<RBMover>();
        foreach (RBMover mover in movers)
        {
            if (mover != this)
                Attract(mover);
        }
    }

    public void Attract(RBMover m)
    {
        Rigidbody rbToM = m.mRb;
        Vector3 direction = rb.position - rbToM.position;
        float distance = direction.magnitude;

        float forceMagnitude = G * (rb.mass * rbToM.mass) / Mathf.Pow(distance, 2);
        Vector3 force = direction.normalized * forceMagnitude;

        rbToM.AddForce(force);
    }
}
