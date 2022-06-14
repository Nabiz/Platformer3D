using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
  
  public AudioSource coinFX;
  private CoinsManager coinsManager;

    private void Start()
    {
        coinsManager = GameObject.Find("Canvas").GetComponent<CoinsManager>();
    }

    void OnTriggerEnter(Collider other)
  {
        if (other.CompareTag("Player"))
        {
            coinFX.Play();
            coinsManager.coins += 1;
            this.gameObject.SetActive(false);
        }
  }
}
