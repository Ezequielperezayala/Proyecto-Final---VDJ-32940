using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsManager : MonoBehaviour
{
    [SerializeField] GameObject[] weapons;

    [SerializeField] Transform playerHand;

    [SerializeField] List<GameObject> weaponsList;

    public List<GameObject> WeaponsList { get => weaponsList; set => weaponsList = value; }
    
    private Dictionary<string, GameObject> weaponDictionary;
    public Dictionary<string, GameObject> WeaponDictionary { get => weaponDictionary; set => weaponDictionary = value; }

    // Start is called before the first frame update
    void Start()
    {
        weaponsList = new List<GameObject>();
        weaponDictionary = new Dictionary<string, GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        EquipWeapon();
    }

    void EquipWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weaponDictionary["Sword15_Lava"].SetActive(true);
            weaponDictionary["Sword15_Frost"].SetActive(false);
            weaponDictionary["Sword12_Red"].SetActive(false);
            weaponDictionary["Sword15_Lava"].transform.parent = playerHand;
            weaponDictionary["Sword15_Lava"].transform.localPosition = Vector3.zero;

        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weaponDictionary["Sword15_Lava"].SetActive(false);
            weaponDictionary["Sword15_Frost"].SetActive(true);
            weaponDictionary["Sword12_Red"].SetActive(false);
            weaponDictionary["Sword15_Frost"].transform.parent = playerHand;
            weaponDictionary["Sword15_Frost"].transform.localPosition = Vector3.zero;

        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            weaponDictionary["Sword15_Lava"].SetActive(false);
            weaponDictionary["Sword15_Frost"].SetActive(false);
            weaponDictionary["Sword12_Red"].SetActive(true);
            weaponDictionary["Sword12_Red"].transform.parent = playerHand;
            weaponDictionary["Sword12_Red"].transform.localPosition = Vector3.zero;

        }
    }
}
