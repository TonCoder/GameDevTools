using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour {

    [SerializeField] internal Slider hpSlider;
    [SerializeField] internal Image hpCircle;
    [SerializeField] internal float decreaseSpeed = 3;

    private bool hpSet = false;

    private Coroutine running;

    private void Start()
    {
        hpCircle.fillAmount = 1;
    }

    private void OnDisable() {
        hpCircle.fillAmount = 1;
        if(running != null)
            StopCoroutine(running);
    }

    public void UpdateHp(Vector2 value)
    {
        UpdateHealthBar(value.x, value.y);
    }

    private void UpdateHealthBar(float currentHp, float maxHp)
    {
        if (hpCircle && !hpSet)
        {
           if(hpCircle.fillAmount > 0)
            {
                hpSet = true;
                StopCoroutine(running);
                running = StartCoroutine(UpdateHealthCircle(currentHp, maxHp));
            }
        }
        if(hpSlider){
            hpSlider.value = Mathf.Lerp(hpSlider.value, currentHp, decreaseSpeed);
        }
    }

    private IEnumerator<float> UpdateHealthCircle(float hpLeft, float maxHp){

        float currentHpVal = hpCircle.fillAmount;
        float percentAfterDamage = Mathf.Abs((hpLeft / maxHp));

        float elapsedTime = 0;

        while(elapsedTime < decreaseSpeed){
            elapsedTime += Time.deltaTime;
            hpCircle.fillAmount = Mathf.Lerp(currentHpVal, percentAfterDamage, elapsedTime / decreaseSpeed);
            yield return 0;
        }

        hpCircle.fillAmount = percentAfterDamage;
        hpSet = false;
    }
}