using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public float spawnCooldown = 5.0f;
    public int maxQuantity = 10;
    public int total = 0;
    public GameObject sideline;
    private bool isAvailble = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(total < maxQuantity && isAvailble)
        {
            Vector3 spwanPosition = new Vector3(Random.Range(-10, 11), 4f, Random.Range(-8, 9));
            Instantiate(sideline, spwanPosition, Quaternion.identity);
            StartCoroutine(startCooldown());
            total++;
        }
    }

    IEnumerator startCooldown()
    {
        isAvailble = false;

        yield return new WaitForSeconds(spawnCooldown);

        isAvailble = true;
    }
}
