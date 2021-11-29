using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushyScript : MonoBehaviour
{
    GameObject Player;
    public GameObject GoldiLocks;
    public float speed = 10f;
    public Rigidbody2D rb;
    public bool Gold = false;
    public bool InBar = false;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Gold = GoldiLocks.GetComponent<MushyGoldilocks>().Gold;

        if (Gold == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
        }
        
    }

}