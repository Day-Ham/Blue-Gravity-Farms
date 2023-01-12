using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Furniture : MonoBehaviour
{
    [SerializeField] private SpriteRenderer renderer;
    
    [SerializeField] private Collider2D placementCollider;
    [SerializeField] private Collider2D rigidCollider;
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] public FurnitureData baseData;

    [SerializeField] public bool CanBePlace=false;
    [SerializeField] bool Building = false;
    float rotationOffset=0;
    
    Vector2 mousePosition ;
    [SerializeField] private Ease placementEase;

    private void Start()
    {
        //BuildMode(true);
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        IndicateVaibility();  
    }
    
    void FixedUpdate()
    {
        if (Building)
        {
             rb.MovePosition(mousePosition);
        }
           
    }
    public void BuildMode(bool toggle)
    {
        if (toggle)
        {
            placementCollider.enabled = true;
            rigidCollider.enabled = false;
            Building = true;
        }
        else
        {
            Debug.Log("Is Rigid");
            placementCollider.enabled = false;
            rigidCollider.enabled = true;
            rigidCollider.isTrigger = false;
            Building = false;
        }
        renderer.color = Color.white;
    }
    void IndicateVaibility()
    {
        if (Building)
        {
            if (CanBePlace)
                renderer.color = Color.green;
            else
                renderer.color = Color.red;
        }
    }
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        CanBePlace = false;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        CanBePlace = true;
    }

    public void PlaceAnimation()
    {
        transform.localScale = Vector3.zero;
        transform.DOScale(Vector2.one, .25f).SetEase(placementEase);
    }

    public void InvalidAnimation()
    {
        transform.DOShakePosition(1, .1f);
    }

    public void SoldAnimation()
    {
        transform.DOScale(Vector2.zero, .25f).OnComplete(() =>
        {
            Destroy(gameObject);
        });
    }
}
