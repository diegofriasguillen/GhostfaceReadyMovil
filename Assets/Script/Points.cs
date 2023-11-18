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

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        UpdatePointsText();
    }

    private void UpdatePointsText()
    {
        // Muestra la cantidad actual de puntos y la meta del nivel
        textMesh.text = points.ToString("0") + (" / ") + levelInfoList[currentLevelIndex].pointsToWin.ToString("0");
    }

    private void Update()
    {
        UpdatePointsText();
    }

    public void AddPoints(float onCommingPoints)
    {
        points += onCommingPoints;

        if (points >= levelInfoList[currentLevelIndex].pointsToWin)
        {
            // Desactiva la condición de victoria en el nivel actual
            winCondition.gameObject.SetActive(false);

            // Reinicia los puntos al ganar el nivel
            points = 0;

            // Avanza al siguiente nivel
            currentLevelIndex++;

            // Activa la condición de victoria en el nuevo nivel
            if (currentLevelIndex < levelInfoList.Count)
            {
                winCondition.gameObject.SetActive(true);
            }
            else
            {
                Debug.LogWarning("Todos los niveles completados");
            }
        }
    }

    public void NextLevel()
    {
        currentLevelIndex++; // Avanza al siguiente nivel

        // Asegúrate de que estás dentro de los límites del array
        if (currentLevelIndex < levelInfoList.Count)
        {
            // Reinicia otros elementos relacionados con cambiar de nivel si es necesario

            // Activa la condición de victoria en el nuevo nivel
            winCondition.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Todos los niveles completados");
        }
    }

}