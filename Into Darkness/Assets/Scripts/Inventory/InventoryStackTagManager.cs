using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryStackTagManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI stackTypeText;
    [SerializeField] private TextMeshProUGUI stackCountText;
    [SerializeField] private ItemLibrary itemLibrary;
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
        if (item.name != null){

        } else {

        }
    }
}
