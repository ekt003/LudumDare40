using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class to keep track of user stock usage
public class Stocks : MonoBehaviour {

    //number of stocks a player has
    public int numStocks;

    //number of blue chip stocks the player has
    public int blueStock;
    public float blueStockVal;
    public float blueStockChance;

    //number of income stocks the player has
    public int incomeStock;
    public float incomeStockVal;
    public float incomeStockChance;

    //number of value stocks the player has
    public int valueStock;
    public float valueStockVal;
    public float valueStockChance;

    //number of growth stocks the player has
    public int growthStock;
    public float growthStockVal;
    public float growthStockChance;

    //amount that the player makes from their stock money this year
    public float yrIncome;

	// Use this for initialization
	void Start () {
        //starting stock numbers
        blueStock = 0;
        incomeStock = 0;
        valueStock = 0;
        growthStock = 0;
        numStocks = 0;

        //stock costs
        blueStockVal = 30000;
        incomeStockVal = 150000;
        valueStockVal = 10000;
        growthStockVal = 200000;

        //stock chance of return
        blueStockChance = 8;
        incomeStockChance = 6;
        valueStockChance = 5;
        growthStockChance = 1;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public float NumStocks()
    {
        numStocks = blueStock + incomeStock + valueStock + growthStock;
        return numStocks;
    }

    //returns the amount of money that the player makes this year from stocks
    public float CalcIncome()
    {
        //variable to hold amount of income the player makes this year
        float income = 0;

        //adds blue stocks to income
        income += CalcStockValue(blueStock, 500, blueStockChance);

        //adds income stock to income
        income += CalcStockValue(incomeStock, 2000, incomeStockChance);

        //adds value stock to income
        income += CalcStockValue(valueStock, 200, valueStockChance);

        //adds growth stock to income
        income += CalcStockValue(growthStock, 10000, growthStockChance);

        yrIncome = income;

        return income;
    }

    //calculates the amount of money a given stock makes given the amount, annual earnings, and chance of success
    public float CalcStockValue(int stockNum, float stockEarn, float stockChance)
    {
        //variable for how many stocks made money
        int stocksPassed = 0;

        //cycles through all of the stocks
        for (int i = 0; i < stockNum; i++)
        {
            //creates a random number from 1-10
            int chanceCalc = Random.Range(0, 10);

            //if the chance of success is greater than the random number, the stock makes money this cycle
            if(stockChance > chanceCalc)
            {
                stocksPassed++; //added to number of stocks passed
            }
        }

        //returns amount of money each stock can make multiplied by the number of stocks that passed
        return stocksPassed * stockEarn;


    }

}
