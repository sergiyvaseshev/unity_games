using System;
using UnityEngine;
public class Pool<T> where T : Poolable {
  private readonly Func<T> _factory;

  private int _poolSize;

  public Pool (Func<T> func) {
    _factory = func;
  }

  public T GetFromPool() {
    T poolable = _factory?.Invoke();
    poolable.OnPickFromPool();
    return poolable;
  }

  public void ReturnToPool (T poolable) {
    poolable.OnReturnToPool();
    poolable.transform.SetParent(poolable.ParentTransform);
  }
}

public interface IPoolable {

  public void OnPickFromPool();

  public void OnReturnToPool();
}

public abstract class Poolable : MonoBehaviour, IPoolable {

  public Transform ParentTransform;
  public ParticleSystem PickParticle;
  public ParticleSystem ReturnParticle;

  private ParticleSystem _particlePick;
  private ParticleSystem _particleReturn;

  public virtual void OnPickFromPool() {
    gameObject.SetActive(true);

    if (_particlePick == null) {
      _particlePick = Instantiate(PickParticle, transform.position, transform.rotation, transform);
    } else {
      _particlePick.Play();
    }
  }

  public virtual void OnReturnToPool() {
    gameObject.SetActive(false);

    if (_particleReturn == null) {
      _particleReturn = Instantiate(ReturnParticle, transform.position, transform.rotation, transform.parent);
    } else {
      _particleReturn.Play();
    }
  }

  private void OnMouseDown() {
    PoolManager.ReturnPoolItem?.Invoke(this);
  }
}