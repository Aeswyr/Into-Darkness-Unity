using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Item", order = 1)]
public class Item : ScriptableObject
{
    public int id;
    public Sprite sprite;
}
