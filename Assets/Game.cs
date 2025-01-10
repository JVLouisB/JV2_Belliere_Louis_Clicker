using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public Text scoreText;
    public float currentScore;
    public float hitPower;
    public float scoreIncreasedPerSecond;
    public float x;

    public int shop1prize;
    public Text shop1text;

    public int shop2prize;
    public Text shop2text;

    public int shop3prize;
    public Text shop3text;

    public Text amount1Text;
    public int amount1;
    public float amount1Profit;

    public Text amount2Text;
    public int amount2;
    public float amount2Profit;

    public Text amount3Text;
    public int amount3;
    public float amount3Profit;

    public float upgradePrize;
    public Text upgradeText;

    public GameObject plusObject;
    public Text plusText;

    public bool nowIsEvent;
    public GameObject DragonEgg;

    public bool achivementScore;
    public bool achivementShop;
    public bool achivementScore2;
    public bool achivementShop2;
    public bool achivementScore3;
    public bool achivementShop3;

    public Image image1;
    public Image image2;
    public Image image3;
    public Image image4;
    public Image image5;
    public Image image6;

    public int level;
    public int xp;
    public int xplvl;
    public Text LevelText;


    void Start()
    {
        currentScore = 0;
        hitPower = 1;
        scoreIncreasedPerSecond = 1;
        x = 0f;
    }

    [System.Obsolete]
    void Update()
    {
        scoreText.text = (int)currentScore+" Dents";
        scoreIncreasedPerSecond = x * Time.deltaTime;
        currentScore = currentScore + scoreIncreasedPerSecond;


        shop1text.text = "Plantation :" + shop1prize + " ";
        shop2text.text = "Mineur :" + shop2prize + " ";
        shop3text.text = "Elevage :" + shop3prize + " ";

        amount1Text.text = "Tier 1: " + amount1 + "  " + amount1Profit + "/s";
        amount2Text.text = "Tier 2: " + amount2 + "  " + amount2Profit + "/s";
        amount3Text.text = "Tier 3: " + amount3 + "  " + amount3Profit + "/s";

        upgradeText.text = "Cost: "+upgradePrize+" ";

        plusText.text = "+ " + hitPower;

        if(nowIsEvent == false && DragonEgg.active ==true)
        {
            DragonEgg.SetActive(false);
            StartCoroutine(WaitForEvent());
        }

        if(nowIsEvent == true && DragonEgg.active == false)
        {
            DragonEgg.SetActive(true);
            DragonEgg.transform.position = new Vector3(Random.Range(0, 751), Random.Range(0, 401), 0);
        }

        if(currentScore >250)
        {
            achivementScore = true;
        }
        if(amount1 > 2)
        {
            achivementShop = true;
        }
        if (currentScore > 5000)
        {
            achivementScore2 = true;
        }
        if (amount2 > 0)
        {
            achivementShop2 = true;
        }
        if (currentScore > 25000)
        {
            achivementScore3 = true;
        }
        if (amount3 > 2)
        {
            achivementShop3 = true;
        }

        if (achivementScore == true)
        {
            image1.color = new Color(1f ,1f ,1f , 1f);
        }
        else
        {
            {
                image1.color = new Color(0.25f, 0.25f, 0.25f, 0.25f);
            }
        }

        if (achivementShop == true)
        {
            image2.color = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
            {
                image2.color = new Color(0.25f, 0.25f, 0.25f, 0.25f);
            }
        }
        if (achivementScore2 == true)
        {
            image3.color = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
            {
                image3.color = new Color(0.25f, 0.25f, 0.25f, 0.25f);
            }
        }

        if (achivementShop2 == true)
        {
            image4.color = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
            {
                image4.color = new Color(0.25f, 0.25f, 0.25f, 0.25f);
            }
        }
        if (achivementScore3 == true)
        {
            image5.color = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
            {
                image5.color = new Color(0.25f, 0.25f, 0.25f, 0.25f);
            }
        }

        if (achivementShop3 == true)
        {
            image6.color = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
            {
                image6.color = new Color(0.25f, 0.25f, 0.25f, 0.25f);
            }
        }

        if (xp >= xplvl )
        {
            level++;
            xp = 0;
            xplvl *= 2;
        }

        LevelText.text = "niveau " + level ;



    }

    public void Hit()
    {
        currentScore += hitPower;


        plusObject.SetActive(false);
        plusObject.transform.position = new Vector3(Random.Range(900,700 +1), Random.Range(500,350+ 1), 0);
        plusObject.SetActive(true) ;
        StopCoroutine(Fly());
        StartCoroutine(Fly());

        xp++;
    }

    public void Shop1()
    {
        if (currentScore > shop1prize)
        {
            currentScore -= shop1prize;
            amount1 += 1;
            amount1Profit += 1;
            x += 1;
            shop1prize += 15;
        }
    }

    public void Shop2()
    {
        if (currentScore > shop2prize)
        {
            currentScore -= shop2prize;
            amount2 += 1;
            amount2Profit += 25;
            x += 100;
            shop2prize *= 2;
        }
    }

    public void Shop3()
    {
        if (currentScore > shop3prize)
        {
            currentScore -= shop3prize;
            amount3 += 1;
            amount3Profit += 1000;
            x += 1000;
            shop3prize *= 3;
        }
    }

    public void Upgrade()
    {
        if (currentScore > upgradePrize)
        {
            currentScore -= upgradePrize;
            hitPower *= 2f;
            upgradePrize *= 2.5f;
                
        } 
    }

    IEnumerator Fly()
    {
        for(int i=0;i<=19;i++)
        {
            yield return new WaitForSeconds(0.01f);
            plusObject.transform.position = new Vector3(plusObject.transform.position.x, plusObject.transform.position.y + 2, 0);

        }
        plusObject.SetActive(false);
    }

    public void GetReward()
    {
        currentScore = currentScore + Random.Range(1, 5000);
        nowIsEvent = false;
        StartCoroutine(WaitForEvent());
    }

    IEnumerator WaitForEvent()
    {
        yield return new WaitForSeconds(5f);

        int x = 0;
        x = Random.Range(1, 3);

        if(x == 2)
        {
            nowIsEvent = true;
        }
        else
        {
            DragonEgg.SetActive(true);
        }
    }
}
