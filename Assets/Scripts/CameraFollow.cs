
using UnityEngine;


public class Camera : MonoBehaviour
{
    [SerializeField] float turnSpeed = 15.0f;
    [SerializeField] Transform cat;
    [SerializeField] float speed = 2.0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x_movement = Input.GetAxis("Mouse X");
        float y_movement = Input.GetAxis("Mouse Y");
        transform.Rotate(new Vector3(y_movement, x_movement, 0)*Time.deltaTime*turnSpeed);
        
    }
    void LateUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position ,cat.position, 10*Time.deltaTime);
    }
}
