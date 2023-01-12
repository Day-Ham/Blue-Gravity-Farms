using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Shop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Hide();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Hide()
    {
        transform.DOLocalMoveY(transform.localPosition.y-500, 2);
    }
    public void Show()
    {
        transform.DOLocalMoveY(transform.localPosition.y+500, 2);
    }
}
