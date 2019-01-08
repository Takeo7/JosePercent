﻿using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControllerScript : MonoBehaviour {

    public InputField moneyIF;
    public InputField monthIF;
    public InputField totalInvIF;
    public InputField totalMOnthIF;
    public InputField costeOp1IF;
    public InputField costeOp2IF;
    [Space]
    public GameObject PopUp;

    public Text percentText;

    [Space]
    float month;
    float money;
    float totalInversion = 50000;
    float totalMonth = 12;
    float costeOp1 = 0.03f;
    float costeOp2 = 0.06f;
    float pagoPrefCoste = 0.08f;

    float percent;

    bool pagoPreferente = false;

    public void PressButton()
    {
        Calculate();
    }

    void Calculate()
    {
        percent = (money * 100 / totalInversion)/(1+(month * calculateDesp(month)));
        percent = percent * 0.8f;
        percentText.text = percent.ToString("F2") + "%";
    }

    float calculateDesp(float i)
    {
        if (i < (totalMonth / 2))
        {
            if (i == 0)
            {
                if (pagoPreferente)
                {
                    month = 1;
                    return pagoPrefCoste;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                if (pagoPreferente)
                {
                    return costeOp1 + pagoPrefCoste;
                }
                else
                {
                    return costeOp1;
                }
            }
        }
        else
        {
            if (pagoPreferente)
            {
                return costeOp2 + pagoPrefCoste;
            }
            else
            {
                return costeOp2;
            }
        }
    }

    public void ChangePagoPref()
    {
        pagoPreferente = !pagoPreferente;
    }

    public void MoneyIFUpdate(Text t)
    {
        money = Convert.ToInt32(t.text);
    }
    public void MonthIFUpdate(Text t)
    {
        month = Convert.ToInt32(t.text);
    }
    public void TotalInvIFUpdate(Text t)
    {
        totalInversion = Convert.ToInt32(t.text);
    }
    public void TotalMonthIFUpdate(Text t)
    {
        totalMonth = Convert.ToInt32(t.text);
    }
    public void CosteOp1IFUpdate(Text t)
    {
        costeOp1 = (float)Convert.ToDouble(t.text);
    }
    public void CosteOp2IFUpdate(Text t)
    {
        costeOp2 = (float)Convert.ToDouble(t.text);
    }

    public void TooglePopUp()
    {
        PopUp.SetActive(!PopUp.activeSelf);
    }

    public void ScenePercent()
    {
        SceneManager.LoadScene("percent");
    }
    public void SceneMoney()
    {
        SceneManager.LoadScene("money");
    }

}
