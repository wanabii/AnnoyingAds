using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Person", menuName = "Scriptable Objects/Person")]
public class Person : ScriptableObject
{
    public Sprite image;
    public string name;
    public int age;
    public string text;
    public string parametrs;
    public string[] positiveTags;
    public string[] negativeTags;
}