using UnityEngine;

public class SpriteFlipper : MonoBehaviour
{
    [SerializeField] private SpriteRenderer  _sprite;

    public void FlipSprite(bool watchRight)
    {
        _sprite.flipX = watchRight;
    }
}
