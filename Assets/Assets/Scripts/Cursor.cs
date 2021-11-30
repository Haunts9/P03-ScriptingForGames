using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    public Transform leader;
    public GameObject detector;
    public float followSharpness = 0.1f;
    public bool inRadius = false;
    bool mbuttondown = false;
    Vector3 _followOffset;
    Vector3 mouseL;

    void Start()
    {
        // Cache the initial offset at time of load/spawn:
        _followOffset = transform.position - leader.position;
    }
    private void FixedUpdate()
    {
        mouseL = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        inRadius = detector.GetComponent<CursorDetection>().inRadius;
    }
    void LateUpdate()
    {

        // Apply that offset to get a target position.
        Vector3 targetPosition = leader.position + _followOffset;
        // Keep our y position unchanged.

        // Smooth follow.
        if (Input.GetMouseButton(0))
        {
            mbuttondown = true;
            float zPos = 0f;
            mouseL = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position += (mouseL - transform.position) * (followSharpness*2);
            transform.position = new Vector3(transform.position.x, transform.position.y, zPos);
        }
        else 
        {
            if (inRadius == false && mbuttondown == false)
            {
                transform.position += (targetPosition - transform.position) * (followSharpness);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            mbuttondown = false;
        }    


    }


}

