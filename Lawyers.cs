using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lawyers : MonoBehaviour {

    //fields

    //0 is no lawyer, 1 is junior partner, 2 is associate, 3 is finance and securities lawyer
    public int lawyerType;

    //type of lawyer to be displayed in game
    public string lawyerStr;

	// Use this for initialization
	void Start () {
        lawyerType = 0;
        lawyerStr = "None";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //accessors for lawyers
    public int LawyerType
    {
        get { return lawyerType; }
        set { lawyerType = value; }
    }

    //returns the chance reduction recieved from lawyer based on lawyer type
    public float CalcInvesDeduct()
    {
        switch (lawyerType)
        {
            case 0: return 0;

            case 1: return 10;

            case 2: return 20;

            case 3: return 35;
        }

        return 0;
    }

    //returns the percentage the player's lawyer decreases the IRS deduction
    public float CalcPenDeduct()
    {
        switch (lawyerType)
        {
            case 0: return 0;

            case 1: return 15;

            case 2: return 30;

            case 3: return 50;
        }

        return 0;
    }

    public string GetLawyerStr()
    {
        switch(lawyerType)
        {
            case 0: lawyerStr = "None";
                break;

            case 1: lawyerStr = "Junior Partner";
                break;

            case 2: lawyerStr = "Associate";
                break;
            case 3: lawyerStr = "Finance and Securities Lawyer";
                break;

        }

        return lawyerStr;
    }
}
