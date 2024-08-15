using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorChecker : MonoBehaviour
{

    public int floorNumberPlayer;
    public bool elevatorOneRotated;
    public bool elevatorTwoRotated;
    public bool startFloor;
    
    // Start is called before the first frame update
    void Start()
    {
        floorNumberPlayer = 10;   
        elevatorOneRotated = false;
        elevatorTwoRotated=false;
        startFloor = true;
        
    }
    

}
