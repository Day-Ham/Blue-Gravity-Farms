using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        Player player = FindObjectOfType<Player>();
        if (player!=null)
        {
            //player.GetComponent<Rigidbody>();
            player.GetComponent<Movement>().enabled = true;
            player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            player.transform.position = transform.position;
        }
    }

}
