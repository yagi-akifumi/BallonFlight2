using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStage : MonoBehaviour
{
    public GameObject block;
    public GameObject Boss;
    public bool hyouji = false;
    

    // Start is called before the first frame update
    void Start()
    {
        block.SetActive(false);
        Boss.SetActive(false);


    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag=="Player")
        {
            hyouji = true;
            Debug.Log("ボス戦に入る");
            block.SetActive(true);
            Boss.SetActive(true);

        }


    }

    
}
