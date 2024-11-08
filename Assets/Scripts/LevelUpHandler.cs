using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpHandler : MonoBehaviour
{
    public int moneyUpdate = 150;
    public int taxIncrease = 150;
    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.layer == 3 && GameController.Instance.collectionLevel < 5 && GameController.Instance.money >= moneyUpdate)
        {
            GameController.Instance.collectionLevel += 1;
            GameController.Instance.maxCollected += 1;
            GameController.Instance.money -= moneyUpdate;
            moneyUpdate += taxIncrease;
        }
    }
}
