using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject resourceList;
    [SerializeField] private GameObject resourcePrefab;
    [SerializeField] private GameObject inventoryList;
    [SerializeField] private GameObject inventoryPrefab;
    [SerializeField] private int size;
    [SerializeField] private AspectSpriteAtlas atlas;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i < (int)AspectType.MAX; i++) {
            ResourceIcon icon = Instantiate(resourcePrefab, resourceList.transform).GetComponent<ResourceIcon>();
            icon.SetCount(0);
            icon.SetImage(atlas.GetSprite((AspectType)i));
        }
        for (int i = 0; i < size; i++) {
            Instantiate(inventoryPrefab, inventoryList.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
