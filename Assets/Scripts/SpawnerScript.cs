using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public float spawnCooldown = 5.0f;
    public int maxQuantity = 10;
    public int total = 10;
    public GameObject sideline;
    public Transform[] positions;
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
            Instantiate(sideline, positions[Random.Range(0, positions.Length)].position, Quaternion.identity);
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
