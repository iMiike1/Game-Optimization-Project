using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : Photon.MonoBehaviour {

    // Health and Damage
    public float health = 50f;
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Update()
    {
    }

    // [PunRPC] void ChatMessage(string a, string b)
    // {
    //    Debug.Log(string.Format("ChatMessage {0} {1}", a, b));
    // }


    // photonView.RPC("ChatMessage", PhotonTargets.All, "jup", "and jup!");

    void Die()
    {
        Destroy(gameObject);
    }
}
