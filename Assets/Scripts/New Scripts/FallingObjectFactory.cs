using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectFactory : MonoBehaviour
{
    [Tooltip("Prefab ที่จะสุ่มสร้าง (ของตก, ลูกบอล, ผลไม้ ฯลฯ)")]
    public GameObject[] itemPrefabs;

    public GameObject CreateRandomItem(Vector3 position, Quaternion rotation)
    {
        if (itemPrefabs == null || itemPrefabs.Length == 0)
        {
            Debug.LogWarning("FallingObjectFactory: ไม่มี prefab ให้สร้าง");
            return null;
        }

        int index = Random.Range(0, itemPrefabs.Length);
        GameObject prefab = itemPrefabs[index];

        return Instantiate(prefab, position, rotation);
    }
}
