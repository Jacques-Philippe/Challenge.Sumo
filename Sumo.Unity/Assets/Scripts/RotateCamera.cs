using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    /// <summary>
    /// The speed by which we rotate the camera about the scene's vertical axis
    /// </summary>
    private float speed = 50;

    /// <summary>
    /// Rotate the camera clockwise about the scene's vertical axis
    /// </summary>
    public void RotateClockwise()
    {
        this.transform.Rotate(Vector3.up, this.speed * Time.deltaTime, Space.World);
    }

    /// <summary>
    /// Rotate the camera counter-clockwise about the scene's vertical axis
    /// </summary>
    public void RotateCounterClockwise()
    {
        this.transform.Rotate(-Vector3.up, this.speed * Time.deltaTime, Space.World);
    }
}
