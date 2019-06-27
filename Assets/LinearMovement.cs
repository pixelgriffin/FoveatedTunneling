using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class LinearMovement : MonoBehaviour
{
    public Hand left, right;
    public Transform hmd;

    [Tooltip("The speed the player moves in meters per second (m/s)")]
    public float speed = 100f;

    void Start()
    {
        
    }

    void Update()
    {
        Vector2 dir = left.touchpad.GetAxis(left.handType) + right.touchpad.GetAxis(right.handType);
        dir.Normalize();

        Vector3 flatForward = hmd.forward;
        flatForward.y = 0;
        Vector3 flatRight = hmd.right;
        flatRight.y = 0;

        this.transform.position += (flatForward * dir.y + flatRight * dir.x) * Time.deltaTime * speed;

        float y = this.transform.position.y;

        RaycastHit hit;
        if(Physics.Raycast(this.transform.position + Vector3.up * 2, Vector3.down, out hit))
        {
            y = hit.point.y;
        }

        this.transform.position = new Vector3(this.transform.position.x, y, this.transform.position.z);
    }
}
