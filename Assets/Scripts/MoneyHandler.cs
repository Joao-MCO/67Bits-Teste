using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyHandler : MonoBehaviour
{
    public CollectSpawn cs;
    public int moneyPerCollected = 25;
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.layer == 3)
        {
            GameController.Instance.money += cs.collectedTotal*moneyPerCollected;
            cs.collectedTotal = 0;
            foreach(GameObject aux in cs.collections)
            {
                aux.SetActive(false);
            }
        }
    }
}