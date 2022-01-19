using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace PirateGame.Utils
{
    public class ObjectPooling : MonoBehaviour
    {
        private List<GameObject> _pooledObjects = new List<GameObject>();

        [SerializeField] private GameObject _objectPrefab;
        [SerializeField] private int _amount = 10;

        private void Awake()
        {
            InstantiateObjects();
        }

        private void InstantiateObjects()
        {
            for (int i = 0; i < _amount; i++)
            {
                GameObject pooledObject = Instantiate(_objectPrefab);
                pooledObject.SetActive(false);
                _pooledObjects.Add(pooledObject);
            }
        }

        public GameObject GetObject()
        {
            GameObject pooledObject = _pooledObjects.FirstOrDefault(o => !o.activeSelf);
            if (pooledObject == null)
            {
                pooledObject = Instantiate(_objectPrefab);
                _pooledObjects.Add(pooledObject);
            }

            pooledObject.SetActive(true);
            return pooledObject;
        }
    }
}

