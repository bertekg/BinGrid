using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosingFullscreen : MonoBehaviour
{
    public GameObject thisPanel;
    public void CloseFullscreenPanel()
    {
        thisPanel.SetActive(false);
    }
}
