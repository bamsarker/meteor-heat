using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerpendicularToGround : MonoBehaviour
{

    private Rigidbody thisRb;
    public Transform camera;
    private Vector3 fallOff;
    private bool fellOff;

    void Start()
    {
        thisRb = GetComponent<Rigidbody>();
        RotateSelf();
    }

    public void RotateSelf()
    {
        RaycastHit hit;
        Ray ray = new Ray(this.transform.position, -this.transform.up);

        if (Physics.Raycast(ray, out hit, 5.0f))
        {
            Debug.DrawLine(this.transform.position, hit.point, Color.green);
            thisRb.useGravity = false;
            if (fellOff)
            {
                fellOff = false;
            }
            this.transform.rotation = Quaternion.FromToRotation(this.transform.up, hit.normal) * this.transform.rotation;
        }
        else
        {
            thisRb.useGravity = true;
            if (!fellOff)
            {
                fallOff = transform.position;
                fellOff = true;
            }
        }
    }

    void CheckFallOffDistance()
    {
        if (transform.position.y + 10.0f < fallOff.y)
        {
            camera.GetComponent<Follow>().enabled = false;
            Destroy(this);
        }
    }

    void Update()
    {
        // RotateSelf();
        if (fellOff)
        {
            CheckFallOffDistance();
        }
    }
}
