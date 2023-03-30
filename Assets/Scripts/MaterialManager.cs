using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MaterialManager : MonoBehaviour
{
    [SerializeField] private Renderer[] _renderers;

    public void SetMaterial(Material material)
    {
        var span = new Span<Renderer>(_renderers);

        for (int i = 0; i < span.Length; i++)
        {
            span[i].sharedMaterial = material;
        }
    }
}
