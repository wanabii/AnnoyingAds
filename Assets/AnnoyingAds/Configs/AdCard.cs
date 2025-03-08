using UnityEngine;

[CreateAssetMenu(fileName = "Ad", menuName = "Scriptable Objects/Ad")]
public class AdCard : ScriptableObject
{
    public Sprite _image;
    public string _name;
    public string _text;
    public string[] _positiveTags;
    public string[] _negativeTags;
}