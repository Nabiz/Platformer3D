using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectCake : MonoBehaviour
{
    public AudioSource cakeFX;
    public string _levelSelection;

  void OnTriggerEnter(Collider other)
  {
        if (other.CompareTag("Player"))
        {
            cakeFX.Play();
            this.gameObject.SetActive(false);
            SceneManager.LoadScene(_levelSelection);
        }
  }
}
