using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float forwardSpeed = 25.0f, strafeSpeed = 75.0f,  hoverSpeed = 75.0f, rollSpeed = 90.0f;
    public float activeForwardSpeed, activeStrafeSpeed, activeHoverSpeed, activeRoll;
    public float forwardAccel = 2.5f, strafeAccel = 2.0f, hoverAccel = 2.0f, rollAccel = 10.0f;

    public Vector2 lookDirectionInput, centerOfScreen, distancefromScreenCenter;
    public float navigateSpeed = 90f;

    
    void Start()
    {
            centerOfScreen.x = Screen.width/2.0f;
            centerOfScreen.y = Screen.height/2.0f;

            Cursor.lockState =CursorLockMode.Confined; 
        
    }

    void Update()
    {
            lookDirectionInput.x = Input.mousePosition.x;
            lookDirectionInput.y = Input.mousePosition.y;

            distancefromScreenCenter.x = (lookDirectionInput.x - centerOfScreen.x)/centerOfScreen.y;
            distancefromScreenCenter.y = (lookDirectionInput.y - centerOfScreen.y)/ centerOfScreen.y;

            transform.Rotate(-distancefromScreenCenter.y * navigateSpeed * Time.deltaTime, distancefromScreenCenter.x * navigateSpeed * Time.deltaTime, activeRoll * rollSpeed * Time.deltaTime, Space.Self);

            activeForwardSpeed = Mathf.Lerp(activeForwardSpeed, Input.GetAxisRaw("Vertical") * forwardSpeed, forwardAccel * Time.deltaTime);
            activeStrafeSpeed = Mathf.Lerp(activeStrafeSpeed, Input.GetAxisRaw("Horizontal") * strafeSpeed, strafeAccel *Time.deltaTime );
            activeHoverSpeed = Mathf.Lerp(activeHoverSpeed, Input.GetAxisRaw("Hover") * hoverSpeed, hoverAccel * Time.deltaTime);
            activeRoll = Mathf.Lerp(activeRoll, Input.GetAxisRaw("Roll"), rollAccel * Time.deltaTime);

            transform.position += (transform.forward * activeForwardSpeed * Time.deltaTime) + 
                                (transform.right * activeStrafeSpeed * Time.deltaTime) + (transform.up * activeHoverSpeed * Time.deltaTime);

            distancefromScreenCenter = Vector2.ClampMagnitude(distancefromScreenCenter, 1.0f);  
    }
}
