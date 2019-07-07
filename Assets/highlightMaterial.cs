using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class highlightMaterial : MonoBehaviour
{
    public Material m_default;

    private void Awake()
    {
        m_default = this.gameObject.GetComponent<Renderer>().material;
    }

}
