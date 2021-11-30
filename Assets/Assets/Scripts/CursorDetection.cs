using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorDetection : MonoBehaviour
{
    public bool inRadius = false;
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            inRadius = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            inRadius = false;
        }
    }
}
