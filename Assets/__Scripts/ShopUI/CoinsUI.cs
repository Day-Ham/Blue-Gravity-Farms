using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinsUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coins;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coins.SetText(GameManager.Instance.Money.ToString());
    }
}
