using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
    [Tooltip("จุดที่จะใช้สุ่ม spawn ของตก")]
    public Transform[] spawnPoints;

    [Tooltip("ตัว Factory สำหรับสร้างของตก")]
    public FallingObjectFactory factory;

    [Tooltip("ช่วงเวลาระหว่างการ spawn แต่ละชิ้น")]
    public float spawnInterval = 1.0f;

    private void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    private IEnumerator SpawnLoop()
    {
        while (true)
        {
            SpawnAtRandomPoint();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnAtRandomPoint()
    {
        if (spawnPoints == null || spawnPoints.Length == 0 || factory == null)
        {
            Debug.LogWarning("SpawnPoints: spawnPoints หรือ factory ยังไม่ได้เซ็ต");
            return;
        }

        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        
        factory.CreateRandomItem(spawnPoint.position, spawnPoint.rotation);
    }
}
