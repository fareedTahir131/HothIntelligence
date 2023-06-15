using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class JsonClasses : MonoBehaviour
{
    
}
[Serializable]
public class Patient
{
    public GameObject[] Models;
}
[Serializable]
public class ModelMaterials
{
    public Material DefaultMaterial;
    public Material TransparentMaterial;
}
[Serializable]
public class Models
{
    public ModelMaterials[] materials;
}