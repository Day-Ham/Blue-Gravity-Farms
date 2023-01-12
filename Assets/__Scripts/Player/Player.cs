using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private PlayerOutfit Outfit;
   
    //Animators
    [SerializeField] public ClothesHandler Accesory;
    [SerializeField] public ClothesHandler Body;
    [SerializeField] public ClothesHandler Hair;
    [SerializeField] public ClothesHandler Pants;
    [SerializeField] public ClothesHandler Top;
    void Start()
    {
        UpdateOutfit();
        ClothesManager.Instance.player = this;
    }

    public void UpdateOutfit()
    {
        Accesory.Show(Outfit.Accesory);
        Body.Show(Outfit.Body);
        Hair.Show(Outfit.Hair);
        Pants.Show(Outfit.Pants);
        Top.Show(Outfit.Top);
        
    }
}
