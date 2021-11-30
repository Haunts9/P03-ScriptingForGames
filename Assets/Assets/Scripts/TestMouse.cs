using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float zPos = 0f; // or whatever you want to constrain it to

        //in function
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = new Vector3(transform.position.x, transform.position.y, zPos); // this line will alter the z to match the zPos variable
    }
}
