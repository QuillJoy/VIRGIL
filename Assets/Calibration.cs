using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**********************************/
/*       Calibration Script
 * ********************************
 * This script will ask the User to
 * do two actions:
 *   1. Walk 1 meter in the x 
 *   direction.
 *   
 *   2. Look 90 degrees to 
 *   the right.
 *   
 * The script will then retrieve 
 * data from the telemetry stream
 * to verify that VISION is working.
 * 
 * Any line with "Debug.Log" may be
 * replaced with Isaac's display
 * solution
 * 
 * 
 * 
 * 
/*                               */
/**********************************/
public class Calibration : MonoBehaviour
{
    Vector3 initialPosition;
    Vector3 currentPosition;
    float initialAngleY;
    float currentAngleY;
    bool sentinel1;
    bool sentinel2;
    void Start()
    {
        // Add the Instruction functions as events in 
        // the EventManager
        EventManager.CalibrationEvent1 += Instruction1;
        EventManager.CalibrationEvent2 += Instruction2;
    }

    // Each instruction will display instructions on
    // the screen and then execute data verification.
    private void Instruction1()
    {
        sentinel1 = false;
        Debug.Log("Please move 1 meter forward");
        StartCoroutine(calibration1());
    }

    private void Instruction2()
    {
        Debug.Log("Please look 90 degrees to your right");
        StartCoroutine(calibration2());
    }

    // calibration1 and calibration2 
    IEnumerator calibration1()
    {
        initialPosition = FindObjectOfType<TelemetryStream>().getCurrentPosition();
        Vector3 goalPosition = initialPosition + new Vector3(1.0f, 0.5f, 0.0f);
        currentPosition.x = FindObjectOfType<TelemetryStream>().getCurrentPosition().x;
        while (currentPosition.x < goalPosition.x)
        {
            currentPosition.x = FindObjectOfType<TelemetryStream>().getCurrentPosition().x;
            yield return null;
        }
        sentinel1 = true;
        Debug.Log("One meter walked. Thank you!");
    }

    public bool getBool1()
    {
        return sentinel1;
    }
    public bool getBool2()
    {
        return sentinel2;
    }


    IEnumerator calibration2()
    {
        initialAngleY = FindObjectOfType<TelemetryStream>().getCurrentAngleY();
        float goalAngle = initialAngleY + (90);
        currentAngleY = FindObjectOfType<TelemetryStream>().getCurrentAngleY();
        while (currentAngleY < goalAngle)
        {
            currentAngleY = FindObjectOfType<TelemetryStream>().getCurrentAngleY();
            yield return null;
        }
        sentinel2 = true;
        Debug.Log("Looked 90 degrees to the right. Thank you!");
  
    }
}
