using UnityEngine;

[CreateAssetMenu(fileName = "Ad", menuName = "Scriptable Objects/Ad")]
public class AdCard : ScriptableObject
{
    public Sprite image;
    public string name;
    public string text;
    public string[] positiveTags;
    public string[] negativeTags;
}