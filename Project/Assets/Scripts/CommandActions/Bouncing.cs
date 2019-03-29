using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncing : MonoBehaviour {

  const float bounceScale = 10;

  void OnCollisionEnter(Collision collision) {
    Rigidbody otherRB = collision.collider.gameObject.GetComponent<Rigidbody>();

    if (otherRB != null) {
      Debug.Log(otherRB.velocity.y);
      if (otherRB.velocity.y != 0f) {
        otherRB.AddForce(Vector3.up * bounceScale, ForceMode.VelocityChange);
      }
    } else {
      Debug.Log("In Bouncing rigidbody not found.");
    }
  }
}
