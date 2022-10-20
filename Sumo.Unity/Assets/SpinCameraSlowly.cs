using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinCameraSlowly : MonoBehaviour
{
    private float speed = 5.0f;

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(speed * Time.deltaTime * Vector3.up);   
    }
}
