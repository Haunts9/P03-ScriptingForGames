using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushyDetectRange : MonoBehaviour
{
    public bool Detect = false;
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Cursor")
        {
            Detect = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Cursor")
        {
            Detect = false;
        }
    }
}
