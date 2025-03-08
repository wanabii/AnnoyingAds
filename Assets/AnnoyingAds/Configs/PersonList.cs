using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PersonList", menuName = "Scriptable Objects/List")]
public class PersonList : ScriptableObject
{
    public List<Person> _list;
}