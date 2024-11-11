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
    private bool ctrl;
    private void Start()
    {
        col = null; 
        animator = GetComponent<Animator>();
        ctrl = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7 && collectedTotal < GameController.Instance.maxCollected && ctrl)
        {
            animator.SetTrigger("punch");
            col = other;
            ctrl = false;
        }
    }

    public void Management()
    {
        if (col != null && col.gameObject.layer == 7 && collectedTotal < GameController.Instance.maxCollected)
        {
            ss.total--;
            collectedTotal++;
            Destroy(col.gameObject);
            collections[collectedTotal].SetActive(true);
        }
        ctrl = true;
    }
}