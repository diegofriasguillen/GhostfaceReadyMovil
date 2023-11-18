using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeRecolect : MonoBehaviour
{
    [SerializeField] private float pointsAmount;
    [SerializeField] private Points points;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            points.AddPoints(pointsAmount);
            Destroy(gameObject);

            if (points.levelInfoList.Count > 0)
            {
                points.currentLevelIndex = Mathf.Clamp(points.currentLevelIndex, 0, points.levelInfoList.Count - 1);

                if (points.currentLevelIndex < points.levelInfoList.Count)
                {
                    if (points.points >= points.levelInfoList[points.currentLevelIndex].pointsToWin)
                    {
                        points.NextLevel();
                    }
                }
                else
                {
                    Debug.LogError("Índice de nivel fuera de rango en KnifeRecolect");
                }
            }
            else
            {
                Debug.LogError("levelInfoList no contiene ningún elemento en KnifeRecolect");
            }
        }
    }
}