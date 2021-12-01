using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushyScript : MonoBehaviour
{
    GameObject Cursor;
    ParticleSystem Running;
    public GameObject GoldiLocks;
    public GameObject DetectRange;
    public Cursor Curse;
    public float speed = 10f;
    public Rigidbody2D rb;
    public bool Gold = false;
    public bool InBar = false;
    public bool Detect = false;
    public bool Freeze = false;
    // Start is called before the first frame update
    void Start()
    {
        Running = GetComponent<ParticleSystem>();
        Cursor = GameObject.FindGameObjectWithTag("Cursor");
        Curse = Cursor.GetComponent<Cursor>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Freeze = Curse.mtoggle;
        MovementParticle();
        Gold = GoldiLocks.GetComponent<MushyGoldilocks>().Gold;
        Detect = DetectRange.GetComponent<MushyDetectRange>().Detect;
        if (Gold == false && Detect == true && Freeze == false)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            transform.position = Vector2.MoveTowards(transform.position, Cursor.transform.position, speed * Time.deltaTime);
        }
        else if ((Gold == false && Detect == false) || Freeze == true)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        }
        
    }

    void MovementParticle()
    {
        if (rb.IsAwake())
        {
            if (!Running.isPlaying) { Running.Play(); }
        }
        else
        {
            if (Running.isPlaying) { Running.Stop(); }
        }
    }

}