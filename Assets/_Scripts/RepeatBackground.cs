using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class RepeatBackground : MonoBehaviour
{

    private Vector3 startPos;
    private float repeatWidth;
    // Start is called before the first frame update
    void Start()
    {
        repeatWidth = GetComponent<BoxCollider>().size.x;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(startPos.x - this.transform.position.x>(repeatWidth/ 2))
        {
            transform.position = startPos;
        }
    }
}
