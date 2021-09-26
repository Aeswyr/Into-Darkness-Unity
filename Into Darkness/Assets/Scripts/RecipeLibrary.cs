using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/RecipeLibrary", order = 1)]
public class RecipeLibrary : ScriptableObject
{
    [SerializeField] private Recipe recipes;
}
