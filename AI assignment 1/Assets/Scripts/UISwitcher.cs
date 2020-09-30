// Daniel Carr
// 100660903
// Used to switch the UI from the file path input and instructions to the controls

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class UISwitcher : MonoBehaviour
{
    public GameObject inputField;
    public GameObject inputInstructions;
    public GameObject gameInstructions;

    private bool playerMovementDisabled = true;

    // deactivates the first two UIs and activates the third one
    public void SwitchUI()
    {
        inputField.SetActive(false);
        inputInstructions.SetActive(false);
        gameInstructions.SetActive(true);

        Debug.Log("UI switching completed");

        playerMovementDisabled = false;
    }

    public bool GetMoveDisabled()
    {
        return playerMovementDisabled;
    }
}
