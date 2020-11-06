using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FirstPersonMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 direction = Vector3.zero;

    [SerializeField]
    float maxSpeed = 20f;

    [SerializeField]
    float maxAcceleration = 10f;
    
    Vector3 velocity;
    Vector3 desiredVelocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
        direction = Vector3.zero;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        direction = transform.forward * verticalInput + transform.right * horizontalInput;
        
        direction = Vector3.ClampMagnitude(direction, 1f);
            
    }


    private void FixedUpdate()
    {
        desiredVelocity = direction * maxSpeed;
        velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        float maxSpeedChangeDelta = maxAcceleration * Time.fixedDeltaTime;
        
        velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChangeDelta);
        velocity.z = Mathf.MoveTowards(velocity.z, desiredVelocity.z, maxSpeedChangeDelta);

        rb.velocity = new Vector3(velocity.x, 0f, velocity.z);
       
    }

}
