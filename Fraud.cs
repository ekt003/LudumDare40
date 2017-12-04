using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fraud : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //returns the float to be added to amtFake in Finances
    public float HideMoney(float fakeMoney)
    {
        //decreases perceived income by $50,000
        float amountFake = 50000;

        //makes sure fake money stays above set amount
        if(fakeMoney < 50000)
        {
            amountFake = 0;
        }

        return amountFake;
    }

    //returns the float to be added to amtFake in Finances
    public float FalseDeductions(float fakeMoney)
    {
        //decreases perceived income by 10 percent
        float amountFake = (fakeMoney / 10);

        //makes sure fake money doesn't fall below set amount
        if(fakeMoney < 10000)
        {
            amountFake = 0;
        }

        return amountFake;

    }

    //returns the float to be added to amtFake in Finances
    public float UnderReport(float fakeMoney)
    {
        float amountFake = 10000;

        if(fakeMoney< amountFake)
        {
            amountFake = 0;
        }

        return amountFake;
    }

    //returns the float to be subtracted from yearly taxes for this year
    public float Lobby(float yearlyTax)
    {
        float taxDeducted = yearlyTax / 5;

        if(yearlyTax < 50000)
        {
            taxDeducted = 0;
        }

        return taxDeducted;

    }
}
