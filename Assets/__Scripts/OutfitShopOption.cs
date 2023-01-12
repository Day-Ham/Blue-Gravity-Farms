using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "OutfitShopOption", menuName = "ScriptableObjects/OutfitShopOption")]
public class OutfitShopOption : ScriptableObject
{
    public Sprite Icon;
    public string Name;
    public int Cost;
    
}
