using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth_UI : Health
{
    public Image[] healthBar_UI;
    public Sprite emptyCell_HP;
    public Sprite fullCell_HP;

    //private float maxHP;
    //private float currentHP;


    protected override void UpdateHealth_UI(float currentHP)
    {
        //gameObject.TryGetComponent<Health>(out Health info_HP); //referenced HP
        //maxHP = info_HP.GetMaxHP();
        //currentHP = info_HP.GetCurrentHP();

        //if (currentHP == null) { return; }

        for (int i = 0; i < maxHealthPoints; i++)
        {
            if (i < currentHP)
                healthBar_UI[i].sprite = fullCell_HP;
            else
                healthBar_UI[i].sprite = emptyCell_HP;
        }
    }
}
