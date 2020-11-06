using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonLook : MonoBehaviour
{
    [SerializeField]
    private float HorizontalMouseSensitivity = 100f;
    [SerializeField]
    private float VerticalMouseSensitivity = 100f;
    private Transform player;
    float accumulatedVerticalRotation;

    const float MAX_ROTATION_UP = 90f;
    const float MAX_ROTATION_DOWN = -90f;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInParent<FirstPersonMovement>().transform;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        
        Rotate();
    }

    private void Rotate()
    {
        RotateHorizontally();
        RotateVertically();
    }

    private void RotateHorizontally()
    {
        float horizontalMouseMovement = Input.GetAxis("Mouse X");
        player.Rotate(Vector3.up * horizontalMouseMovement * Time.deltaTime * HorizontalMouseSensitivity);
    }


    private void RotateVertically()
    {
        float verticalMouseMovement = Input.GetAxis("Mouse Y");
        float verticalDeltaRotation = verticalMouseMovement * VerticalMouseSensitivity * Time.deltaTime;
        accumulatedVerticalRotation -= verticalDeltaRotation;
        accumulatedVerticalRotation = Mathf.Clamp(accumulatedVerticalRotation, MAX_ROTATION_DOWN, MAX_ROTATION_UP);

        transform.localRotation = Quaternion.Euler(accumulatedVerticalRotation, 0f, 0f);
    }

   
   
}
