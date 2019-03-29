using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {
  [SerializeField] private float duration;
  [SerializeField][MultilineAttribute] private string text;
  
  [SerializeField] private float breakBeetweenChars;

  private void OnTriggerEnter(Collider other) {
    Debug.Log(other.gameObject.tag);

    //if (other.gameObject.tag.Equals("Player")) {
    //  StartCoroutine(DialogueManager.ShowTextCourutine(text, duration, breakBeetweenChars));
    //}
  }
}
