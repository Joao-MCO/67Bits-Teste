using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelUpHandler : MonoBehaviour
{
    public int moneyUpdate = 150;
    public int taxIncrease = 150;
    public ChangeColor main;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 3 && GameController.Instance.collectionLevel < 5 && GameController.Instance.money >= moneyUpdate)
        {
            GameController.Instance.collectionLevel += 1;
            GameController.Instance.maxCollected += 1;
            GameController.Instance.money -= moneyUpdate;
            moneyUpdate += taxIncrease;
            main.Change();
        }
    }
}
