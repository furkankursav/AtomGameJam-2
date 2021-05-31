using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinamitFirlat : MonoBehaviour
{
    public float throwForce = 40f;
    public GameObject dinamitPrefab;

    public float sogumaSuresi = 1f;
    private float sonFirlastisZamani = Mathf.NegativeInfinity;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && Time.time >= sogumaSuresi + sonFirlastisZamani)
        {
            sonFirlastisZamani = Time.time;
            Firlat();
        }
    }

    void Firlat()
    {
        GameObject dinamit = Instantiate(dinamitPrefab, transform.position, transform.rotation);
        Rigidbody2D dinamitRB = dinamit.GetComponent<Rigidbody2D>();
        dinamitRB.AddForce(transform.right * throwForce, ForceMode2D.Impulse);
    }
}
