using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class ClothesPurchaseUI : MonoBehaviour,IPurchaseable
{
    
    
    [SerializeField] private OutfitShopOption data;

    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI costText;
    [SerializeField] private Image renderer;
    private bool Purchased = false;
    
    enum ClothType{Accesory,Hair,Pants,Top}

    [SerializeField] private ClothType type;
    
    
    // Start is called before the first frame update
    void Start()
    {
        CheckIfPurchased();
        
        UpdatePrompt();
    }
    void UpdatePrompt()
    {
        nameText.SetText(data.Name);
        if(!Purchased)
            costText.SetText(data.Cost.ToString());
        else
        {
            costText.SetText(" ");
        }
        renderer.sprite = data.Icon;
        renderer.SetNativeSize();
    }

    public void Purchase()
    {
        if (GameManager.Instance.Money >= data.Cost && !Purchased)
        {
            GameManager.Instance.Money -= data.Cost;
            AddPurchaseToWardrobe();
            Purchased=true;
            SAudioManager.instance.Play("Purchase");
        }
        
        if (Purchased)
        {
            EquipPurchase();
        }

        UpdatePrompt();
    }

    void CheckIfPurchased()
    {
        switch (type)
        {
            case ClothType.Accesory:
               Purchased = ClothesManager.Instance.AccesoryWardrobe.Contains(data.Name);
                break;
            case ClothType.Hair:
                Purchased = ClothesManager.Instance.HairWardrobe.Contains(data.Name);
                break;
            case ClothType.Pants:
                Purchased = ClothesManager.Instance.PantsWardrobe.Contains(data.Name);
                break;
            case ClothType.Top:
               Purchased = ClothesManager.Instance.TopWardrobe.Contains(data.Name);
                break;
            
        }
    }

    void AddPurchaseToWardrobe()
    {
        switch (type)
        {
            case ClothType.Accesory:
                ClothesManager.Instance.AddToAccessoryWardrobe();
                break;
            case ClothType.Hair:
                ClothesManager.Instance.AddToHairWardrobe();
                break;
            case ClothType.Pants:
                ClothesManager.Instance.AddToPantsWardrobe();
                break;
            case ClothType.Top:
                ClothesManager.Instance.AddToTopWardrobe();
                break;
        }
    }

    void EquipPurchase()
    {
        switch (type)
        {
            case ClothType.Accesory:
                ClothesManager.Instance.ChangeAccesory(data.Name);
                break;
            case ClothType.Hair:
                ClothesManager.Instance.ChangeHair(data.Name);
                break;
            case ClothType.Pants:
                ClothesManager.Instance.ChangePants(data.Name);
                break;
            case ClothType.Top:
                ClothesManager.Instance.ChangeTop(data.Name);
                break;
        }
    }
    
    
}
