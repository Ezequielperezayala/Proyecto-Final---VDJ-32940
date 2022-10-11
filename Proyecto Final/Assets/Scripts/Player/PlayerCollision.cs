using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class PlayerCollision : MonoBehaviour
{
    PlayerData playerData;

    [SerializeField]
    AudioSource Heal;

    [SerializeField] 
    Animator playerAnimatorController;

    [SerializeField]
    AudioSource Gold;

    [SerializeField]
    AudioSource GameOver;

    public UnityEvent Soundheal;
    public UnityEvent SoundGold;
    public UnityEvent SoundGameOver;

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
            //HUDManager.HealBar(playerData.HP);
            PlayerCollision.OnchangeHP(playerData.Hp);
            if (playerData.Hp >= 100)
            {
                Destroy(other.gameObject);
                playerData.Healing(0);
                Soundheal?.Invoke();
            }
            else
            {
                Destroy(other.gameObject);
                playerData.Healing(20);
                Soundheal?.Invoke();
            }
        }

        if (other.tag == "Score")
        {
            Debug.Log("tocaste" + other.gameObject.name);
            Destroy(other.gameObject);
            GameManager.Score += 5;
            Debug.Log("Puntuacion =" + GameManager.Score);
            //HUDManager.instance.ViewScore("" + GameManager.Score);
            PlayerCollision.OnPick("" + GameManager.Score);
            SoundGold?.Invoke();
        }

        if (other.gameObject.CompareTag("Weapons"))
        {
            other.gameObject.SetActive(false);
            weaponManager.WeaponsList.Add(other.gameObject);
            weaponManager.WeaponDictionary.Add(other.gameObject.name, other.gameObject);
        }

        if (other.tag == "instantDeath")
        {
            playerData.Damage(40);
            //HUDManager.HealBar(playerData.HP);
            PlayerCollision.OnchangeHP(playerData.Hp);
            Destroy(other.gameObject);

            if (playerData.Hp <= 0)
            {
                Debug.Log("Interactuando con Ondead");
                PlayerCollision.Ondead.Invoke();
                SoundGameOver?.Invoke();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "EnemiesAtack")
        {
            PlayerCollision.OnchangeHP(playerData.Hp);
            if (playerData.Hp == 0)
            {
                PlayerCollision.Ondead.Invoke();
                playerData.Damage(0);
                SoundGameOver?.Invoke();
            }
            else
            {
                playerAnimatorController.SetBool("Damage", true);
                playerAnimatorController.Play("Damage");
                Invoke("DelayDamage", 0.25f);
                playerData.Damage(5);
            }

        }

        
    }

    void DelayDamage()
    {
        playerAnimatorController.SetBool("Damage", false);
    }

}
