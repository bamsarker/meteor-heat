using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerpendicularToGround : MonoBehaviour
{

    void Start()
    {
        RotateSelf();
    }

    void RotateSelf()
    {
        RaycastHit hit;
        Ray ray = new Ray(this.transform.position, -this.transform.up);

        if (Physics.Raycast(ray, out hit))
        {
            Debug.DrawLine(this.transform.position, hit.point, Color.green);
            this.transform.rotation = Quaternion.FromToRotation(this.transform.up, hit.normal) * this.transform.rotation;
        }
    }

    void Update()
    {
        RotateSelf();
    }
}
