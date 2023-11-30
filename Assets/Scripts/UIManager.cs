using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Image startImage;
    [SerializeField] private TMP_Text startText;

    public void StartGame()
    {
        startButton.enabled = false;
        startImage.enabled = false;
        startText.enabled = false;
    }
    
}
