using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class PoolManager : MonoBehaviour {
  public static Action<Poolable> ReturnPoolItem;
  public static Action CreateRandomItem;

  private readonly List<GameObject> _poolParents = new List<GameObject>();
  private readonly Dictionary<Type, Pool<Poolable>> _dictionary = new Dictionary<Type, Pool<Poolable>>();

  [SerializeField]
  private List<Poolable> _prefabPoolablesList;

  [SerializeField]
  private int _createStartItem;

  [SerializeField]
  private ParticleSystem _getItemParticleSystem;
  [SerializeField]
  private ParticleSystem _returnItemParticleSystem;

  private void Awake() {
    CreatePool();
    CreateItem();
    ReturnPoolItem += ReturnFromPool;
    CreateRandomItem += GetRandomItem;
  }

  private void OnDestroy() {
    ReturnPoolItem -= ReturnFromPool;
    CreateRandomItem -= GetRandomItem;
  }

  private void CreateItem() {
    for (int i = 0; i < _createStartItem; i++) {
      GetRandomItem();
    }
  }

  private void GetRandomItem() {
    List<Type> poolableTypes = new List<Type>(_dictionary.Keys);

    int randomIndex = Random.Range(0, poolableTypes.Count);
    Type selectedType = poolableTypes[randomIndex];

    Poolable poolable = _dictionary[selectedType].GetFromPool();
    poolable.transform.position = GetRandomPosition();
  }

  private Vector2 GetRandomPosition() {
    float randomX = Random.Range(-9f, 13f);
    float randomY = Random.Range(-7f, 7f);
    Vector2 randomPosition = new Vector2(randomX, randomY);

    return randomPosition;
  }

  private T GetFromPool<T>() where T : Poolable {
    if (!_dictionary.ContainsKey(typeof(T))) {
      Debug.LogError($"Poolable type {typeof(T)} not found in dictionary!");
      return null;
    }

    return (T)_dictionary[typeof(T)].GetFromPool();
  }

  private void ReturnFromPool (Poolable poolable) {
    Pool<Poolable> pool = _dictionary[poolable.GetType()];
    pool.ReturnToPool(poolable);
  }

  private void CreatePool() {
    foreach (Poolable prefabPoolable in _prefabPoolablesList) {

      GameObject poolParent = new GameObject(nameof(prefabPoolable) + "Pool");
      poolParent.transform.SetParent(transform);

      Pool<Poolable> pool = new Pool<Poolable>(() => {
        Poolable poolable = Instantiate(prefabPoolable, poolParent.transform);
        poolable.ParentTransform = poolParent.transform;
        poolable.PickParticle = _getItemParticleSystem;
        poolable.ReturnParticle = _returnItemParticleSystem;
        return poolable;
      });

      _poolParents.Add(poolParent);
      _dictionary.Add(prefabPoolable.GetType(), pool);
    }
  }
}