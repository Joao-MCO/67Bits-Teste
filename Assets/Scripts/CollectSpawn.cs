using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectSpawn : MonoBehaviour
{
    public SpawnerScript ss;
    public int collectedTotal = 0;
    public GameObject[] collections;
    private Animator animator;
    private Collider col;

    private void Start()
    {
        col = null; 
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7)
        {
            animator.SetTrigger("punch");
            col = other;
        }
    }

    public void Management()
    {
        if (col != null && col.gameObject.layer == 7)
        {
            ss.total--;
            collectedTotal++;
            Destroy(col.gameObject);
            collections[collectedTotal].SetActive(true);
        }
    }
}