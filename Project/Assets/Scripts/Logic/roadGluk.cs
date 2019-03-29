using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roadGluk : MonoBehaviour {
  [SerializeField] List<Material> _materials;
  private int _index;
  private MeshRenderer _meshRenderer;

	void Start () {
    _index = 0;
    _meshRenderer = GetComponent<MeshRenderer>();
	}
	
	void FixedUpdate () {
    _meshRenderer.material = _materials[_index];
    _index = (_index + 1) % _materials.Count;
	}
}
