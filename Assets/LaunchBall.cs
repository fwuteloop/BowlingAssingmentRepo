using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchBall : MonoBehaviour
{
    [SerializeField]
    private Rigidbody ball;
    [SerializeField]
    private float launchSpeed;
    private void FixedUpdate()
    {
        ball.AddForce(Vector3.forward * -launchSpeed, ForceMode.Force);

    }

    public void SetRotation(Vector3 rotation)
    {
        ball.transform.rotation = Quaternion.Euler(rotation);
    }
}
