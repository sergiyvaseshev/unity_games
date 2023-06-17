using System.Collections.Generic;
using UnityEngine;

namespace Item {
  public class ItemRandom : Poolable {
    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    [SerializeField]
    private List<Sprite> _listSprite;

    private void OnEnable() {
      int randomIndex = Random.Range(0, _listSprite.Count);
      _spriteRenderer.sprite = _listSprite[randomIndex];
    }
  }
}