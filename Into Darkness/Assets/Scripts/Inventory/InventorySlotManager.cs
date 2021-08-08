using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlotManager : MonoBehaviour
{
    [SerializeField] private InventoryNameTagManager nameTagManager;
    [SerializeField] private InventoryStackTagManager stackTagManager;
    [SerializeField] private ItemDisplayManager itemDisplayManager;
    [SerializeField] private InventorySlotPanelManager panelManager;

    private Item stored;
    private bool filled;

    // Start is called before the first frame update
    void Start()
    {
        SetSlotState(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InsertItem(Item item) {
        SetSlotState(true);
        stored = item;
        itemDisplayManager.SetItem(item);
        filled = true;
    }

    public Item RemoveItem() {
        Item item = stored;
        stored = default;
        itemDisplayManager.EmptyItem();
        SetSlotState(false);
        filled = false;
        return item;
    }

    private void SetSlotState(bool active) {
        nameTagManager.SetEnabled(active);
        stackTagManager.SetEnabled(active);
        itemDisplayManager.SetDisplayState(active);
        panelManager.SetDisplayState(active);
    }

    public bool ContainsItem() {
        return filled;
    }
}
