using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : MonoBehaviour
{
    [SerializeField] private GameObject speechbubble;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (LayerMask.NameToLayer("Furniture") != col.gameObject.layer)
        {
            SAudioManager.instance.Play("ShopKeep");
            speechbubble.SetActive(true);
        }
         
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (LayerMask.NameToLayer("Furniture") != other.gameObject.layer)
        {
            speechbubble.SetActive(false);
        }
            
    }
}
