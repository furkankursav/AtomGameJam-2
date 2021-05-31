using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Dinamit : MonoBehaviour
{
    public float beklemeSuresi = 3f;
    public float patlamaYaricapi = 5f;
    public float patlamaGucu = 700f;
    public LayerMask whatIsDamageable;

    public GameObject patlamaEfekti;
    public GameObject madenExplosion;

    float geriSayim;
    bool patladiMi;

    private void Start()
    {
        patladiMi = false;
        geriSayim = beklemeSuresi;
    }

    private void Update()
    {
        geriSayim -= Time.deltaTime;
        if(geriSayim <= 0f && !patladiMi)
        {
            patladiMi = true;
            Patlat();
        }
    }

    void Patlat()
    {
        Destroy(Instantiate(patlamaEfekti, transform.position, Quaternion.Euler(0f, 0f, Random.Range(0f, 360f))), 2f);
        CameraShaker.Instance.ShakeOnce(4f, 4f, 0.1f, 1f);
        GameObject.Find("BombaPatlamaSesi").GetComponent<AudioSource>().Play();
        Collider2D[] colls = Physics2D.OverlapCircleAll(transform.position, patlamaYaricapi, whatIsDamageable);
        Destroy(Instantiate(madenExplosion, transform.position, Quaternion.identity), 2f);
        foreach(Collider2D nesne in colls)
        {
            Destroy(nesne.gameObject);
            //camera salla
        }

        Destroy(gameObject);

    }
}
