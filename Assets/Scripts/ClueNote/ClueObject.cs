using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Clue", menuName = "Scirptable Object/ClueData")]
public class ClueObject : ScriptableObject
{
    [Header("Item Button Name")]
    public string clueBtnName;

    [Header("Item Name")]
    public string clueName;

    [Header("Item Explain")]
    [TextArea(3, 10)]
    public string clueExplain;

    [Header("Replace Explain")]
    [TextArea(3, 10)]
    public string replaceExplain;

}
