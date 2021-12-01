using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushyGoldilocks : MonoBehaviour
{
    public bool Gold = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("GoldFail");
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Cursor")
        {
            Gold = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Cursor")
        {
            Gold = false;
        }
    }

    private IEnumerator GoldFail()
    {
        Gold = false;
        yield return new WaitForSeconds(1f);
        StartCoroutine("GoldFail");
    }
}
