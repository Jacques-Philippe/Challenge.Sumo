using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    /// <summary>
    /// The speed by which the player should move forward and backward, with respect to the camera
    /// </summary>
    public float speed;

    /// <summary>
    /// A reference to our camera so we can access its position later
    /// </summary>
    private Camera Camera;


    /// <summary>
    /// A reference to the player's rigidbody
    /// </summary>
    private Rigidbody rigidBody;

    private void Start()
    {
        this.rigidBody = this.GetComponent<Rigidbody>();

        this.Camera = GameObject.FindObjectOfType<Camera>();
    }

    /// <summary>
    /// Move the player away from the camera
    /// </summary>
    public void MoveAwayFromCamera()
    {
        var direction = GetDirectionAwayFromCameraInXZPlane();
        this.rigidBody.AddForce(direction.normalized * speed * Time.deltaTime, ForceMode.VelocityChange);
    }

    /// <summary>
    /// Move the player towards the camera
    /// </summary>
    public void MoveTowardsCamera()
    {
        var direction = GetDirectionAwayFromCameraInXZPlane();
        this.rigidBody.AddForce(-direction.normalized * speed * Time.deltaTime, ForceMode.VelocityChange);
    }

    /// <summary>
    /// Helper to get the direction in w
    /// </summary>
    /// <returns></returns>
    private Vector3 GetDirectionAwayFromCameraInXZPlane()
    {
        //See https://www.maplesoft.com/support/help/maple/view.aspx?path=MathApps%2FProjectionOfVectorOntoPlane
        //Get the projection of the vector from the camera to the player on the XZ plane
        Vector3 u = this.transform.position - this.Camera.transform.position;
        Vector3 n = Vector3.Cross(-Vector3.right, Vector3.forward);

        float nominator = DotProduct(u, n);
        float denominator = Mathf.Pow(n.magnitude, 2);

        return u - (nominator / denominator) * n;
    }


    private float DotProduct(Vector3 v1, Vector3 v2)
    {
        return (v1.x * v2.x) + (v1.y * v2.y) + (v1.z * v2.z);
    }
}
