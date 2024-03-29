using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
    public GameBehavior gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
        testMethod();

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(this.transform.parent.gameObject);

            Debug.Log("Item collected");

            gameManager.Items += 1;
        }

        gameManager.PrintLootReport();
    }

    private void testMethod()
    {
        Queue<string> activePlayers = new Queue<string>();

        activePlayers.Enqueue("Harrison");
        activePlayers.Enqueue("Alex");
        activePlayers.Enqueue("Haley");
        
        var firstPlayer = activePlayers.Peek(); //return first element in queue
        firstPlayer = activePlayers.Dequeue(); //return first element and delete it in queue
    }
}
