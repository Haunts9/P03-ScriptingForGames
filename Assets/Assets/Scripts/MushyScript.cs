using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushyScript : MonoBehaviour
{
    GameObject Cursor;
    public GameObject GoldiLocks;
    public GameObject DetectRange;
    public float speed = 10f;
    public Rigidbody2D rb;
    public bool Gold = false;
    public bool InBar = false;
    public bool Detect = false;
    // Start is called before the first frame update
    void Start()
    {
        Cursor = GameObject.FindGameObjectWithTag("Cursor");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        Gold = GoldiLocks.GetComponent<MushyGoldilocks>().Gold;
        Detect = DetectRange.GetComponent<MushyDetectRange>().Detect;
        if (Gold == false && Detect == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, Cursor.transform.position, speed * Time.deltaTime);
        }
        else if (Gold == false && Detect == false)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        }
        
    }

}