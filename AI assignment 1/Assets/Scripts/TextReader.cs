// Daniel Carr
// 100660903
// Reads in the probabilities text file and stores the probability values in an array

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text.RegularExpressions;

public class TextReader : MonoBehaviour
{
    private string[] probabilities = new string[8];
    private string path;
    private float[] probNumbers = new float[8];
    public TextInput textInput;
    public UISwitcher uiSwitcher;
    private bool isFinished = false;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (textInput.GetFinished() && !isFinished)
        {
            uiSwitcher.SwitchUI();

            path = textInput.GetFilePath();

            ReadFile();

            Compute();

            isFinished = true;
            //textInput.SetFinished(false); // because I had to move everything into the update loop (because I don't know how else to make it work),
            Debug.Log("TextReader is done"); // I need to set the previous class' finished bool to false so that the current class doesn't try to repeat
        }                                     // it's one-time tasks every frame
    }

    // reads the probabilities text file
    private void ReadFile()
    {
        int i = -1;
        StreamReader reader = new StreamReader(path);
        while (!reader.EndOfStream)
        {
            string thing = reader.ReadLine();
            var otherThing = Regex.Match(thing, @"([-+]?[0-9]*\.?[0-9]+)").Value;


            if (i >= 0)
            {
                probabilities[i] = otherThing;

                //Debug.Log(probabilities[i]);
            }
            i++;
        }

        reader.Close();
    }

    // converts the probability strings into floats
    private void Compute()
    {
        for (int j = 0; j < 8; j++)
        {
            //Debug.Log(float.Parse(probabilities[j]));
            probNumbers[j] = float.Parse(probabilities[j]) * 20;

            //Debug.Log(probNumbers[j]);
        }
    }

    // returns the probability float stored in slot i of the array
    // used by the DoorBehaviour class to import the probabilities
    public float GetProbNum(int i)
    {
        //Debug.Log(probNumbers[i]);
        return probNumbers[i];
    }

    public bool GetFinished()
    {
        return isFinished;
    }
}