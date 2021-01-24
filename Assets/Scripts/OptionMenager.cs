using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionMenager : MonoBehaviour
{
    public GameObject panelForConfiramtionOfDeleteData;
    public List<GameObject> go;
    public void ShowConfirmationOfClearData()
    {
        panelForConfiramtionOfDeleteData.SetActive(true);
    }
    public void MakeClearData()
    {
        GameObject LevelData = GameObject.Find("LevelsData");
        LevelData.GetComponent<ManageOfSave>().ClearLevels();
        LevelData.GetComponent<ManageOfSave>().ClearAward();
        for (int i = 0; i < go.Count; i++)
        {
            go[i].GetComponent<TestRecognitionImage>().CalcPanelSize();
        }
        panelForConfiramtionOfDeleteData.SetActive(false);
    }
    public void CancelCelarData()
    {
        panelForConfiramtionOfDeleteData.SetActive(false);
    }
}
