using AnnoyingAds.Scripts;
using UnityEngine;

[CreateAssetMenu(fileName = "Person", menuName = "Scriptable Objects/Person")]
public class Person : ScriptableObject
{
    public Sprite _image;
    public string _name;
    public int _age;
   [TextArea] public string _text;
   [TextArea] public string _parametrs;
    public ETags[] _tags;
}