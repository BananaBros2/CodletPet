using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class FishScript : MonoBehaviour
{
    public float speed = 10;
    public float turnSpeed = 200;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
        transform.eulerAngles += new Vector3(0, Time.deltaTime * turnSpeed, 0);
    }
}
