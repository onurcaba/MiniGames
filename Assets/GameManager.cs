using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public AudioListener audioListener;
    
    public List<AreaTypeSO> areaTypeList = new List<AreaTypeSO>();

    public GameObject youWin;
    public List<AreaUnit> areaUnitList = new List<AreaUnit>();
    public AreaUnit areaUnit;

    public int height;
    public int width;

    private void Start()
    {
        CreateArea();
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void CreateArea()
    {
        int index = Random.Range(0, areaTypeList.Count);
        height = areaTypeList[index].height;
        width = areaTypeList[index].width;

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                var position = new Vector3(i, 0, j);
                var newAreaUnit = Instantiate(areaUnit, position, Quaternion.identity);
                areaUnitList.Add(newAreaUnit);
            }
        }
    }

    public void YouWin()
    {
        youWin.SetActive(true);
    }

    public void AudioControl()
    {
        audioListener.enabled= !audioListener.enabled;
    }
    
    public void GoToHome()
    {
        // Crete a go to Home Screen Method
    }    
    
    public void ExitGame()
    {
       Application.Quit();
    }
}