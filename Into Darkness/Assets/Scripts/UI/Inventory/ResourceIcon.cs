using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResourceIcon : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI text;
    private int count = -1;

    public void SetCount(int count) {
        if (count == this.count)
            return;
        text.text = $"x{count}";
        this.count = count;
    }

    public void SetImage(Sprite image) {
        icon.sprite = image;
    }
}
