using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    static List<GameObject> toPlace = new List<GameObject>(); //create a new list that holds pieces to Place
    [SerializeField] GameObject[] pieces;
    static int furthest = 96;

    public TextMeshPro coinTxt;
    public int coins=0;

    public static void addNewPiece(GameObject thingToAdd)
    {
        toPlace.Add(thingToAdd);
        
    }

    public void collectCoin()
    {
        coins++;
        coinTxt.text="Coins: "+coins;
    }

    public void resetCoins()
    {
        coins-=0;
        coinTxt.text = "Coins: " + coins;
    }

    // Start is called before the first frame update
    void Start()
    {
        addNewPiece(Instantiate(pieces[Random.Range(0, pieces.Length)],transform.position,Quaternion.identity));
        addNewPiece(Instantiate(pieces[Random.Range(0, pieces.Length)], transform.position, Quaternion.identity));
        addNewPiece(Instantiate(pieces[Random.Range(0, pieces.Length)], transform.position, Quaternion.identity));
        addNewPiece(Instantiate(pieces[Random.Range(0, pieces.Length)], transform.position, Quaternion.identity));
        addNewPiece(Instantiate(pieces[Random.Range(0, pieces.Length)], transform.position, Quaternion.identity));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlacePieces()
    {
        int rand = Random.Range(0, toPlace.Count);
        furthest = furthest + 32;
        toPlace[rand].transform.position = new Vector3(furthest, 0, 0);
        toPlace.RemoveAt(rand);
    }
}
