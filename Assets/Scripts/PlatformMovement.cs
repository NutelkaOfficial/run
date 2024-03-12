using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{

    public float runSpeed = 500f;
    private void Move()
    {
        transform.Translate(-transform.forward * runSpeed * Time.fixedDeltaTime);
    }
    void FixedUpdate()
    {
        Move();
        DestroyPlatform();
    }
    private void DestroyPlatform()
    {
        if (gameObject.name != "Platform" && transform.position.z < -180f)
        {

            Destroy(gameObject);
        }
    }
}
