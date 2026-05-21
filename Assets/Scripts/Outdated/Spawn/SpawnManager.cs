using UnityEngine;
using Zenject;

public class SpawnManager : MonoBehaviour
{
    private Transform[] spawnPoints;

    private int index;

    private void Start()
    {
        spawnPoints = new Transform[transform.childCount];
        for (int i = 0; i < spawnPoints.Length; i++)
            spawnPoints[i] = transform.GetChild(i);
    }

    public void SpawnPoint()
    {
        index++;
    }
}
