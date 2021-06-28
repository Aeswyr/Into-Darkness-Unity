using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplayManager : MonoBehaviour
{
    [SerializeField] private Image displaySlot;
    [SerializeField] private Sprite displayActiveImage;
    [SerializeField] private Sprite displayInactiveImage;
    [SerializeField] private Image itemSlot;
    [SerializeField] private ItemLibrary itemLibrary;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDisplayState(bool active) {
        if (active)
            displaySlot.sprite = displayActiveImage;
        else {
            displaySlot.sprite = displayInactiveImage;
            itemSlot.sprite = null;
        }
    }

    public void SetItem(Item item) {
        itemSlot.sprite = itemLibrary.GetSprite(item.type);
    }

    public void EmptyItem() {
        itemSlot.sprite = null;
    }
}
