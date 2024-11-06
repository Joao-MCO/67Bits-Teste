using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectSpawn : MonoBehaviour
{
    public SpawnerScript ss;
    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.layer == 7)
        {
            Destroy(collision.gameObject);
            ss.total--;
        }
    }
}
