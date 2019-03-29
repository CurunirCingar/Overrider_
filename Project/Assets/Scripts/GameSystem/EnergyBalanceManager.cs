using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBalanceManager : MonoBehaviour
{
    [SerializeField]
    private CameraEffectsManager cameraEffect;

    private bool invincible;

    [SerializeField]
    float totalBalance = 150;
    [SerializeField]
    float balance;
    
    [SerializeField]
    Slider energySlider;
    [SerializeField]
    Text energyText;

    public float Balance
    {
        get
        {
            return balance;
        }

        set
        {
            balance = value;
            energySlider.value = (balance / totalBalance);
            energyText.text = string.Format("{0:.0} exaFLP", balance);
        }
    }

    // Use this for initialization
    void Start ()
    {
        Balance = totalBalance;
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public bool ConsumeBalance(float value)
    {
        if(balance < value)
        {
            Debug.Log("Low balance");
            var diff = balance - value;
            cameraEffect.RunGlitchEffect(diff);
            return false;
        }
        Balance -= value;
        cameraEffect.RunGlitchEffect(value);
        return true;
    }

    public void RecieveDamage(float damage)
    {
        if (balance <= 0 || invincible)
            return;
        if (damage > balance)
            damage = balance;
        Balance -= damage;
        cameraEffect.RunGlitchEffect(damage);
        invincible = true;
        StartCoroutine(EnableDamage());
    }

    private IEnumerator EnableDamage()
    {
        yield return new WaitForSeconds(2f);
        invincible = false;
    }
}
