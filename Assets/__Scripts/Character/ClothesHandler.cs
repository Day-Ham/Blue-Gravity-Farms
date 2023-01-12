using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ClothesHandler : MonoBehaviour
{
    
    private int index=0;
    [SerializeField] private List<GameObject> Clothes;
    public string currentSelection;
    public void Next()
    {
        index++;
        Show(Clothes[Mathf.Abs(index)% Clothes.Count].name);
        SAudioManager.instance.Play("Press");
    }
    
    public void Previous()
    {
        index--;
        Show(Clothes[Mathf.Abs(index)% Clothes.Count].name);
        SAudioManager.instance.Play("Press");
    }

    public void Hide()
    {
        foreach (var piece in Clothes)
        {
            piece.SetActive(false);
        }
    }


    public void Show(string nameOfOutfit)
    {
        currentSelection =nameOfOutfit;
        foreach (var piece in Clothes)
        {
            piece.SetActive(false);
        }
        foreach (var piece in Clothes)
        {
            if (piece.name == nameOfOutfit)
            {
                piece.SetActive(true);
                currentSelection = piece.name;
                
            }
        }
    }

    
    
    
}
