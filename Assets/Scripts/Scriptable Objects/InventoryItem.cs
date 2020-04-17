using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryItem", menuName = "InventoryItem")]
public class InventoryItem : ScriptableObject
{
    // Start is called before the first frame update
    public string objectName;
    public Sprite icon;
}
