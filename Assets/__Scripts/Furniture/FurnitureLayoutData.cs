using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "FurnitureLayout", menuName = "ScriptableObjects/FurnitureLayout")]
public class FurnitureLayoutData : ScriptableObject
{
    public FurnitureTransform[] AllFurniture;
}
