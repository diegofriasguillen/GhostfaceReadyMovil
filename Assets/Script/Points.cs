using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public struct LevelInfo
{
    public int levelNumber;
    public int pointsToWin;
}

public class Points : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    [SerializeField] private GameObject winCondition;
    public List<LevelInfo> levelInfoList;
    public int currentLevelIndex = 0;
    public float points;

    private Dictionary<int, int> collectedPointsByLevel = new Dictionary<int, int>();

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        UpdatePointsText();
    }

    private void UpdatePointsText()
    {
        int collectedPoints = collectedPointsByLevel.ContainsKey(currentLevelIndex) ? collectedPointsByLevel[currentLevelIndex] : 0;

        textMesh.text = collectedPoints.ToString("0") + (" / ") + levelInfoList[currentLevelIndex].pointsToWin.ToString("0");
    }

    private void Update()
    {
        UpdatePointsText();
    }

    public void AddPoints(float onComingPoints)
    {
        int currentCollectedPoints = collectedPointsByLevel.ContainsKey(currentLevelIndex) ? collectedPointsByLevel[currentLevelIndex] : 0;
        currentCollectedPoints++;

        collectedPointsByLevel[currentLevelIndex] = currentCollectedPoints;
        points += onComingPoints;

        if (currentCollectedPoints >= levelInfoList[currentLevelIndex].pointsToWin)
        {
            winCondition.gameObject.SetActive(false);
            points = 0;

            currentLevelIndex++;

            if (currentLevelIndex < levelInfoList.Count)
            {
                winCondition.gameObject.SetActive(true);
            }
        }
    }

    public void NextLevel()
    {
        currentLevelIndex++;

        if (currentLevelIndex < levelInfoList.Count)
        {
            winCondition.gameObject.SetActive(true);
        }
    }
}