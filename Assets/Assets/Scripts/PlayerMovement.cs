using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator Anim;
    ParticleSystem Running;
    SpriteRenderer Rend;
    public float speed = 100f;
    public Rigidbody2D rb;
    public void Start()
    {
        Running = GetComponent<ParticleSystem>();
        Anim = GetComponent<Animator>();
        Rend = GetComponent<SpriteRenderer>();
    }
    public void FixedUpdate()
    {
        Flip();
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 tempVect = new Vector3(h, v, 0);
        tempVect = tempVect.normalized * speed * Time.deltaTime;
        rb.MovePosition(rb.transform.position + tempVect);
        MovementParticle();
    }

    void MovementParticle()
    {
       // Debug.Log(rb.velocity.magnitude);
        if (rb.IsAwake())
        {
            Anim.SetBool("Walking", true);
            if (!Running.isPlaying) { Running.Play(); }
        }
        else
        {
            Anim.SetBool("Walking", false);
            if (Running.isPlaying) { Running.Stop(); }
        }
    }

    void Flip()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        if (moveHorizontal < 0)
        {
            Rend.flipX = true;
        }
        if (moveHorizontal > 0)
        {
            Rend.flipX = false;
        }
    }
}
