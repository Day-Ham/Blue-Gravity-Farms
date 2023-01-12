using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OutfitLabel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmp;
    [SerializeField] private ClothesHandler clothesHandler;
    



    // Start is called before the first frame update
    void Start()
    {
        tmp.SetText(clothesHandler.currentSelection);
    }

    // Update is called once per frame
    void Update()
    {
        tmp.SetText(clothesHandler.currentSelection);
    }
}
