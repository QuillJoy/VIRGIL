using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

/*-------------------------------------------------------*/
/*  Script that lets an object:
 *   
 *   1. Initalize a hashmap to store Rock samples
 *      using their RFIDs.
 *   2. Allow other objects to access the hashmap.
 *   
 *   To use for ConnScript, call setFloat(...), somehow...
 *     
 *      
 *--------------------------------------------------------*/


public class SpectrometerDataHolderScript : MonoBehaviour
{
    public Dictionary<string, float> spectrometerData;

    public TMPro.TMP_Text SiO2Info;
    public TMPro.TMP_Text TiO2Info;
    public TMPro.TMP_Text Al2O3;
    public TMPro.TMP_Text FeOInfo;
    public TMPro.TMP_Text MgOInfo;
    public TMPro.TMP_Text MnOInfo;
    public TMPro.TMP_Text CaOInfo;
    public TMPro.TMP_Text K2OInfo;
    public TMPro.TMP_Text P2O3Info;

    public TMPro.TMP_Text LastUpdatedInfo;
    string LastUpdatedString;
    void Start()
    {

    }

    public void HouseKeeping()
    {
        spectrometerData = new Dictionary<string, float>();
        spectrometerData.Add("SiO2", 0.0f);
        spectrometerData.Add("TiO2", 0.0f);
        spectrometerData.Add("Al2O3", 0.0f);
        spectrometerData.Add("FeO", 0.0f);
        spectrometerData.Add("MnO", 0.0f);
        spectrometerData.Add("MgO", 0.0f);
        spectrometerData.Add("CaO", 0.0f);
        spectrometerData.Add("K2O", 0.0f);
        spectrometerData.Add("P2O3", 0.0f);

        StartCoroutine(CoroutineUpdate());

    }

    private void Update()
    {
    }

    IEnumerator CoroutineUpdate()
    {
        while (true)
        {
            displayScanFloats();
            yield return null;
        }

    }

    public void setScanFloats(float sio2, float tio2, float al2o3, float feo, float mno, float mgo, float cao, float k2o, float p2o3)
    {
        spectrometerData["SiO2"] = sio2;
        spectrometerData["TiO2"] = tio2;
        spectrometerData["Al2O3"] = al2o3;
        spectrometerData["FeO"] = feo;
        spectrometerData["MnO"] = mno;
        spectrometerData["MgO"] = mgo;
        spectrometerData["CaO"] = cao;
        spectrometerData["K2O"] = k2o;
        spectrometerData["P2O3"] = p2o3;

    }



    public Dictionary<string,float> GetSpectroData()
    {
        return spectrometerData;
    }

    public void setFloat(string rock, float newfloat, string telemLastUpdated)
    {
        spectrometerData[rock] = newfloat;
        LastUpdatedString = telemLastUpdated;
    }

    public void displayScanFloats()
    {
        SiO2Info.text = "" + spectrometerData["SiO2"];
        TiO2Info.text = "" + spectrometerData["TiO2"];
        Al2O3.text = "" + spectrometerData["Al2O3"];
        FeOInfo.text = "" + spectrometerData["FeO"];
        MgOInfo.text = "" + spectrometerData["MgO"];
        MnOInfo.text = "" + spectrometerData["MnO"];
        CaOInfo.text = "" + spectrometerData["CaO"];
        K2OInfo.text = "" + spectrometerData["K2O"];
        P2O3Info.text = "" + spectrometerData["P2O3"];

        LastUpdatedInfo.text = LastUpdatedString;

    }
}
