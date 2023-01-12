using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using DG.Tweening;
using UnityEngine;

public class InteriorDesigner : MonoBehaviour
{
    private static InteriorDesigner _instance;
    public static InteriorDesigner Instance { get { return _instance; } }

    public bool CanSelectFurniture = true;

    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Ease placementEase;
    
    
    [SerializeField] private FurnitureLayoutData layoutData;
    [SerializeField] private Furniture selectedFurniture;
    private List<FurnitureTransform> currentLayout = new List<FurnitureTransform>();
    private void Awake()
    {
       
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        } 
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (CanSelectFurniture )
            {
                //Moving Furniture Mechanic
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero,layerMask);
                if (hit.collider!=null) {
                    Debug.Log(hit.collider.name);
                    hit.collider.transform.parent.TryGetComponent<Furniture>(out selectedFurniture);
                    selectedFurniture.BuildMode(true);
                    CanSelectFurniture = false;
                }
            }
            else
            {
                //Placing Furniture Mechanic
                if (selectedFurniture != null)
                {
                    if (selectedFurniture.CanBePlace)
                    {
                        selectedFurniture.BuildMode(false);
                        transform.localScale = Vector3.zero;
                        selectedFurniture.PlaceAnimation();
                        selectedFurniture = null;
                        CanSelectFurniture = true;
                    }else
                    {
                        selectedFurniture.InvalidAnimation();
                    }
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (selectedFurniture != null)
            {
                selectedFurniture.transform.Rotate(0,0,selectedFurniture.transform.localRotation.z + 90);
            }
            else
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero,layerMask);
                if (hit.collider!=null) {
                    Furniture sold;
                    hit.collider.transform.parent.TryGetComponent<Furniture>(out sold);
                    GameManager.Instance.Money += sold.baseData.Cost;
                    SAudioManager.instance.Play("Coins");
                    sold.SoldAnimation();
                }
            }
        }
        
    }
    public void SetSelected(Furniture newFurniture)
    {
        selectedFurniture = newFurniture;
    }


    public void AddToLayOut(FurnitureData prefab, Vector2 position, float rotation)
    {
        FurnitureTransform toAdd = new FurnitureTransform();
        toAdd.data = prefab;
        toAdd.position = position;
        toAdd.rotation = rotation;
        
        currentLayout.Add(toAdd);
        
        
    }

    
    [ContextMenu("Save Layout")]
    public void SaveLayout()
    {
        Debug.Log("saving");
        Furniture[] furnitures = FindObjectsOfType<Furniture>();
        currentLayout.Clear();
        foreach (var toSave in furnitures)
        {
            AddToLayOut(toSave.baseData,toSave.transform.position,toSave.transform.rotation.z);
        }

        layoutData.AllFurniture = currentLayout.ToArray();
    }
    
    public void PlaceLoadedFurniture(FurnitureTransform newFurniture)
    {
        var furniture = Instantiate(newFurniture.data.Prefab);
        furniture.GetComponent<Furniture>().BuildMode(false);
        furniture.transform.position = newFurniture.position;
        furniture.transform.Rotate(0,0,newFurniture.rotation);
    }

    public void BuildRoom()
    {
        if (layoutData != null)
        {
            Debug.Log("loading layout");
            foreach (var loaded in layoutData.AllFurniture)
            {
                PlaceLoadedFurniture(loaded);
            }
        }
    }
    
}
