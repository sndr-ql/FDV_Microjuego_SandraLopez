using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class PooledBullets : MonoBehaviour
{
    public GameObject _bulletPrefab;
    List<GameObject> _pool_bulletPrefab = new List<GameObject>();

    int _totalSpawnedBullets = 0;
    int _totalTimesPooled = 0;

    public GameObject GetBullet(Vector3 direction, Vector3 location) {
        
        for (int i = 0; i < _pool_bulletPrefab.Count; i++) {
            if (!_pool_bulletPrefab[i].activeInHierarchy) {
                GameObject pBullet = _pool_bulletPrefab[i];
                pBullet.transform.position = location;
                pBullet.GetComponent<Bullet>().targetVector = direction;
                pBullet.gameObject.SetActive(true);
                _totalTimesPooled++;

               // Debug.LogWarning($"[POOL BALAS] Reutilizada del Pool. Creadas: {_totalSpawnedBullets} | Reutilizadas: {_totalTimesPooled}");
                return _pool_bulletPrefab[i];
            }
        }
        GameObject newBullet = Instantiate(_bulletPrefab, location, Quaternion.identity);
        newBullet.GetComponent<Bullet>().targetVector = direction;
        _pool_bulletPrefab.Add(newBullet);
        _totalSpawnedBullets++;

    //    Debug.LogWarning("Han spawneado: " + _totalSpawnedBullets + " balas\n"
     //   + "Se han spawneado: " + _totalTimesPooled + " veces");
        return newBullet;
    }
}
