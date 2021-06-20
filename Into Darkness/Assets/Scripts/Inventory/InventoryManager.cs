using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    [SerializeField] private int size;
    [SerializeField] private GameObject inventorySlot;
    [SerializeField] private GameObject inventoryList;
    private GameObject[] inventorySlotList;
    private InventorySlotManager[] inventorySlotManagerList;

    // Start is called before the first frame update
    void Start()
    {
        inventorySlotList = new GameObject[size];
        for (int i = 0; i < size; i++)
            inventorySlotList[i] = Instantiate(inventorySlot, inventoryList.transform);
        RegenerateSlotManagers();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSize(int newSize) {
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
    }

    private void RegenerateSlotManagers() {
        for (int i = 0; i < size; i++)
            inventorySlotManagerList[i] = inventorySlotList[i].GetComponent<InventorySlotManager>();
    }
}
