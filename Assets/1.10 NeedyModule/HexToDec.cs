using UnityEngine;
using System.Collections;

public class HexToDec : MonoBehaviour
{
    public KMSelectable AddOne;
    public KMSelectable AddTen;
    public KMSelectable AddHundred;
    public KMSelectable ClearDisplay;
    public TextMesh mainDisplay;
    public TextMesh inputDisplay;

    int leftDigit;
    int rightDigit;
    int finalDec;
    int inputInt;

    string digitLeft;
    string digitRight;
    string finalStrg;
    string inputStrg;
    string newInput;

    void Awake()
    {
        GetComponent<KMNeedyModule>().OnNeedyActivation += OnNeedyActivation;
        GetComponent<KMNeedyModule>().OnNeedyDeactivation += OnNeedyDeactivation;
        AddOne.OnInteract += AddNum;
        AddTen.OnInteract += AddTenNum;
        AddHundred.OnInteract += AddHundredNum;
        ClearDisplay.OnInteract += ClearInput;
        GetComponent<KMNeedyModule>().OnTimerExpired += OnTimerExpired;
    }
    protected bool ClearInput()
    {
        inputInt = 0;
        inputDisplay.text = inputInt.ToString();
        return false;
    }
    protected bool AddHundredNum()
    {
        inputInt = inputInt + 100;
        inputDisplay.text = inputInt.ToString();
        return false;
    }

    protected bool AddTenNum()
    {
        inputInt = inputInt + 10;
        inputDisplay.text = inputInt.ToString();
        return false;
    }

    protected void OnNeedyActivation()
    {
        leftDigit = Random.Range(0, 16);
        rightDigit = Random.Range(0, 16);

        if(leftDigit == 10)
        {
            digitLeft = "A";
        }
        else
        {
            if(leftDigit == 11)
            {
                digitLeft = "B";
            }
            else
            {
                if (leftDigit == 12)
                {
                    digitLeft = "C";
                }
                else
                {
                    if (leftDigit == 13)
                    {
                        digitLeft = "D";
                    }
                    else
                    {
                        if (leftDigit == 14)
                        {
                            digitLeft = "E";
                        }
                        else
                        {
                            if (leftDigit == 15)
                            {
                                digitLeft = "F";
                            }
                            else
                            {
                                digitLeft = leftDigit.ToString();
                            }
                        }
                    }
                }
            }
        }
        if (rightDigit == 10)
        {
            digitRight = "A";
        }
        else
        {
            if (rightDigit == 11)
            {
                digitRight = "B";
            }
            else
            {
                if (rightDigit == 12)
                {
                    digitRight = "C";
                }
                else
                {
                    if (rightDigit == 13)
                    {
                        digitRight = "D";
                    }
                    else
                    {
                        if (rightDigit == 14)
                        {
                            digitRight = "E";
                        }
                        else
                        {
                            if (rightDigit == 15)
                            {
                                digitRight = "F";
                            }
                            else
                            {
                                digitRight = rightDigit.ToString();
                            }
                        }
                    }
                }
            }
        }
        string debugRight = rightDigit.ToString();
        string debugLeft = leftDigit.ToString();

        mainDisplay.text = digitLeft + " " + digitRight;
        Debug.Log("Generating Hex: " + debugLeft + " " + debugRight + " Or " + digitLeft + " " + digitRight);
        calculateDec();
    }

    protected void calculateDec()
    {
        if (digitLeft == "1")
        {
            finalDec = finalDec + 16;
        }
        if (digitLeft == "2")
        {
            finalDec = finalDec + 32;
        }
        if (digitLeft == "3")
        {
            finalDec = finalDec + 48;
        }
        if (digitLeft == "4")
        {
            finalDec = finalDec + 64;
        }
        if (digitLeft == "5")
        {
            finalDec = finalDec + 80;
        }
        if (digitLeft == "6")
        {
            finalDec = finalDec + 96;
        }
        if (digitLeft == "7")
        {
            finalDec = finalDec + 112;
        }
        if (digitLeft == "8")
        {
            finalDec = finalDec + 128;
        }
        if (digitLeft == "9")
        {
            finalDec = finalDec + 144;
        }
        if (digitLeft == "A")
        {
            finalDec = finalDec + 160;
        }
        if (digitLeft == "B")
        {
            finalDec = finalDec + 176;
        }
        if (digitLeft == "C")
        {
            finalDec = finalDec + 192;
        }
        if (digitLeft == "D")
        {
            finalDec = finalDec + 208;
        }
        if (digitLeft == "E")
        {
            finalDec = finalDec + 224;
        }
        if (digitLeft == "F")
        {
            finalDec = finalDec + 240;
        }
        if (digitRight == "1")
        {
            finalDec = finalDec + 1;
        }
        if (digitRight == "2")
        {
            finalDec = finalDec + 2;
        }
        if (digitRight == "3")
        {
            finalDec = finalDec + 3;
        }
        if (digitRight == "4")
        {
            finalDec = finalDec + 4;
        }
        if (digitRight == "5")
        {
            finalDec = finalDec + 6;
        }
        if (digitRight == "6")
        {
            finalDec = finalDec + 6;
        }
        if (digitRight == "7")
        {
            finalDec = finalDec + 7;
        }
        if (digitRight == "8")
        {
            finalDec = finalDec + 8;
        }
        if (digitRight == "9")
        {
            finalDec = finalDec + 9;
        }
        if (digitRight == "A")
        {
            finalDec = finalDec + 10;
        }
        if (digitRight == "B")
        {
            finalDec = finalDec + 11;
        }
        if (digitRight == "C")
        {
            finalDec = finalDec + 12;
        }
        if (digitRight == "D")
        {
            finalDec = finalDec + 13;
        }
        if (digitRight == "E")
        {
            finalDec = finalDec + 14;
        }
        if (digitRight == "F")
        {
            finalDec = finalDec + 15;
        }

        finalStrg = finalDec.ToString();
    }

    protected void OnNeedyDeactivation()
    {
        mainDisplay.text = "- -";
        inputDisplay.text = "0";
        inputInt = 0;
        finalDec = 0;
    }

    protected void OnTimerExpired()
    {
        inputStrg = inputInt.ToString();

        if(inputStrg == finalStrg)
        {
            GetComponent<KMNeedyModule>().OnPass();
        }
        else
        {
            GetComponent<KMNeedyModule>().OnStrike();
        }

        mainDisplay.text = "- -";

        Debug.Log("Corret answer was: " + finalStrg);

        inputInt = 0;
        finalDec = 0;
        inputDisplay.text = inputInt.ToString();
    }

    protected bool AddNum()
    {
        inputInt = inputInt + 1;
        inputDisplay.text = inputInt.ToString();
        return false;
    }
}