using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorway : MonoBehaviour
{

    [SerializeField] private SceneTransition _transition;

    [SerializeField]  private bool isIndoor = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (LayerMask.NameToLayer("Furniture") != other.gameObject.layer)
        {
            _transition.GoToNextScene();
                    if(isIndoor) 
                        InteriorDesigner.Instance.SaveLayout();
        }
            
        
    }
}
