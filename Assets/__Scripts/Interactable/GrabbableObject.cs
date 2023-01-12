using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GrabbableObject : MonoBehaviour,IInteractable
{
    [SerializeField] Rigidbody rb;
    // Start is called before the first frame update
    void Awake()
    {
        if(rb==null)
            rb =GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact(Transform handTransform)
    {
        Debug.Log("Grabbing");
        transform.parent = handTransform;
        transform.DOLocalMove(Vector3.zero, 0.25f);

        if (rb != null)
            rb.isKinematic = true;
        
    }

    public void Interact(HandInteractor hand)
    {
        if (hand.Item != null)
        {
            //TODO: Connect UI Manager Cant grab
            Debug.Log("There is an item already");
            return;
        }
            
        
        
        transform.parent = hand.HeldTransform;
        transform.DOLocalMove(Vector3.zero, 0.25f);
        hand.Item = gameObject;
        if (rb != null)
            rb.isKinematic = true;
    }
}
