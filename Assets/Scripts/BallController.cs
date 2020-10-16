using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private bool inPossession = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool isInPossession() {
        return inPossession;
    }

    public void setInPossesionState(bool possessed) {
        inPossession = possessed;
    }
}
