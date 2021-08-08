using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryNameTagManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameTagText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetEnabled(bool enabled) {
        gameObject.SetActive(enabled);
    }

    public void SetText(Item item) {
        if (item.name != null)
            nameTagText.text = item.name;
        else
            nameTagText.text = LibraryManager.Instance.GetItems().GetName(item.type);
    }
}
