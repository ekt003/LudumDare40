using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Main SceneManager class

public class SceneManager : MonoBehaviour {

    //fields
    //gameobject to handle finances
    public GameObject finances;

    //building game objects
    public GameObject stockMarket;
    public GameObject lawFirm;
    public GameObject accountingFirm;
    public GameObject house;

    //menus and whether or not they are displaying
    public Canvas stockMenu;
    public Canvas lawMenu;
    public Canvas accMenu;

    public bool isStockMenu;
    public bool isLawMenu;
    public bool isAccMenu;

    //keeps track of year status
    public float numSeconds;
    public bool updateTime;

    //VARIABLES TO BE DISPLAYED AT THE TOP OF THE SCREEN
    //player money stats to be displayed
    public Text currentMoney;
    public Text fakeMoney;

    //yearly info to be displayed
    public Text yearNum;
    public Text yearTime;
    public Text yearlyTaxes;
    public Text yearlyExpenses;

    //stock numbers to be displayed
    public Text blueStock;
    public Text incStock;
    public Text valStock;
    public Text growthStock;

    //IRS Info to be displayed
    public Text irsInvesChance;
    public Text lawyerType;
    public Text investigationStatus;


    // Use this for initialization
    void Start () {
        //starts second clock
        numSeconds = 0;

        //doesn't start the clock until the player clicks off of the title screen
        updateTime = false;

        //sets all menus to not display
        stockMenu.enabled = false;
        lawMenu.enabled = false;
        accMenu.enabled = false;

        isStockMenu = false;
        isLawMenu = false;
        isAccMenu = false;

        SetDisplayValues();
        SetTimes();
	}

    // Update is called once per frame
    void Update() {

        //increments second clock
        numSeconds += 1 * Time.deltaTime;

        if (numSeconds >= 1)
        {
            SetTimes();
            SetDisplayValues();
        }

        if (numSeconds >= 10)
        {
            numSeconds = 0;
            NewYear();
        }

        

        isStockMenu = stockMarket.GetComponent<ClickableAsset>().isClicked;
        isLawMenu = lawFirm.GetComponent<ClickableAsset>().isClicked;
        isAccMenu = accountingFirm.GetComponent<ClickableAsset>().isClicked;

        //checks to see if any of the menus have been clicked on, if they have set the value to true
        if (isStockMenu && !isLawMenu && !isAccMenu)
        {
            //sets menu to display
            stockMenu.enabled = true;

        }

        if (isLawMenu && !isStockMenu && !isAccMenu)
        {
            //sets menu to display
            lawMenu.enabled = true;
        }

        if(isAccMenu && !isStockMenu && !isLawMenu)
        {
            //sets menu to display
            accMenu.enabled = true;

        }

	}

    //actions that need to be taken on a new year
    void NewYear()
    {
        //new year updates to finances
        finances.GetComponent<Finances>().NewYear();

        if(finances.GetComponent<Finances>().currentMoney <= 0)
        {
            CloseMenus();
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
        }

    }

    void CloseMenus()
    {
        isStockMenu = false;
        isLawMenu = false;
        isAccMenu = false;
    }

    //sets all values to be up to date
    void SetDisplayValues()
    {
        currentMoney.text = "Money: $" + finances.GetComponent<Finances>().currentMoney.ToString("n0");
        fakeMoney.text = "Fake Money: $" + finances.GetComponent<Finances>().fakeMoney.ToString("n0");
        yearNum.text = "Year: " + finances.GetComponent<Finances>().yearNum.ToString("n0");
        yearlyTaxes.text = "Taxes: $" + finances.GetComponent<Finances>().taxPerYear.ToString("n0");
        yearlyExpenses.text = "Expenses: $" + finances.GetComponent<Finances>().yearlyExp.ToString("n0");
        blueStock.text = "Blue Stock: " + finances.GetComponent<Finances>().stockMan.GetComponent<Stocks>().blueStock;
        incStock.text = "Income Stock: " + finances.GetComponent<Finances>().stockMan.GetComponent<Stocks>().incomeStock;
        valStock.text = "Value Stock: " + finances.GetComponent<Finances>().stockMan.GetComponent<Stocks>().valueStock;
        growthStock.text = "Growth Stock: " + finances.GetComponent<Finances>().stockMan.GetComponent<Stocks>().growthStock;
        irsInvesChance.text = "IRS Suspicion: " + finances.GetComponent<Finances>().irsMan.GetComponent<IRS>().investChance;
        lawyerType.text = "Lawyer: " + finances.GetComponent<Finances>().lawMan.GetComponent<Lawyers>().GetLawyerStr();

        if (finances.GetComponent<Finances>().irsInvestigation)
        {
            investigationStatus.text = "IRS Investigation Underway: Funds Confiscated";
        }
        else
        {
            investigationStatus.text = "No Investigation at this Time";
        }
    }

    void SetTimes()
    {
        int nextYear = 10 - (int)numSeconds;
        yearTime.text = "Time to New Year: " + nextYear;
    }



}
