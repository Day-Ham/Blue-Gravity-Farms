using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FurnitureData", menuName = "ScriptableObjects/FurnitureData")]
public class FurnitureData : ScriptableObject
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public int Cost { get; private set; }
    [field: SerializeField] public int SellValue { get; private set; }
    [field: SerializeField] public GameObject Prefab { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }
}
