using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlotManager : MonoBehaviour
{
    [SerializeField] private InventoryNameTagManager nameTagManager;
    [SerializeField] private InventoryStackTagManager stackTagManager;
    [SerializeField] private ItemDisplayManager itemDisplayManager;
    [SerializeField] private InventorySlotPanelManager panelManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InsertItem() { //TODO InsertItem(Item item)

    }

    public void RemoveItem() { //TODO public Item 

    }

    private void SetSlotState(bool active) {
        nameTagManager.SetEnabled(active);
        stackTagManager.SetEnabled(active);
        itemDisplayManager.SetDisplayState(active);
        panelManager.SetDisplayState(active);
    }
}
