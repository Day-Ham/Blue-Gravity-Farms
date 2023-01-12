using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class FurniturePurchaseUI : MonoBehaviour,IPurchaseable
{
    [SerializeField] private FurnitureData data;

    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI costText;
    [SerializeField] private Image renderer;
    
    
    // Start is called before the first frame update
    void Start()
    {
        UpdatePrompt();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdatePrompt()
    {
        nameText.SetText(data.Name);
        costText.SetText(data.Cost.ToString());
        renderer.sprite = data.Icon;
        renderer.SetNativeSize();
    }

    public void Purchase()
    {
        //Instantiate Prefab
        Furniture furniture = Instantiate(data.Prefab, Vector3.zero, Quaternion.identity).GetComponent<Furniture>();
        furniture.baseData = data;
        //Interior Designer selected is this
        InteriorDesigner.Instance.SetSelected(furniture);
        InteriorDesigner.Instance.CanSelectFurniture=false;
        SAudioManager.instance.Play("Purchase");
    }
}
