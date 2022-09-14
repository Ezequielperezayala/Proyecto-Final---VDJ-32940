using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerCollision : MonoBehaviour
{
    PlayerData playerData;

    [SerializeField] WeaponsManager weaponManager;

    public static event Action Ondead;
    public static event Action<int> OnchangeHP;
    public static event Action<string> OnPick;

    private void Start()
    {
        playerData = GetComponent<PlayerData>();
        //HUDManager.HealBar(playerData.HP);
        PlayerCollision.OnchangeHP(playerData.Hp);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PowerUp")
        {
            Debug.Log("tocaste" + other.gameObject.name);
            Destroy(other.gameObject);
            playerData.Healing(10);
            //HUDManager.HealBar(playerData.HP);
            PlayerCollision.OnchangeHP(playerData.Hp);
        }

        if (other.tag == "Score")
        {
            Debug.Log("tocaste" + other.gameObject.name);
            Destroy(other.gameObject);
            GameManager.Score += 5;
            Debug.Log("Puntuacion =" + GameManager.Score);
            //HUDManager.instance.ViewScore("" + GameManager.Score);
            PlayerCollision.OnPick("" + GameManager.Score);
        }

        if (other.gameObject.CompareTag("Weapons"))
        {
            other.gameObject.SetActive(false);
            weaponManager.WeaponsList.Add(other.gameObject);
            weaponManager.WeaponDictionary.Add(other.gameObject.name, other.gameObject);
        }

        if (other.tag == "instantDeath")
        {
            playerData.Damage(100);
            //HUDManager.HealBar(playerData.HP);
            PlayerCollision.OnchangeHP(playerData.Hp);
            Destroy(other.gameObject);

            if (playerData.Hp <= 0)
            {
                Debug.Log("Interactuando con Ondead");
                PlayerCollision.Ondead.Invoke();
            }
        }
    }

    
}
