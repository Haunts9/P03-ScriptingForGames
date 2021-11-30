using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushyBarrier : MonoBehaviour
{
    public Rigidbody2D rb;
    GameObject Player;
    public GameObject Mushy;
    public bool Gold = false;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = Mushy.GetComponent<MushyScript>().speed;
        Player = GameObject.FindGameObjectWithTag("Cursor");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Gold = Mushy.GetComponent<MushyScript>().Gold;

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if ((other.gameObject.tag == "Player" || other.gameObject.tag == "Mushy") && Gold == false)
        {
            Mushy.transform.position = Vector2.MoveTowards(Mushy.transform.position, other.gameObject.transform.position, -1 * (speed * 1.1f) * Time.deltaTime);
        }
    }
}
