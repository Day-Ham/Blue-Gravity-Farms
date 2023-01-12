using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CropData", menuName = "ScriptableObjects/CropData", order = 1)]
public class CropData : ScriptableObject
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public string Description { get; private set; }
    
    [field: SerializeField] public float GrowthTime { get; private set; }
    [field: SerializeField] public int Value { get; private set; }
    
    [field: SerializeField] public Sprite ZeroPercent { get; private set; }
    [field: SerializeField] public Sprite QuaterPercent { get; private set; }
    [field: SerializeField] public Sprite ThirdQuaterPercent { get; private set; }
    [field: SerializeField] public Sprite HundredPercent { get; private set; }
}
