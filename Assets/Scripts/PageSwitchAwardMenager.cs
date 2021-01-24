using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageSwitchAwardMenager : MonoBehaviour
{
    public List<Button> listOfPageButtons;
    public List<GameObject> listOpPages;
    public void Start()
    {
        int lastPage = PlayerPrefs.GetInt("PageAwardSelected", 1);
        SwitchToPage(lastPage);
    }   
    public void SwitchToPage(int pageNo)
    {
        for (int i = 0; i < listOfPageButtons.Count; i++)
        {
            if (pageNo == i + 1)
            {
                listOfPageButtons[i].image.color = Color.yellow;
            }
            else
            {
                listOfPageButtons[i].image.color = Color.white;
            }
        }
        for (int i = 0; i < listOpPages.Count; i++)
        {
            if (pageNo == i + 1)
            {
                listOpPages[i].SetActive(true);
            }
            else
            {
                listOpPages[i].SetActive(false);
            }
        }
        PlayerPrefs.SetInt("PageAwardSelected", pageNo);
    }
}
