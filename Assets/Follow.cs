using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {
    
    public GameObject objectToFollow;
    
    public float speed = 2.0f;

    public Vector3 offset;
    
    void Update () {
        float interpolation = speed * Time.deltaTime;
        
        Vector3 position = this.transform.position;
        Vector3 rotation = this.transform.rotation.eulerAngles;
        position.y = Mathf.Lerp(this.transform.position.y, objectToFollow.transform.position.y + offset.y, interpolation);
        position.x = Mathf.Lerp(this.transform.position.x, objectToFollow.transform.position.x + offset.x, interpolation);
        position.z = Mathf.Lerp(this.transform.position.z, objectToFollow.transform.position.z + offset.z, interpolation);
        
        Vector3 direction = (objectToFollow.transform.position + offset) - transform.position;
        Quaternion toRotation = Quaternion.FromToRotation(transform.forward, direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, interpolation);
        
        this.transform.position = position;
    }
}