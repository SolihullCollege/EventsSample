using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnBecameVisible()
    {
        Debug.Log("visible" + gameObject.name);
    
    }

    private void OnBecameInvisible()
    {
        Debug.Log("No longer visible" + gameObject.name);
       
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.gameObject);
        if(collision.gameObject.CompareTag("Player"))
        {
            GameManager.addNewPiece(gameObject.transform.parent.gameObject);
            GameManager.PlacePieces();
        }
    }
}
