// Daniel Carr
// 100660903
// Determines how many doors there needs to be for each set of properties, based on the probability values provided by the TextReader class

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    private int[] numDoors = new int[8];
    public bool[] hotArray = new bool[20];
    private bool[] noisyArray = new bool[20];
    private bool[] safeArray = new bool[20];

    public TextReader textReader;

    //private bool[] finishedArray = new bool[20];
    private bool isFinished = false;

    // grabs the probabilities from the text reader class,
    // and calculates how many doors need to be set aside for each set of properties
    private void GetNumArray()
    {
        for (int i = 0; i < 8; i++)
        {
            numDoors[i] = Mathf.RoundToInt(textReader.GetProbNum(i));
            //Debug.Log(numDoors[i]);
        }
    }

    // sets the properties for each door
    private void SetDoorProperties()
    {
        int doorNum = 0;

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < numDoors[i]; j++)
            {
                if (i == 0 || i == 1 || i == 2 || i == 3)
                    hotArray[doorNum] = true;
                else
                    hotArray[doorNum] = false;

                if (i == 0 || i == 1 || i == 4 || i == 5)
                    noisyArray[doorNum] = true;
                else
                    noisyArray[doorNum] = false;

                if (i == 0 || i == 2 || i == 4 || i == 6)
                    safeArray[doorNum] = true;
                else
                    safeArray[doorNum] = false;

                doorNum++;
            }
        }
    }

    private void Update()
    {
        if (textReader.GetFinished() && !isFinished)
        {
            GetNumArray();

            SetDoorProperties();

            isFinished = true;
            //Debug.Log("DoorBehaviour is done");
        }        
    }

    // returns whether door i is hot
    public bool GetHot(int i)
    {
        return hotArray[i];
    }

    // returns whether door i is noisy
    public bool GetNoisy(int i)
    {
        return noisyArray[i];
    }

    // returns whether door i is safe
    public bool GetSafe(int i)
    {
        return safeArray[i];
    }

    public bool GetFinished()
    {
        return isFinished;
    }
}
