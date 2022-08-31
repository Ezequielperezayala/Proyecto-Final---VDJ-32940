using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    PlayerData playerData;

    [SerializeField] WeaponsManager weaponManager;

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

        if (other.tag == "Score")
        {
            Debug.Log("tocaste" + other.gameObject.name);
            Destroy(other.gameObject);
            GameManager.Score += 5;
            Debug.Log("Puntuacion =" + GameManager.Score);
        }

        if (other.gameObject.CompareTag("Weapons"))
        {
            other.gameObject.SetActive(false);
            weaponManager.WeaponsList.Add(other.gameObject);
            weaponManager.WeaponDictionary.Add(other.gameObject.name, other.gameObject);
        }
    }

    
}
