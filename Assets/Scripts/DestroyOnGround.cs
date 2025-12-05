using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnGround : MonoBehaviour
{
    public string groundTag = "Ground"; // ตั้งค่า Tag ของพื้น

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(groundTag))
        {
            Destroy(gameObject); // ทำลาย Ball
        }
    }
}
