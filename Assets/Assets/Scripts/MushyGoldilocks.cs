using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushyGoldilocks : MonoBehaviour
{
    public bool Gold = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Gold = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Gold = false;
        }
    }
}
