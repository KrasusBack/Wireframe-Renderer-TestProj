using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotation : MonoBehaviour
{
    [SerializeField]
    private Vector3 rotationVector = new Vector3( 30, 60, 10 );

    void Update()
    {
        Rotate();
    }

    private void Rotate()
    {
        transform.Rotate(rotationVector * Time.deltaTime);
    }
}
