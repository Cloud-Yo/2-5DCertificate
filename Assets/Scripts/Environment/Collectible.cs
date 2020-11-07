using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private int _points = 5;
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //other.GetComponent<Player>().AddCollectScore(_points);
            UIManager.Instance.UpdateScore(_points);
            other.GetComponentInChildren<Animator>().SetTrigger("PickUp");
            Destroy(this.gameObject);
        }
    }
}
