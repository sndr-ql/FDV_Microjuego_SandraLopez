using UnityEngine;

public class Deactivate : MonoBehaviour
{
    public float xLimit = 10;
    public float yLimit = 6;

    void Update()
    {
        Vector3 pos = transform.position;

        if (pos.x < -xLimit || pos.x > xLimit || pos.y < -yLimit || pos.y > yLimit) {
            gameObject.SetActive(false);
        }
    }
}
