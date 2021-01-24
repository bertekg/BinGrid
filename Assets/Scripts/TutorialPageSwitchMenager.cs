using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TutorialPageSwitchMenager : MonoBehaviour
{
    public List<Button> buttonsForPage;
    public List<GameObject> gameObjectPages;
    public int indexOfPage = 0;
    private void Start()
    {
        UpdateButtonsColor();
    }
    public void ChangeToPage(int index)
    {
        indexOfPage = index;
        UpdateButtonsColor();
        SwitchToPage();
    }
    private void UpdateButtonsColor()
    {
        for (int i = 0; i < buttonsForPage.Count; i++)
        {
            if(i != indexOfPage)
            {
                buttonsForPage[i].image.color = Color.white;
            }
            else
            {
                buttonsForPage[i].image.color = Color.green;
            }
        }
    }
    private void SwitchToPage()
    {
        for (int i = 0; i < gameObjectPages.Count; i++)
        {
            if (i != indexOfPage)
            {
                gameObjectPages[i].SetActive(false);
            }
            else
            {
                gameObjectPages[i].SetActive(true);
            }
        }
    }
}
