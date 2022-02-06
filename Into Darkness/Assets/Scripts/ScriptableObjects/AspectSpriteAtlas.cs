using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AspectSpriteAtlas", menuName = "Into Darkness/AspectSpriteAtlas", order = 0)]
public class AspectSpriteAtlas : ScriptableObject {
    [SerializeField] private SerializableDictionary<AspectType, Sprite> atlas;

    public Sprite GetSprite(AspectType type) {
        return atlas[type];
    }
}

public enum AspectType {
    DEFAULT, FIBERS, STONE, METAL, STURDY, FOOD, LIQUID, MAX
}
