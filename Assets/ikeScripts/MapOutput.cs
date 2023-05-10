using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Microsoft.MixedReality.Toolkit.UX;
using UnityEngine.XR.Interaction.Toolkit;

public class MapOutput : MonoBehaviour
{
    public GameObject user;

    public TMPro.TMP_Text latitude;
    public TMPro.TMP_Text longitude;
    public TMPro.TMP_Text altitude;
    public GameObject userMarker;
    public GameObject roverMarker;
    float userXPos;
    float userZPos;
    float userRotationY;

    public GameObject flag;
    public GameObject mapFlag;

    public MRTKTMPInputField mrtkDisplayEnterLong;
    float distance;
    public GameObject farRay;
    public TMPro.TMP_Text timerInfo;

    public GameObject crumb1;
    public GameObject crumb2;
    public GameObject crumb3;
    public GameObject mapCrumb1;
    public GameObject mapCrumb2;
    public GameObject mapCrumb3;
    public GameObject breadCrumbHolder;
    bool isBreadcrumbsOn = true;

    float realOriginLat;
    float realOriginLon;
    float realBearing;
    float realAltitude;

    public TMPro.TMP_Text realOriginInfo;
    Vector3 realOriginVector;
    Vector3 realUserPosVector;
    Vector3 realRoverPosVector;
    Vector3 virtualUserPos;
    Vector3 virtualRoverPos;

    private void Start()
    {
        breadCrumbHolder.SetActive(false);
        StartCoroutine(breadCrumbSystemCoroutine());

    }


    void Update()
    {
        // put calculation functions here (1)
        userXPos = user.transform.position.x; // delete these(2)
        userZPos = user.transform.position.z;

        userRotationY = user.transform.rotation.eulerAngles.y; // replace this with set bearing (3)


        userMarker.transform.position = new Vector3(userXPos, 86.0f, userZPos); // delete (4)
        userMarker.transform.rotation = Quaternion.Euler(90.0f, userRotationY, 0.0f); // delete (5)

        latitude.text = "" + userXPos; // replace with virtual.x (6)
        longitude.text = "" + userZPos;// replace with virtual.z (7)

    }
    public void setAltitude(float altFromTelem)
    {
        realAltitude = altFromTelem;
    }
    public void setBearing(float bearingFromTelem)
    {
        realBearing = bearingFromTelem; 
        userMarker.transform.rotation = Quaternion.Euler(90.0f, realBearing, 0.0f);
    }

    public void setRealOriginPoint(float realOriginPointLat, float realOriginPointLon)
    {
        realOriginLat = realOriginPointLat;
        realOriginLon = realOriginPointLon;
        realOriginInfo.text = "Real origin lat: " + realOriginLat + " Real origin lon: " + realOriginLon;
        realOriginVector = new(realOriginLat, 0f, realOriginLon);
    }

    public void calculateUserLatLongDistanceFromOrigin(float userRealLat, float userRealLon)
    {

        realUserPosVector = new(userRealLat, 0f, userRealLon);

        virtualUserPos = realUserPosVector - realOriginVector; // actual real life origin is 29deg33min53sec N, 095deg04min53sec W

        userMarker.transform.position = new Vector3(virtualUserPos.x, 86.0f, virtualUserPos.y);
    }

    public void calculateRoverLatLongDistanceFromOrigin(float roverRealLat, float roverRealLon)
    {
        realRoverPosVector = new(roverRealLat, 0f, roverRealLon);

        virtualRoverPos = realRoverPosVector - realOriginVector;

        roverMarker.transform.position = new Vector3(virtualRoverPos.x, 86.0f, virtualRoverPos.y);
    }

    public void returnBtn()
    {
        isBreadcrumbsOn = !isBreadcrumbsOn;
        breadCrumbHolder.SetActive(isBreadcrumbsOn);

        if (isBreadcrumbsOn)
        {
            StartCoroutine (breadCrumbSystemCoroutine());
        }
    }


    public void submitDistance()
    {

        // get foot distance 
        distance = float.Parse(mrtkDisplayEnterLong.text);
        float altitude = 1.72f;
        float x = altitude / distance;
        float angle = Mathf.Acos(x);
        float distanceActual = Mathf.Sin(angle) * distance;

        // calculate position of flag
        float radians = (userRotationY / 180.0f) * 3.14f; // replace with bearing (8)
        float horizCompVector = distanceActual * Mathf.Sin(radians);
        float vertCompVector = distanceActual * Mathf.Cos(radians);
        
        //offset flag position from user position
        float flagXPos = userXPos + horizCompVector; // replace with virtual.x (9)
        float flagZPos = userZPos + vertCompVector;  // replace with virtual.z (10)

        Instantiate(flag, new Vector3(flagXPos, 0.5f, flagZPos), Quaternion.Euler(0, 0, 0));
        Instantiate(mapFlag, new Vector3(flagXPos, 100.0f, flagZPos), Quaternion.Euler(0, 0, 0));
    }


    public void timedFlagPlacement()
    {
        StartCoroutine(coroutine1());
        StartCoroutine(coroutine2());
    }

    IEnumerator breadCrumbSystemCoroutine()
    {
        Vector3 oldPosition = new Vector3(userXPos, 0.3f, userZPos); // replace with virtual (11)
        int colorCounter = 0;
        while (isBreadcrumbsOn)
        {

            Vector3 newPosition = new Vector3(userXPos, 0.3f, userZPos);// replace with virtual (12)

            Vector3 diff = newPosition - oldPosition;
            float magnitude = Mathf.Sqrt(Mathf.Pow(diff.x, 2) + Mathf.Pow(diff.z, 2));
            if  (magnitude > .75f) // change (??)
            {
                print("Placing a breadcrumb...");
                if (colorCounter == 0)
                {
                    Instantiate(crumb1, new Vector3(userXPos, 0.3f, userZPos), Quaternion.Euler(0, userRotationY - 90.0f, 0), breadCrumbHolder.transform); // replace with virtual (13)
                    Instantiate(mapCrumb1, new Vector3(userXPos, 86f, userZPos), Quaternion.Euler(0, userRotationY - 90.0f, 0), breadCrumbHolder.transform);// replace with virtual (14)
                } else if (colorCounter == 1)
                {
                    Instantiate(crumb2, new Vector3(userXPos, 0.3f, userZPos), Quaternion.Euler(0, userRotationY - 90.0f, 0), breadCrumbHolder.transform); // replace with virtual (15)
                    Instantiate(mapCrumb2, new Vector3(userXPos, 86f, userZPos), Quaternion.Euler(0, userRotationY - 90.0f, 0), breadCrumbHolder.transform);// replace with virtual (16)

                } else if (colorCounter == 2)
                {
                    Instantiate(crumb3, new Vector3(userXPos, 0.3f, userZPos), Quaternion.Euler(0, userRotationY - 90.0f, 0), breadCrumbHolder.transform);// replace with virtual (17)
                    Instantiate(mapCrumb2, new Vector3(userXPos, 86f, userZPos), Quaternion.Euler(0, userRotationY - 90.0f, 0), breadCrumbHolder.transform);// replace with virtual (18)
                }

                oldPosition = newPosition;
                colorCounter++;
            }

            if (colorCounter == 3)
            {
                colorCounter = 0;
            }
            
            yield return new WaitForSeconds(2f);
        }
    }

    IEnumerator coroutine1()
    {
        float totalTime = Time.time + 5.0f;

        while (Time.time < totalTime)
        {
            float currentTime = Time.time;
            currentTime = totalTime - currentTime;
            timerInfo.text = "" + (int)currentTime;
            yield return null;
        }


    }
    IEnumerator coroutine2()
    {

        yield return new WaitForSeconds(5f);
        var ray = new Ray(farRay.transform.position, farRay.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            Instantiate(flag, hit.point, Quaternion.Euler(0, 0, 0));
        }
    }
}



