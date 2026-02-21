using UnityEngine;
using UnityEngine.UI;

public class SliderHP_UI : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    private float currentHP = 0.0f;
    private float maxHP = 0.0f;

    //private void Awake()
    //{
    //    this.gameObject.TryGetComponent<Health>(out Health info_HP);
    //    currentHP = info_HP.GetCurrentHP();
    //    maxHP = info_HP.GetMaxHP();
    //    UpdateHealthBar(currentHP, maxHP);
    //}
    private void Update()
    {
        this.gameObject.TryGetComponent<Health>(out Health info_HP); //gets HP script
        currentHP = info_HP.GetCurrentHP();
        maxHP = info_HP.GetMaxHP();
        UpdateHealthBar(currentHP, maxHP);
    }
    private void UpdateHealthBar(float currentHealth, float maxHealth)//HP Bar
    {
        healthSlider.value = currentHealth / maxHealth;
    }
}
