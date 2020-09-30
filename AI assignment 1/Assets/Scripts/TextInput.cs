// Daniel Carr
// 100660903
// Takes in the file path for the text file so that the TextReader class can access it

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextInput : MonoBehaviour
{
    private string filePath;
    public InputField inputField;
    private bool isFinished = false;


    //private void Start()
    //{
    //    string log = inputField.enabled.ToString();
    //    Debug.Log(log);
    //}

    private void Update()
    {
        

        if (Input.GetButtonDown("Submit") && !isFinished)
        {
            filePath = inputField.text.ToString();
            //Debug.Log(filePath);

            isFinished = true;
            //Debug.Log("TextInput is done");
        }

    }

    public string GetFilePath()
    {
        return filePath;
    }

    public bool GetFinished()
    {
        return isFinished;
    }
}
