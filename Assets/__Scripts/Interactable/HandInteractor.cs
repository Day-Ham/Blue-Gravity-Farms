using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandInteractor : MonoBehaviour
{
    [SerializeField] private float range;
    [SerializeField] LayerMask InteractableLayer;
    [field: SerializeField] public Transform HeldTransform {  get; private set; }

    [field:SerializeField] public GameObject Item {  get;  set; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, -Vector2.up, Color.green,range);
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up,range);
            if (hit.collider !=null)
             { 
                 IInteractable interactable = hit.collider.GetComponent<IInteractable>();
                 if (interactable !=null)
                 {
                     //if I had a tool do a check and then interact
                     interactable.Interact(this);

                 }
                 else
                 {
                     Debug.Log($"{hit.collider.name} does not have IIinteractable" );
                 }
             }
        }

    }

    public void RemoveHeldItem()
    {
        Item.transform.parent = null;
        Item = null;
    }

}
