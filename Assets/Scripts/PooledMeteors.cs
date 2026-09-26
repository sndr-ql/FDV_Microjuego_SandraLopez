using UnityEngine;
using System.Collections.Generic;

public class PooledMeteors : MonoBehaviour
{
    public GameObject _meteorPrefab;
    List<GameObject> _pool_astPrefab = new List<GameObject>();

    int _totalMeteorsSpawned = 0;
    int _totalTimesPooled = 0;

    public GameObject GetMeteor(Vector3 location)
    {
        for (int i = 0; i < _pool_astPrefab.Count; i++) {
            if (!_pool_astPrefab[i].activeInHierarchy) {
                GameObject pooledAst = _pool_astPrefab[i];
                pooledAst.transform.position = location;
                pooledAst.transform.rotation = Quaternion.identity;

                Rigidbody astRigid = pooledAst.GetComponent<Rigidbody>();
                astRigid.linearVelocity = Vector3.zero;
                astRigid.angularVelocity = Vector3.zero;

                pooledAst.SetActive(true);

                _totalTimesPooled++;
                Debug.LogWarning($"[POOL ASTEROIDES] Reutilizado. Creados: {_totalMeteorsSpawned} | Reutilizados: {_totalTimesPooled}");
                return pooledAst;
            }
        }

        GameObject newAst = Instantiate(_meteorPrefab, location, Quaternion.identity);
        _pool_astPrefab.Add(newAst);
        _totalMeteorsSpawned++;

        Debug.LogWarning($"[POOL ASTEROIDES] Nueva Instancia. Creados: {_totalMeteorsSpawned} | Reutilizados: {_totalTimesPooled}");
        return newAst;
    }

}
