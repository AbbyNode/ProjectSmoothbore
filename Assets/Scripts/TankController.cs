using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{

    public float maxSpeed = 2; // Units per second
    public float rotationSpeed = 360; // Degrees per second
    public int controllerNumber;

    void Update()
    {
        Vector2 inputMove = Vector2.zero;
        inputMove.x = Input.GetAxis("Horizontal" + controllerNumber);
        inputMove.y = Input.GetAxis("Vertical" + controllerNumber);

        if (inputMove != Vector2.zero)
        {
            // Input angle, clamped between 0 and 360
            float inputAngle = (Mathf.Atan2(inputMove.y, inputMove.x) * Mathf.Rad2Deg);
            while (inputAngle < 0)
            {
                inputAngle += 360;
            }

            float currentAngle = transform.eulerAngles.z;

            // Angle diff, soft clamped between -180 and 180
            float angleDiff = inputAngle - currentAngle;
            if (angleDiff < -180)
            {
                angleDiff += 360;
            }
            else if (angleDiff > 180)
            {
                angleDiff -= 360;
            }
            else if (angleDiff == 180)
            { // Prefer clockwise full turns;
                angleDiff = -180;
            }

            // Rotate if needed
            if (angleDiff != 0)
            {
                float rotateAmt = Time.deltaTime * rotationSpeed; // Usual rotate amt
                if (angleDiff < 0)
                {
                    rotateAmt *= -1;
                    rotateAmt = Mathf.Max(rotateAmt, angleDiff); // Clamp with angleDiff
                }
                else
                { // angleDiff > 0
                    rotateAmt = Mathf.Min(rotateAmt, angleDiff); // Clamp with angleDiff
                }
                transform.eulerAngles = new Vector3(0, 0, currentAngle + rotateAmt); // Add to rotation
            }

            // Move
            if (Input.GetAxisRaw("Anchor") == 0)
            { // Not anchored
                float moveAmt = Time.deltaTime * maxSpeed; // Usual move amt
                moveAmt *= ((180 - Mathf.Abs(angleDiff)) / 180); // Reduce if facing away
                transform.position += transform.right * moveAmt;
                Debug.Log("moving");
            }
        }
    }
}
