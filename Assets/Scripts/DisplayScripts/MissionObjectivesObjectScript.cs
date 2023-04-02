using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MissionObjectivesObjectScript : MonoBehaviour
{
    //public GameObject buttonGO;
    public TextMeshProUGUI labelInstructions;
    private GameObject confirmObject;
    private bool colorBool;
    private bool retrievedMOObjects;
    public GameObject CalibrationStatusGO;
    public GameObject EgressStatusGO;
    public GameObject SiteNavigationStatusGO;
    public GameObject GeologicalScanningStatusGO;
    public GameObject ROVERStatusGO;
    public GameObject ReturnNavigationStatusGO;

    void Start()
    {
        colorBool = false;
        //buttonGO.GetComponent<Image>().color = Color.red;
    }


    // When user presses button once
    //      Display instructions
    //      Enable button to change mission objectives status
    //      User presses again
    //          BUtton changes color

    public void ConfirmButton()
    {
        if (confirmObject == null)
        {
            labelInstructions.GetComponent<TextMeshProUGUI>().text = "There is nothing selected";
        }
        else
        {
            retrievedMOObjects = FindObjectOfType<MissionObjectivesDataHolder>().GetMissionObjectives()[confirmObject];
            if (retrievedMOObjects == true)
            {
                FindObjectOfType<MissionObjectivesDataHolder>().toggleStatus(confirmObject, false);
                confirmObject.GetComponent<Image>().color = Color.red;
                confirmObject = null;
            }
            else
            {
                FindObjectOfType<MissionObjectivesDataHolder>().toggleStatus(confirmObject, true);
                confirmObject.GetComponent<Image>().color = Color.green;
                confirmObject = null;
            }
        }
    }


    public void setColor(GameObject statusGameObject,  bool dataHolderBool)
    {
        if (dataHolderBool == true)
        {
            statusGameObject.GetComponent<Image>().color = Color.green;
        }
        else
        {
            statusGameObject.GetComponent<Image>().color = Color.red;
        }
    }

    public void OnButtonPressCalibration()
    {
        labelInstructions.GetComponent<TextMeshProUGUI>().text = "" +
            "Calibration is to make sure the VISIONKit, HoloLens 2, " +
            "and Telemetry Stream are working correctly together." +
            "The Objective should have turned green, signalling" +
            " objective success!";
        confirmObject = CalibrationStatusGO;
    }

    public void OnButtonPressEgress()
    {
        labelInstructions.GetComponent<TextMeshProUGUI>().text = "" +
            "To complete Egress, refer to the UIA data found in" +
            " 'UIA'. It will show the current positions of the switches." +
            "Once they are in the correct positions, the Egress Objective " +
            "should automatically be toggled green.";
        confirmObject = EgressStatusGO;
    }

    public void OnButtonPressSiteNav()
    {
        labelInstructions.GetComponent<TextMeshProUGUI>().text = "" +
            "The status of this Objective needs to be toggled" +
            "manually. During Site Navigation, you will be placing " +
            "Flags to keep track of your path. You may " +
            "find more navigation information in the NAV Card. ";
        confirmObject = SiteNavigationStatusGO;
    }

    public void OnButtonPressGeoScan()
    {
        labelInstructions.GetComponent<TextMeshProUGUI>().text = "" +
            "The status of this Objective needs to be toggled manually. " +
            "During Geological Scanning, you will scan rocks with " +
            "RFID tags. You may find a list of all recently scanned " +
            "RFID tags in 'Spectrometer Data'.";
        confirmObject = GeologicalScanningStatusGO;
    }

    public void OnButtonPressROVER()
    {
        labelInstructions.GetComponent<TextMeshProUGUI>().text = "" +
            "The status of this Objective needs to be toggled manually. " +
            "During this section, you will command the ROVER through " +
            "recall orders as well custom location orders. To find more " +
            "information, please see the ROVER Card. ";
        confirmObject = ROVERStatusGO;
    }

    public void OnButtonPressReturnNav()
    {
        labelInstructions.GetComponent<TextMeshProUGUI>().text = "" +
            "During Return Navigation, you will be retracing your " +
            "steps using the NAV Card as well as scanning any rocks " +
            "with RFID tags. ";
        confirmObject = ReturnNavigationStatusGO;
    }
}