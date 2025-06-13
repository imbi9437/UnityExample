using System;
using UnityEngine;

public class Rotater : MonoBehaviour
{
    [Tooltip("초당 회전 각도")]
    public Vector3 rotateAxis;

    private void Update()
    {
        transform.Rotate(rotateAxis * Time.deltaTime);
    }
}
