using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class Crop : MonoBehaviour
{
    [SerializeField] private CropData cropData;


    [SerializeField] private SpriteRenderer _renderer;

    private bool readyToHarvest = false;

    private float growthPercentage=0;
    // Start is called before the first frame update
    void Start()
    {
        _renderer.sprite = cropData.ZeroPercent;
        StartCoroutine(GrowthCycle());
    }

    IEnumerator GrowthCycle()
    { 
        _renderer.sprite = cropData.ZeroPercent;
        yield return new WaitForSeconds(Random.Range(1,5));
        DOTween.To(() => growthPercentage, x => growthPercentage = x, 200, cropData.GrowthTime)
            .OnUpdate(() => {
                if (growthPercentage >= 50)
                {
                    _renderer.sprite = cropData.QuaterPercent;
                }
                else if (growthPercentage >= 150)
                {
                    _renderer.sprite = cropData.ThirdQuaterPercent;
                }
            }).OnComplete(() => {
                    _renderer.sprite = cropData.HundredPercent;
                    readyToHarvest = true;
            });
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (readyToHarvest)
        {
            SAudioManager.instance.Play("Coins");
            GameManager.Instance.Money += 10;
            readyToHarvest = false;
            _renderer.sprite = cropData.ZeroPercent;
            StartCoroutine(GrowthCycle());
            
        }
    }
}
