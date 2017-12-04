using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class for all finances to be handled
public class Finances : MonoBehaviour {

    //fields
    //the money that the player starts with
    public float startingMoney;

    //the player's current income
    public float currIncome;

    //the amount the player loses to taxes every second
    public float taxPerSecond;

    //the amount the player loses to taxes every year
    public float taxPerYear;

    //the number of years passed
    public float yearNum;

    //current money that the player has
    public float currentMoney;

    //the amount of money that the player is believed to have
    public float fakeMoney;

    //amount of money that the player is earning in stocks
    public float stockIncome;

    //amount of yearly expenses
    public float yearlyExp;

    //stock management
    public GameObject stockMan;

    //lawyer management
    public GameObject lawMan;

    //fraud management
    public GameObject fraudMan;

    //IRS Investigation
    public GameObject irsMan;
    public bool irsInvestigation;

    //amount of revenue difference that you are lying about
    public float amtFake;

    // Use this for initialization
    void Start() {
        amtFake = 0;
        currentMoney = startingMoney;
        fakeMoney = currentMoney;

        irsInvestigation = false;

        CalcNewTaxes();

    }

    // Update is called once per frame
    void Update() {
        fakeMoney = currentMoney - amtFake;
    }

    public void IRSInvestigation()
    {
        //if there is an investigation
        if (irsMan.GetComponent<IRS>().Investigate(currentMoney, fakeMoney, yearNum, lawMan.GetComponent<Lawyers>().CalcInvesDeduct(), stockMan.GetComponent<Stocks>().NumStocks()))
        {
            //subtract the penalty amount from the player
            currentMoney -= irsMan.GetComponent<IRS>().CalcPenalty(currentMoney, amtFake, lawMan.GetComponent<Lawyers>().CalcPenDeduct());
            fakeMoney = currentMoney;
            amtFake = 0;
            irsInvestigation = true;
        }
        else
        {
            irsInvestigation = false;
        }

    }

    //calculates taxes based on how much money the government thinks that you are making
    public void CalcNewTaxes()
    {
        //the lowest taxes possible to be paid is 20k a year
        if (fakeMoney <= 500000)
        {
            taxPerYear = 20000;
        }
        else
        {
            taxPerYear = (fakeMoney / 8f);
        }

        taxPerSecond = taxPerYear / 100f; ;
    }

    public float CalcYearlyExpenses()
    {
        //start with a base yearly expense of 50k
        float expenses = 50000;

        //add the cost of hiring a lawyer
        expenses += lawMan.GetComponent<Lawyers>().lawyerType * 100000;

        //add to the yearly expenses
        expenses += taxPerYear;

        //find the player's new taxes to be paid for the year
        CalcNewTaxes();

        return expenses;
    }

    //everything needed to be done in a new year
    public void NewYear()
    {
        //increment the year number;
        yearNum++;

        //conduct an IRS investigation
        IRSInvestigation();

        //subtract the player's yearly expenses
        yearlyExp = CalcYearlyExpenses();

        //subtract the yearly expenses from the player's current money
        currentMoney -= yearlyExp;

        currentMoney += stockMan.GetComponent<Stocks>().CalcIncome();
    }

    //STOCK PURCHASING
    public void BuyBlueStock()
    {
        //if there is enough money to buy it
        if(currentMoney > stockMan.GetComponent<Stocks>().blueStockVal)
        {
            //subtract the cost and increment number of blue stocks
            currentMoney -= stockMan.GetComponent<Stocks>().blueStockVal;
            stockMan.GetComponent<Stocks>().blueStock++;
            
        }
    }

    public void BuyIncomeStock()
    {
        //if there is enough money to buy it
        if (currentMoney > stockMan.GetComponent<Stocks>().incomeStockVal)
        {
            //subtract the cost and increment number of income stocks
            currentMoney -= stockMan.GetComponent<Stocks>().incomeStockVal;
            stockMan.GetComponent<Stocks>().incomeStock++;

        }
    }

    public void BuyValueStock()
    {
        //if there is enough money to buy it
        if (currentMoney > stockMan.GetComponent<Stocks>().valueStockVal)
        {
            //subtract the cost and increment number of income stocks
            currentMoney -= stockMan.GetComponent<Stocks>().valueStockVal;
            stockMan.GetComponent<Stocks>().valueStock++;

        }
    }

    public void BuyGrowthStock()
    {
        //if there is enough money to buy it
        if (currentMoney > stockMan.GetComponent<Stocks>().growthStockVal)
        {
            //subtract the cost and increment number of income stocks
            currentMoney -= stockMan.GetComponent<Stocks>().growthStockVal;
            stockMan.GetComponent<Stocks>().growthStock++;

        }
    }

    //LAWYER HIRING
    public void HireJunior()
    {
        //if the player can afford it
        if(currentMoney > 250000)
        {
            lawMan.GetComponent<Lawyers>().lawyerType = 1;
        }
    }

    public void HireAssociate()
    {
        //if the player can afford it
        if (currentMoney > 400000)
        {
            lawMan.GetComponent<Lawyers>().lawyerType = 2;
        }
    }

    public void HireLawyer()
    {
        //if the player can afford it
        if (currentMoney > 600000)
        {
            lawMan.GetComponent<Lawyers>().lawyerType = 3;
        }
    }

    //COMMITING TAX FRAUD
    public void MoneyOverseas()
    {
        if(currentMoney > 30000)
        {
            amtFake += fraudMan.GetComponent<Fraud>().HideMoney(fakeMoney);
            currentMoney -= 30000;
        }
        
    }

    public void FalseDeductible()
    {
        if (currentMoney > 100000)
        {
            amtFake += fraudMan.GetComponent<Fraud>().FalseDeductions(fakeMoney);
            currentMoney -= 100000;
        }

    }

    public void UnderReportIncome()
    {
        if (currentMoney > 10000)
        {
            amtFake += fraudMan.GetComponent<Fraud>().UnderReport(fakeMoney);
            currentMoney -= 10000;
        }

    }

    public void Lobby()
    {
        if(currentMoney > 800000)
        {
            taxPerYear -= fraudMan.GetComponent<Fraud>().UnderReport(fakeMoney);
            currentMoney -= 800000;
        }
    }


}
