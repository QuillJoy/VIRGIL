using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EVAScript : MonoBehaviour
{
    public GameObject EVAButton;
    public GameObject canvas;
    public GameObject panelEVA;

    public GameObject MissionObjectivesButton;
    public GameObject UIAStatusButton;
    public GameObject SpectrometerDataButton;

    private Dictionary<string, bool> missionObjectives;

    private bool isShowing;


    void Start()
    {
        panelEVA.SetActive(false);
        //MissionObjectivesButton.SetActive(false);
        //UIAStatusButton.SetActive(false);
        //SpectrometerDataButton.SetActive(false);

    }

    void Update()
    {
    
    }



    public void enableEVACARD()
    {
        EVAButton.SetActive(true);
    }

    public void ButtonPressed()
    {
        isShowing = !isShowing;
        panelEVA.SetActive(isShowing);
        //MissionObjectivesButton.SetActive(isShowing);
        //UIAStatusButton.SetActive(isShowing);
        //SpectrometerDataButton.SetActive(isShowing);

    }
}
