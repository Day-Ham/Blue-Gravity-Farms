using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Outfit", menuName = "ScriptableObjects/Outfit")]
public class PlayerOutfit : ScriptableObject
{
    [field: SerializeField] public string Accesory { get;  set; }
    [field: SerializeField] public string Body { get;  set; }
    [field: SerializeField] public string Hair { get;  set; }
    [field: SerializeField] public string Pants { get;  set; }
    [field: SerializeField] public string Top { get;  set; }
}
