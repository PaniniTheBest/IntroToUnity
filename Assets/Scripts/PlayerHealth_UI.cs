using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth_UI : MonoBehaviour
{
    public Image[] healthBar_UI;
    public Sprite emptyCell_HP;
    public Sprite fullCell_HP;

    private float maxHP;
    private float currentHP;

    private void Update()
    {     
        gameObject.TryGetComponent<Health>(out Health info_HP); //referenced HP
        maxHP = info_HP.GetMaxHP();
        currentHP = info_HP.GetCurrentHP();

        for (int i = 0; i < maxHP; i++)
        {
            if (i < currentHP)
                healthBar_UI[i].sprite = fullCell_HP;
            else
                healthBar_UI[i].sprite = emptyCell_HP;
        }
    }
}
