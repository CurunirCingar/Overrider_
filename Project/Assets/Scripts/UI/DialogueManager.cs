using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{

    public static DialogueManager instance = null;

    private UnityEngine.UI.Text _text;
    private UnityEngine.UI.Image _image;

    const float meanCharReadingSpeed = 1f / ((161f * 6f) / 60f);

    private Queue<string> textQueue = new Queue<string>();
    private float typingSpeed = meanCharReadingSpeed * 0.35f;
    private float waitAfterPrint = 2f;
    private bool isDialogShowing;

    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Singleton DialogueManager doesn't work");
        }

        instance = this;
        _text = GetComponent<UnityEngine.UI.Text>();
        _image = transform.parent.GetComponent<UnityEngine.UI.Image>();

        if (_text == null)
        {
            Debug.Log("UI.Text in DialogueManager wasn't found");
        }
        if (_image == null)
        {
            Debug.Log("UI.Image in DialogueManager wasn't found");
        }

        _image.enabled = false;
    }

    public void ShowText(string text)
    {
        textQueue.Enqueue(text);

        if (!isDialogShowing)
        {
            StartCoroutine(ShowTextCourutine());
        }
    }

    public IEnumerator ShowTextCourutine()
    {
        instance._image.enabled = true;
        instance._text.enabled = true;
        while (textQueue.Count != 0)
        {
            isDialogShowing = true;
            instance._text.text = "";
            var text = textQueue.Dequeue();
            foreach (char c in text)
            {
                instance._text.text += c;
                yield return new WaitForSecondsRealtime(typingSpeed);
            }

            float printTime = text.Length * typingSpeed;
            yield return new WaitForSecondsRealtime(printTime * waitAfterPrint);
        }
        isDialogShowing = false;
        instance._image.enabled = false;
        instance._text.enabled = false;
    }
}
