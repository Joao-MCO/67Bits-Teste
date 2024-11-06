using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectSpawn : MonoBehaviour
{
    public SpawnerScript ss;
    public int collectedTotal = 0;
    public GameObject[] collections;
    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.layer == 7 && collectedTotal < GameController.Instance.maxCollected)
        {
            Destroy(collision.gameObject);
            ss.total--;
            collections[collectedTotal].SetActive(true);
            collectedTotal++;
        }
    }
}
