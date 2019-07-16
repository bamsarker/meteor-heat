using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{

    public float maxSpeed = 5.0f;
    public float acceleration = 2.0f;
    private float currentSpeed = 0.0f;
    public float turnSpeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentSpeed += Input.GetAxis("Vertical") != 0 ? Input.GetAxis("Vertical") * acceleration : (currentSpeed * -1.0f) * Time.deltaTime;
        currentSpeed = currentSpeed > maxSpeed ? maxSpeed : currentSpeed;
        if (Input.GetAxis("Horizontal") != 0) {
            transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0);
        }
        Debug.DrawLine(this.transform.position, this.transform.position + this.transform.forward, Color.red);
        if (currentSpeed > 0) {
            this.transform.Translate(this.transform.forward * currentSpeed * Time.deltaTime, Space.World);
        }

    }
}
