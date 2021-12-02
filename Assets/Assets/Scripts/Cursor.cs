using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    AudioSource cursorSound;
    public GameObject camera1;
    public Transform leader;
    public Animator PlayerAnim;
    public GameObject detector;
    public float followSharpness = 0.1f;
    public bool inRadius = false;
    bool mbuttondown = false;
    public bool mtoggle = false;
    Vector3 _followOffset;
    Vector3 mouseL;

    public AudioClip load;

    void Start()
    {
        cursorSound = gameObject.GetComponent<AudioSource>();
        cursorSound.Stop();
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
        playAudio();
        Vector3 targetPosition = leader.position + _followOffset;

        if (Input.GetMouseButton(0))
        {
            PlayerAnim.SetBool("Commanding", true);
            mbuttondown = true;
            float zPos = 0f;
            mouseL = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position += (mouseL - transform.position) * (followSharpness*2);
            transform.position = new Vector3(transform.position.x, transform.position.y, zPos);
        }
        else 
        {
            PlayerAnim.SetBool("Commanding", false);
            if (inRadius == false && mbuttondown == false)
            {
                transform.position += (targetPosition - transform.position) * (followSharpness);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            mbuttondown = false;
        }

        // Toggle
        if (Input.GetMouseButtonDown(1))
        {
            AudioSource.PlayClipAtPoint(load, camera1.transform.position);
            PlayerAnim.SetBool("Commanding", true);
            if (mtoggle == false)
            {
                mtoggle = true;
                this.tag = "Cursor2";
            }
            else
            {
                mtoggle = false;
                this.tag = "Cursor";
            }

        }

    }
    void playAudio()
    {
        if (mbuttondown == true)
        {
            cursorSound.Play();
        }
        else
        {
            cursorSound.Stop();
        }
    }

}

