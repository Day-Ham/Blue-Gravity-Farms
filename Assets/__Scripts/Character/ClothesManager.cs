using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesManager : MonoBehaviour
{
    [SerializeField] public PlayerOutfit Outfit;
    [SerializeField] public Player player;
    public bool CreatingCharacter = true;
    
    
    [Header("All Possible Outfits")]
    [Space(10)]
    [SerializeField] public List<string> AccesoryPool = new List<string>();
    [SerializeField] public List<string> BodyPool = new List<string>();
    [SerializeField] public List<string> HairPool =new List<string>();
    [SerializeField] public List<string> PantsPool =new List<string>();
    [SerializeField] public List<string> TopPool = new List<string>(); 
    
    [Header("All Player Owned Outfits")]
    [Space(10)]
    [SerializeField] public List<string> AccesoryWardrobe = new List<string>();
    [SerializeField] public List<string> BodyWardrobe = new List<string>();
    [SerializeField] public List<string> HairWardrobe = new List<string>();
    [SerializeField] public List<string> PantsWardrobe =new List<string>();
    [SerializeField] public List<string> TopWardrobe = new List<string>();

    [Header("All Player Owned Outfits")]
    [Space(10)]
    private static ClothesManager _instance;

    public static ClothesManager Instance { get { return _instance; } }
    
    private void Awake()
    {
       
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        } 
        DontDestroyOnLoad(gameObject);
    }
    
    
    public void ChangeAccesory(string desired)
    {
        Outfit.Accesory = desired;
        if (player != null)
        {
            player.UpdateOutfit();
        }
            
    }
    public void ChangeBody(string desired)
    {
        Outfit.Body = desired;
        if(player!=null)
            player.UpdateOutfit();
    }
    public void ChangeHair(string desired)
    {
        Outfit.Hair = desired;
        if(player!=null)
            player.UpdateOutfit();
    }
    public void ChangePants(string desired)
    {
        Outfit.Pants = desired;
        if(player!=null)
            player.UpdateOutfit();
    }
    public void ChangeTop(string desired)
    {
        Outfit.Top = desired;
        if(player!=null)
            player.UpdateOutfit();
    }
    
    
    public void AddToAccessoryWardrobe()
    {
        AccesoryWardrobe.Add(Outfit.Accesory);
    }
    public void AddToBodyWardrobe()
    {
        BodyWardrobe.Add(Outfit.Body);
    }
    public void AddToHairWardrobe()
    {
        HairWardrobe.Add(Outfit.Hair);
    }
    public void AddToPantsWardrobe()
    {
        PantsWardrobe.Add(Outfit.Pants);
    }
    public void AddToTopWardrobe()
    {
        TopWardrobe.Add(Outfit.Top);
    }

    public void AddOutfit()
    {
        AddToAccessoryWardrobe();
        AddToBodyWardrobe();
        AddToHairWardrobe();
        AddToPantsWardrobe();
        AddToTopWardrobe();
        
        
    }

    public void SaveOutfit()
    {
        Outfit.Accesory = player.Accesory.currentSelection;
        Outfit.Hair = player.Hair.currentSelection;
        Outfit.Top = player.Top.currentSelection;
        Outfit.Pants = player.Pants.currentSelection;
        Outfit.Body = player.Body.currentSelection;
        AddToAccessoryWardrobe();
        AddToHairWardrobe();
        AddToTopWardrobe();
        AddToPantsWardrobe();
    }
    
    

}
