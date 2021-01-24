using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TestRecognitionImage : MonoBehaviour
{
    public int numberOfColumns = 5, numberOfRows = 4;
    public Image imgPicture;
    public Image panelForCover;
    public Button buttonToCover;
    public TMP_Text textToDisplay;
    private string desciptionOfPictureAfterUncover;
    public string desciptionOfPictureAfterUncoverEn;
    public string desciptionOfPictureAfterUncoverPl;
    private Vector2 resolution;
    private float realPictureWidth, realPictureHeight;
    private float framePictureWidth, framePictureHeight;
    public int indexOfSave;
    public Button fullScreen;
    public TMP_Text fullscreenDescritpion;
    public Image fullscreenImage;
    public GameObject panelForFullScreen;
    public Sprite imageToShow;
    void Start()
    {
        resolution = new Vector2(Screen.width, Screen.height);
        CalcPanelSize();
    }
    void OnEnable()
    {
        UpadateLanguage();
    }
    // Update is called once per frame
    void Update()
    {
        if (resolution.x != Screen.width || resolution.y != Screen.height)
        {
            resolution = new Vector2(Screen.width, Screen.height);
            framePictureWidth = imgPicture.rectTransform.rect.width;
            framePictureHeight = imgPicture.rectTransform.rect.height;
            CalcPanelSize();
        }
    }
    public void CalcPanelSize()
    {
        foreach (Transform child in imgPicture.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        realPictureWidth = imgPicture.sprite.rect.width;
        realPictureHeight = imgPicture.sprite.rect.height;
        framePictureWidth = imgPicture.rectTransform.rect.width;
        framePictureHeight = imgPicture.rectTransform.rect.height;
        float widthCoof = framePictureWidth / realPictureWidth;
        float heightCoof = framePictureHeight / realPictureHeight;
        float finalCoof = 0.0f;
        if (widthCoof <= heightCoof)
        {
            finalCoof = widthCoof;
        }
        else
        {
            finalCoof = heightCoof;
        }
        float offsetWidthLeft = (framePictureWidth - (realPictureWidth * finalCoof)) / 2;
        float offsetHeightTop = (framePictureHeight - (realPictureHeight * finalCoof)) / 2;
        float panelToCoverWidth = realPictureWidth * finalCoof;
        float panelToCoverHeight = realPictureHeight * finalCoof;
        Image instantionOfPanleForCover = Instantiate(panelForCover) as Image;
        instantionOfPanleForCover.GetComponent<RectTransform>().sizeDelta = new Vector2(panelToCoverWidth, panelToCoverHeight);
        instantionOfPanleForCover.transform.position = new Vector3(offsetWidthLeft, offsetHeightTop);
        instantionOfPanleForCover.transform.SetParent(imgPicture.transform, false);        
        float fBasicTileScaleWidth = panelToCoverWidth / numberOfColumns;
        float fBasicTileScaleHeight = panelToCoverHeight / numberOfRows;
        AwardData tempAD = GameObject.Find("LevelsData").GetComponent<ManageOfSave>().GetAllAwardData();
        for (int i = 0; i < numberOfRows; i++)
        {
            for (int j = 0; j < numberOfColumns; j++)
            {
                if (!tempAD.awardCellsInfo[indexOfSave, j, i])
                {
                    Button tmpBut = Instantiate(buttonToCover) as Button;
                    tmpBut.name = imgPicture.name + "_" + j.ToString() + "_" + i.ToString();
                    tmpBut.onClick.AddListener(delegate { ClickButton(tmpBut.name); });
                    tmpBut.transform.position = new Vector3(fBasicTileScaleWidth * j, fBasicTileScaleHeight * i);
                    tmpBut.GetComponent<RectTransform>().sizeDelta = new Vector2(fBasicTileScaleWidth, fBasicTileScaleHeight);
                    tmpBut.transform.SetParent(instantionOfPanleForCover.transform, false);
                }                    
            }
        }
        CheckForDescription();
    }
    public void ClickButton(string buttonName)
    {
        
        int adressOfFirstChar = buttonName.IndexOf("_", 0);
        int adressOfSecoundChar = buttonName.IndexOf("_", adressOfFirstChar + 1);
        string stringIndexColumn = buttonName.Substring(adressOfFirstChar + 1, adressOfSecoundChar - adressOfFirstChar - 1);
        string stringIndexRow = buttonName.Substring(adressOfSecoundChar + 1, buttonName.Length - adressOfSecoundChar - 1);
        byte byteIdexColumn = byte.Parse(stringIndexColumn);
        byte byteIndexRow = byte.Parse(stringIndexRow);
        if (GameObject.Find("LevelsData").GetComponent<ManageOfSave>().RequestForCells(indexOfSave, byteIdexColumn, byteIndexRow))
        {          
            CheckForDescription();
            GameObject btn = GameObject.Find(buttonName);
            btn.SetActive(false);
        }
    }
    public void CheckForDescription()
    {
        if(GameObject.Find("LevelsData").GetComponent<ManageOfSave>().CheckAllPictureUncovered(indexOfSave))
        {
            textToDisplay.text = desciptionOfPictureAfterUncover;
            fullScreen.interactable = true;
        }
        else
        {
            textToDisplay.text = "???";
            fullScreen.interactable = false;
        }
    }
    public void UpadateLanguage()
    {
        string langFromOtherObejct = GameObject.Find("LangMenMainMenu").GetComponent<LanguageMenagerMainMenu>().GetCurrLanguage();
        UpadateLanguageKnowed(langFromOtherObejct);
    }
    public void UpadateLanguageKnowed(string lang)
    {
        if (lang == SystemLanguage.Polish.ToString())
        {
            desciptionOfPictureAfterUncover = desciptionOfPictureAfterUncoverPl;
        }
        else
        {
            desciptionOfPictureAfterUncover = desciptionOfPictureAfterUncoverEn;
        }
        CheckForDescription();
    }
    public void MakeFullScreen()
    {
        if (GameObject.Find("LevelsData").GetComponent<ManageOfSave>().CheckAllPictureUncovered(indexOfSave))
        {
            fullscreenDescritpion.text = desciptionOfPictureAfterUncover;
            fullscreenImage.sprite = imageToShow;
            panelForFullScreen.SetActive(true);
        }
        else
        {
            Debug.LogError("No possible for " + indexOfSave.ToString());
        }
    }
}
