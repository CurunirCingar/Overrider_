using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour {

    public Collider firstTrig;
    public Collider secTrig;
    float speedText = 0.001f;
	// Use this for initialization
	void Start () {
        MessageFromStart();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        
        if (other == firstTrig)
        {
            MessageAfterTrigger();
            firstTrig.gameObject.SetActive(false);
        }

        if (other == secTrig)
        {
            MessageInTheEnd();
            secTrig.gameObject.SetActive(false);
        }
    }

    void MessageFromStart()
    {
        DialogueManager instance = DialogueManager.instance;
        instance.ShowText("Tip: Press Tab to enable hacking mode. In hacking mode " +
            "you can change properties of your surrounding.");
        instance.ShowText("Unknown_1: I have bad feeling about this...");
        instance.ShowText("Unknown_2: Really? Come on! It's stupid to not use all these weaknesses that they left. They may fix it soon and we will loose it all!");
        instance.ShowText("Unknown_1: Ok then. I'm going to start overwatch jammer - are you ready?");
        instance.ShowText("Unknown_2: More than ever.");
    }

    void MessageAfterTrigger()
    {
        DialogueManager instance = DialogueManager.instance;
        instance.ShowText("Unknown_1: Wait. Seems that our activity have just spotted.");
        instance.ShowText("Unknown_2: Oh...");
        instance.ShowText("Unknown_1: They're trying to identify us! Get out of there!");
        instance.ShowText("Unknown_2: How?!");
        instance.ShowText("Unknown_1: Find this sector's simulation gateway. You can safely jump from there wherever you want. " +
            "It placed in tallest bulding in this sector you should clearly see it from yourfo̦:̅foԦ:Ԇf:܇HʹFHͼWf�������������������������������");
    }

    void MessageInTheEnd()
    {
        DialogueManager instance = DialogueManager.instance;
        instance.ShowText("Unknown_2: I've started to loosing you! That was close! Connect to their's API with your neurolink.");
    }
}
