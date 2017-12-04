using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IRS : MonoBehaviour {

    //chance of investigation
    public float investChance;

    //penalty if investigated
    public float penalty;

	// Use this for initialization
	void Start () {
        investChance = 0;
	}

    //accessors for chance value
    public float InvestChance
    {
        get { return investChance; }
        set { investChance = value; }
    }

    // Update is called once per frame
    void Update () {
		
	}

    public bool Investigate(float playerMoney, float playerMoneyFake, float yearNum, float lawBenefit, float numStocks)
    {
        int chanceNum = Random.Range(0, 100);

        if (chanceNum < CalcChance(playerMoney, playerMoneyFake, yearNum, lawBenefit, numStocks))
        {
            return true;
        }

        return false;
    }

    public float CalcChance(float playerMoney, float playerMoneyFake, float yearNum, float lawBenefit, float numStocks)
    {
        //start with a chance of zero to be discovered
        float chanceVal = 0;

        //number of years passed increases investigation chance
        if(yearNum > 10)
        {
            chanceVal += 25;
        }
        else
        {
            chanceVal += (yearNum * yearNum) / 4f;
        }

        //number of stocks increases investigation chance
        if(numStocks > 100)
        {
            chanceVal += 15;
        }
        else
        {
            chanceVal += numStocks / 100f;
        }

        //amount of money the player is hiding increases investigation chance
        if(playerMoney - playerMoneyFake > 1000000)
        {
            chanceVal += 40;
        }
        else
        {
            chanceVal += (playerMoney - playerMoneyFake) / 50000;
        }

        //type of lawyer reduces chance
        chanceVal -= lawBenefit;

        //there should always be a chance to get caught
        if(chanceVal < 5)
        {
            chanceVal = 5;
        }

        investChance = chanceVal;

        return chanceVal;


    }

    public float CalcPenalty(float currentMoney, float amtFake, float lawyerDeduction)
    {
        //if the player is commiting fraud
        if(amtFake != 0)
        {
            //base penalty is a third of the player's money plus the amount they lied about
            float penalty = (currentMoney / 3) + amtFake;

            //subtract the amount that the lawyer saves
            lawyerDeduction = penalty * (lawyerDeduction / 100);

            penalty -= lawyerDeduction;

            //returns the amount of money to deduct from the player
            return penalty;
        }

        //if the player is not commiting fraud, the IRS doesn't do anything
        return 0;

        

    }
}
