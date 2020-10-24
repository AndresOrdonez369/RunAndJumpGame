using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMove : MonoBehaviour
{
    [Range(0,90)]
    public float velocityMove=10; // Start is called before the first frame update
    [Range(0,90)]
    public float rotateMove=70;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.left*Time.deltaTime*1);
        transform.localPosition+=Vector3.left*Time.deltaTime*velocityMove;
        transform.Rotate(Vector3.up*Time.deltaTime*rotateMove); 
    }
}
