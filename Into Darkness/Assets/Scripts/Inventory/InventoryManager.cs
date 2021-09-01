using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    [SerializeField] private int size;
    private int count = 0;
    [SerializeField] private GameObject inventorySlot;
    [SerializeField] private GameObject inventoryList;
    private InventorySlotManager[] inventorySlotManagerList;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < size; i++) {
            GameObject obj = (GameObject)Instantiate(inventorySlot, inventoryList.transform);
            obj.GetComponent<InventorySlotManager>().InitSlot();
        }
        RegenerateSlotManagers();

        InsertItem(new Item{
            type = ItemType.Default
        });
        InsertItem(new Item{
            type = ItemType.Default
        });
        InsertItem(new Item{
            type = ItemType.Default
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*public void SetSize(int newSize) {
        if (newSize < size) {
            GameObject[] iList = inventorySlotList;
            inventorySlotList = new GameObject[newSize];
            for (int i = 0; i < size; i++)
                if (i < newSize)
                    inventorySlotList[i] = iList[i];
                else
                    Destroy(iList[i]);
        } else if (newSize > size) {
            GameObject[] iList = inventorySlotList;
            inventorySlotList = new GameObject[newSize];
            for (int i = 0; i < newSize; i++)
                if (i < size)
                    inventorySlotList[i] = iList[i];
                else
                    inventorySlotList[i] = Instantiate(inventorySlot, inventoryList.transform);
        }
        size = newSize;
        RegenerateSlotManagers();
    }*/

    private void RegenerateSlotManagers() {
            inventorySlotManagerList = inventoryList.GetComponentsInChildren<InventorySlotManager>();
    }

    public bool InsertItem(Item item) {
        if (count >= size)
            return false;
        foreach (InventorySlotManager slot in inventorySlotManagerList)
        {
            if (slot.ContainsItem()) 
                continue;
            
            slot.InsertItem(item);
            break;
        }
        return true;
    }
}
