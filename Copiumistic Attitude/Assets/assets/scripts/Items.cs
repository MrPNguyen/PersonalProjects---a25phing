using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Items/ New Item")]
public class Items : ScriptableObject
{
    public string name;
    
    public int[] prices;
    
    [TextArea(5, 20)]
    public string description;
    
    public Image img;
}
