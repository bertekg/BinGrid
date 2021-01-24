using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine.UI;

public class ReadLevelData : MonoBehaviour
{
    public TMP_Text levelName;
    public Image placeToShow;
    public Button buttonPrefab;
    public TMP_Text textPrefabToRigt;
    public TMP_Text testPrefabToTop;
    private bool[,] buttonState;
    private bool[,] finalAnswere;
    private bool[] wordsIsOk;
    public GameObject lastInfoScreen;
    public TMP_Text textResultsLast;
    OneLevelData data;
    // Start is called before the first frame update
    private Vector2 resolution;
    void Start()
    {
        resolution = new Vector2(Screen.width, Screen.height);
        string path = Application.persistentDataPath + "/level.data";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            data = formatter.Deserialize(stream) as OneLevelData;
            stream.Close();
            finalAnswere = new bool[data.listOfWords.Count, data.numberOfBits];
            for (int i = data.listOfWords.Count - 1; i >= 0; i--)
            {
                for (int j = data.numberOfBits - 1; j >= 0; j--)
                {
                    int tempAfterShift = data.listOfWords[i] >> j;
                    if((tempAfterShift & 0x1) > 0)
                    {
                        finalAnswere[i,j] = true;
                    }
                    else
                    {
                        finalAnswere[i, j] = false;
                    }
                }
            }            
            buttonState = new bool[data.listOfWords.Count, data.numberOfBits];
            wordsIsOk = new bool[data.listOfWords.Count];
            MakeGui();
            MakeAfterFinishInfo();
        }
        else
        {            
            Debug.LogError("Save file not found in " + path);
        }
        levelName.text = PlayerPrefs.GetString("LavelSelectedName", "No name");
    }
    private void MakeAfterFinishInfo()
    {
        textResultsLast.text = string.Empty;
        string currLine;
        for (int i = data.listOfWords.Count - 1; i >= 0; i--)
        {
            currLine = string.Empty;
            for (int j = data.numberOfBits - 1; j >= 0; j--)
            {
                if(finalAnswere[i,j])
                {
                    currLine += "1";
                }
                else
                {
                    currLine += "0";
                }

            }
            currLine += "[BIN]=" + data.listOfWords[i].ToString() + "[DEC]";
            if (i > 0)
            {
                currLine += "\n";
            }
            textResultsLast.text += currLine;            
        }
    }
    public void Update()
    {
        if (resolution.x != Screen.width || resolution.y != Screen.height)
        {
            foreach (Transform child in placeToShow.transform)
            {
                GameObject.Destroy(child.gameObject);
            }
            MakeGui();
            resolution.x = Screen.width;
            resolution.y = Screen.height;
        }
    }
    public void MakeGui()
    {
        float width = placeToShow.GetComponent<RectTransform>().rect.width;
        float height = placeToShow.GetComponent<RectTransform>().rect.height;
        float theoreticalSingleWidth = 20.0f;
        float theoreticalSingleHeight = 20.0f;
        float theoreticalTextWidth = 25.0f;
        float theoreticalHelpButtomHeight = 10.0f;
        float theoreticalAllWidth = theoreticalSingleWidth * (data.numberOfBits) + theoreticalTextWidth;
        float theoreticalAllHeight = theoreticalSingleHeight * (data.listOfWords.Count) + theoreticalHelpButtomHeight;
        float widthCoof = width / theoreticalAllWidth;
        float heightCoof = height / theoreticalAllHeight;
        float finalCoof = 0.0f;
        if(widthCoof <= heightCoof)
        {
            finalCoof = widthCoof;
        }
        else
        {
            finalCoof = heightCoof;
        }
        float offsetWidthLeft = (width - (theoreticalAllWidth * finalCoof)) / 2;
        float offsetHeightTop = (height - (theoreticalAllHeight * finalCoof)) / 2;
        float fBasicTileScaleWidth = theoreticalSingleHeight * finalCoof;
        float fBasicTileScaleHeight = theoreticalSingleHeight * finalCoof;
        for (int j = 0; j < data.listOfWords.Count; j++)
        {
            for (int i = 0; i < data.numberOfBits; i++)
            {
                Button tmpBut = Instantiate(buttonPrefab) as Button;
                tmpBut.name = "Button_" + j.ToString() + "_" + i.ToString();
                tmpBut.onClick.AddListener(delegate { test(tmpBut.name); });
                tmpBut.transform.position = new Vector3(offsetWidthLeft +((fBasicTileScaleWidth * (data.numberOfBits - 1) ) - (i * fBasicTileScaleWidth)), offsetHeightTop + (j * fBasicTileScaleHeight));
                tmpBut.GetComponent<RectTransform>().sizeDelta = new Vector2(fBasicTileScaleWidth, fBasicTileScaleHeight);
                if (buttonState[j, i])
                {
                    tmpBut.image.color = Color.green;
                }
                tmpBut.transform.SetParent(placeToShow.transform, false);
            }
            TMP_Text tmpText = Instantiate(textPrefabToRigt) as TMP_Text;
            tmpText.name = "ValueForRow_" + j.ToString();
            tmpText.text = data.listOfWords[j].ToString();
            tmpText.transform.position = new Vector3(offsetWidthLeft + (fBasicTileScaleWidth * data.numberOfBits), offsetHeightTop + (j * fBasicTileScaleHeight));
            tmpText.GetComponent<RectTransform>().sizeDelta = new Vector2(theoreticalTextWidth * finalCoof, fBasicTileScaleHeight);
            tmpText.transform.SetParent(placeToShow.transform, false);
        }
        for (int i = 0; i < data.numberOfBits; i++)
        {
            TMP_Text tmpText = Instantiate(testPrefabToTop) as TMP_Text;
            tmpText.name = "ValueForColumn_" + i.ToString();
            tmpText.text = Mathf.Pow(2, i).ToString();
            tmpText.transform.position = new Vector3(offsetWidthLeft + ((fBasicTileScaleWidth * (data.numberOfBits - 1)) - (i * fBasicTileScaleWidth)), offsetHeightTop + (data.listOfWords.Count * fBasicTileScaleHeight));
            tmpText.GetComponent<RectTransform>().sizeDelta = new Vector2(fBasicTileScaleWidth, theoreticalHelpButtomHeight * finalCoof);
            tmpText.transform.SetParent(placeToShow.transform, false);
        }
    }
    public void test(string buttonName)
    {        
        int adressOfFirstChar = buttonName.IndexOf("_", 0);
        int adressOfSecoundChar = buttonName.IndexOf("_", adressOfFirstChar + 1);
        string stringWordAdress = buttonName.Substring(adressOfFirstChar + 1, adressOfSecoundChar - adressOfFirstChar - 1);
        string stringBitAdress = buttonName.Substring(adressOfSecoundChar + 1, buttonName.Length - adressOfSecoundChar - 1);
        Debug.Log("Full name: " + buttonName + ", Detected wordAdres: " + stringWordAdress + ", Detected bitAdress: " + stringBitAdress);
        byte byteWordAdress = byte.Parse(stringWordAdress);
        byte byteBitAdress = byte.Parse(stringBitAdress);
        buttonState[byteWordAdress, byteBitAdress] = !buttonState[byteWordAdress, byteBitAdress];
        Button btn = GameObject.Find(buttonName).GetComponent<Button>();
        if(buttonState[byteWordAdress, byteBitAdress])
        {
            btn.image.color = Color.green;
        }
        else
        {
            btn.image.color = Color.white;
        }
        CheckBitResults(byteWordAdress);
    }
    private void CheckBitResults(byte wordAdress)
    {
        bool isSame = true;
        for (int i = 0; i < data.numberOfBits; i++)
        {
            if(buttonState[wordAdress,i] != finalAnswere[wordAdress, i])
            {
                isSame = false;
            }
        }
        wordsIsOk[wordAdress] = isSame;
        TMP_Text tmpTextNumber = GameObject.Find("ValueForRow_" + wordAdress.ToString()).GetComponent<TMP_Text>();
        if (isSame)
        {
            tmpTextNumber.color = Color.green;
        }
        else
        {
            tmpTextNumber.color = Color.white;
        }
        bool allIsOk = true;
        for (int i = 0; i < data.listOfWords.Count; i++)
        {
            if(wordsIsOk[i] == false)
            {
                allIsOk = false;
            }
        }
        if(allIsOk)
        {
            lastInfoScreen.SetActive(true);
        }
    }
}
