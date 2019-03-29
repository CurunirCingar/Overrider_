using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class ReversiveGravity : MonoBehaviour {

  Rigidbody _rigidbody;

	// Use this for initialization
	void Start () {
    _rigidbody = GetComponent<Rigidbody>();
  }

  void FixedUpdate() {
    _rigidbody.AddForce(-Physics.gravity * 2 * _rigidbody.mass);
  }
}
