using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Person", menuName = "Scriptable Objects/Person")]
public class Person : ScriptableObject
{
    public Sprite _image;
    public string _name;
    public int _age;
    public string _text;
    public string _parametrs;
    public string[] _tags;
}