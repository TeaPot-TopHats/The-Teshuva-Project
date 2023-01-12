using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * A scirptable object class that store all item created in a list
 */
[CreateAssetMenu(menuName ="ItemTable")]
public class Scriptable_ItemTable : ScriptableObject
{
    public List<Scriptable_Item> items;
}
