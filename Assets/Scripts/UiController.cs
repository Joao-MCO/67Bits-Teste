using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiController : MonoBehaviour
{
    public TMP_Text level;
    public TMP_Text money;
    public TMP_Text carryingNow;
    public TMP_Text carryingMax;
    public CollectSpawn cs;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        level.text = (GameController.Instance.collectionLevel).ToString();
        money.text = (GameController.Instance.money).ToString();
        carryingNow.text = (cs.collectedTotal).ToString();
        carryingMax.text = (GameController.Instance.maxCollected).ToString();
    }
}
