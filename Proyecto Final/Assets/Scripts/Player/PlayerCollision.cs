using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    PlayerData playerData;

    private void Start()
    {
        playerData = GetComponent<PlayerData>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PowerUp")
        {
            Debug.Log("tocaste" + other.gameObject.name);
            Destroy(other.gameObject);
            playerData.Healing(5);
        }
        
    }
}
