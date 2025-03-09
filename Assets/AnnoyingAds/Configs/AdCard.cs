using AnnoyingAds.Scripts;
using UnityEngine;

[CreateAssetMenu(fileName = "Ad", menuName = "Scriptable Objects/Ad")]
public class AdCard : ScriptableObject
{
    public Sprite _image;
    public string _name;
   [TextArea] public string _text;
    public ETags[] _positiveTags;
    public ETags[] _negativeTags;
}