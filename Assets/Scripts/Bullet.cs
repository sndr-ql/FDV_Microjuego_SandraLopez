using UnityEngine;
using TMPro;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float maxLifeTime = 3f;
    public Vector3 targetVector;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   // void Start()
    //{
    //    Destroy(gameObject, maxLifeTime);
    //}

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Bala moviéndose en: " + transform.position);
        transform.Translate(speed * targetVector * Time.deltaTime);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            IncreaseScore();

            Asteroid ast = collision.gameObject.GetComponent<Asteroid>();
            ast.Expansion(targetVector);
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        StartCoroutine(DisableGameObjectWithDelay(5.0f));
    }

    IEnumerator DisableGameObjectWithDelay(float delay) {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }

    private void IncreaseScore()
    {
        Player.score++;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        GameObject go = GameObject.FindGameObjectWithTag("UI");
        go.GetComponent<TMP_Text>().text = "Score: " + Player.score;
    }
}
