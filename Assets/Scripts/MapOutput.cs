using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapOutput : MonoBehaviour
{
    //public GameObject irlScale;
    public GameObject user;
    //public GameObject map;
    //public GameObject marker;

    // Start is called before the first frame update
    private void Start()
    {
        // putting everything from Update() in here also works, just won't move marker after start
    }

    // Update is called once per frame
    // Could probably remove variable count by combining them into longer calculations, but left them to show what each one is with a name.
    void Update()
    {
        //float xMeter = irlScale.transform.localScale.x * 10; //101
        //float zMeter = irlScale.transform.localScale.z * 10; //94.3
        //float xDiff = 101 - 0; //101
        //float zDiff = 0 - 94.3f; //-94.3
        float userXPos = user.transform.position.x; //75
        float userZPos = user.transform.position.z; //-25

        print("X: " + userXPos + ", Z:" + userZPos);
        //float markerX = xDiff - userXPos; //101 - 75 = 26
        //float markerZ = zDiff - userZPos; //-94.3 - (-25) = -69.3
        //float ratioPointX = markerX / xDiff; //0.25742574257
        //float ratioPointZ = markerZ / zDiff; //0.73488865323
        //float xMapPos = map.transform.position.x; //275
        //float yMapPos = map.transform.position.y; //40
        //var rectTransform = GetComponent<RectTransform>();
        //float width = rectTransform.sizeDelta.x; //303
        //float height = rectTransform.sizeDelta.y; //283
        //float xRightBorder = xMapPos + (width / 2.0f); //275 + (303/2) = 426.5

        //double xLeftBorder = xMapPos - (width / 2.0); //275 - (303/2)
        //double yTopBorder = yMapPos + (height / 2.0); //40 + (283/2) = 181.5

        //float yBotBorder = yMapPos - (height / 2.0f); //40 - (283/2) = -101.5
        //float xPos = xRightBorder - (width * ratioPointX); //426.5 - (303x.25)
        //float yPos = yBotBorder + (height * ratioPointX); //-101.5 + (283x.75)
        //Vector3 newPos = new Vector3(xPos, yPos, 0);
        //marker.transform.position = newPos;
    }
}

//Hardcode version: OUTDATED
//Get the scale values of the plane and multiply them by 10 
//The user's X will be from 0 to 100 and Z will be from 0 to -100
//Store the far right X and the highest Z as max
//Calculate absolute and this hard code version should have a diff of 100 on both X and Z
//The max X would be 100 and the max Z would be 0, each with dif values of 100
//The min X would be 0 and the min Z would be -100
//If user values are 75,-25

//PSUEDOCODE:
//GameObject marker;
//vector3 objectScale = transform.localScale;
//double xMeter = objectScale.x*10; 101
//double zMeter = objectScale.z*10; 94.3
//double xDiff = 101 - 0; 101
//double zDiff = 0 - 94.3; -94.3
//userXPos = player.x; 75
//userZPos = player.z; -25
//markerX = xDiff - userXPos; 101 - 75 = 26
//markerZ = zDiff - userZPos; -94.3 - (-25) = -69.3
//ratioPointX = markerX / xDiff; 0.25742574257
//ratioPointZ = markerZ / zDiff; 0.73488865323
//xMapPos; 275
//yMapPos; 40
//var rectTransform = GetComponent<RectTransform>();
//float width = rectTransform.sizeDelta.x; 303
//float height = rectTransform.sizeDelta.y; 283
//xRightBorder = xMapPos + (width/2.0); 275 + (303/2) = 426.5
//xLeftBorder = xMapPos - (width/2.0); 275 - (303/2)
//yTopBorder = yMapPos + (height/2.0); 40 + (283/2) = 181.5
//yBotBorder = yMapPos - (height/2.0); 40 - (283/2) = -101.5
//marker.x = xRightBorder - (width*ratioPointX); 426.5 - (303x.25)
//marker.y = yBotBorder + (height*ratioPointX); -101.5 + (283x.75)