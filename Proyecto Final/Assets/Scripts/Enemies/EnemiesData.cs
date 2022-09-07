using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemie Data", menuName = "Crear Enemie Data")]
public class EnemiesData : ScriptableObject
{
    [Header("CONFIGURACION DE MOVIMIENTO")]

    [Tooltip("velocidad de 0 a 10")]
    [SerializeField]
    [Range(0, 10)]
    public float velocidad;
   
    
    [Header("CONFIGURACION DE RAYCAST")]
    [Tooltip("Raycast de 0 a 10")]
    [SerializeField]
    [Range(0, 10)]
    public float distance;
    

}
