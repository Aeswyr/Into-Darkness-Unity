using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AspectSpriteAtlas", menuName = "Into Darkness/AspectSpriteAtlas", order = 0)]
public class AspectSpriteAtlas : ScriptableObject {
    [SerializeField] private DataAtlas<AspectType, Sprite> atlas;
}

public enum AspectType {
    DEFAULT, FASTENER, THREAD, LEATHER, STONE, METAL, CARVABLE
}
