using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public GameObject FragmentoDchaPrefab;
    public GameObject FragmentoIzqPrefab;

    public float explosionForce = 3f;
    public float expansionForce = 50f;

    private Rigidbody _rigid;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public void Expansion(Vector3 direction)
    {
        if (FragmentoDchaPrefab == null || FragmentoIzqPrefab == null)
    {
        gameObject.SetActive(false); // O Destroy(gameObject) si no usas pool para fragmentos
        return;
    }
        Vector3 pos = transform.position;

        Vector3 dirDcha = Quaternion.Euler(0, 0, -90) * direction.normalized;
        Vector3 dirIzq = Quaternion.Euler(0, 0, 90) * direction.normalized;
       
        GameObject fragDcha = Instantiate(FragmentoDchaPrefab, pos + dirDcha, Quaternion.identity);
        GameObject fragIzq = Instantiate(FragmentoIzqPrefab, pos + dirIzq, Quaternion.identity);
       
        Rigidbody fragDchaRigid = fragDcha.GetComponent<Rigidbody>();
        Rigidbody fragIzqRigid = fragIzq.GetComponent<Rigidbody>();

        fragDchaRigid.linearVelocity = (dirDcha + direction.normalized * 0.6f).normalized * explosionForce;
        fragIzqRigid.linearVelocity = (dirIzq + direction.normalized * 0.6f).normalized * explosionForce;

        float rand = Random.Range(-0.5f, 0.5f);
        Vector3 vectDcha = (dirDcha + direction.normalized * 0.3f).normalized;
        fragDchaRigid.AddForce(vectDcha * explosionForce);
        
        Vector3 vectIzq = (dirIzq + direction.normalized * 0.3f).normalized;
        fragIzqRigid.AddForce(vectIzq * explosionForce);
        
        gameObject.SetActive(false);
    }
}
