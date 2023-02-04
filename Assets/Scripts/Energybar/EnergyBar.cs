using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public Slider EnergyBarSlide;
    public Gradient EnergyGradiant;
    [SerializeField]
    private Image _fill;
    public float CurrentEnergy = 0f;
    public float _displayEnergy = 0f;
    public float _maxEnergyValue = 6f;
    
    private IEnumerator _coroutine;

    private void Awake()
    {
        EnergyBarSlide.maxValue = _maxEnergyValue;
        ClearEnergy();
        ChargeMaxEnergy();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            ChargeEnergy(1);
    }
    public void UpdateEnergy()
    {
        EnergyBarSlide.value = _displayEnergy;
        _fill.color = EnergyGradiant.Evaluate(EnergyBarSlide.normalizedValue);
    }
    public void ChargeMaxEnergy()
    {
        EnergyBarSlide.maxValue = _maxEnergyValue;
        CurrentEnergy = _maxEnergyValue;

        if (_coroutine != null)
            StopCoroutine(_coroutine);
        _coroutine = GradualUpdate(CurrentEnergy, 1f);
        StartCoroutine(_coroutine);
    }
    public void ClearEnergy()
    {
        CurrentEnergy = 0f;

        if (_coroutine != null)
            StopCoroutine(_coroutine);
        _coroutine = GradualUpdate(CurrentEnergy, 3f);
        StartCoroutine(_coroutine);
    }
    public void ChargeEnergy(float increment)
    {
        if (CurrentEnergy + increment > _maxEnergyValue)
            ChargeMaxEnergy();
        else
            CurrentEnergy += increment;

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = GradualUpdate(CurrentEnergy);
        StartCoroutine(_coroutine);
    }
    public bool LostEnergy(float decrement)
    {
        if (CurrentEnergy - decrement < 0)
            return false;
        CurrentEnergy -= decrement;

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = GradualUpdate(CurrentEnergy);
        StartCoroutine(_coroutine);
        return true;
    }
    private IEnumerator GradualUpdate(float targetEnergy, float speed = 0.1f)
    {
        UpdateEnergy();

        float amount = targetEnergy - _displayEnergy > 0 ? speed : -1 * speed;
        for (float f = Mathf.Abs(targetEnergy - _displayEnergy); f > 0; f -= speed)
        {
            _displayEnergy += amount;
            UpdateEnergy();
            yield return null;
        }
        _displayEnergy = targetEnergy;
        UpdateEnergy();
    }
}
