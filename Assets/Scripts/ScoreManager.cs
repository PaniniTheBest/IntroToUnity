using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance { get; private set; }

    public Text currentScore_Txt;
    public Text highScore_Txt;

    private int currentScore_Value = 0;
    private int highScore_Value = 0;

    private void Awake()
    {
        if (instance != null)
        { 
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Start()
    {
        highScore_Value = PlayerPrefs.GetInt("highScore_Value", 0);
        currentScore_Txt.text =  "Score: " + currentScore_Value.ToString();
        highScore_Txt.text = "High Score: " + highScore_Value.ToString();
    }

    public void AddPoint(int pointValue)
    {
        currentScore_Value += pointValue;
        currentScore_Txt.text = "Score: " + currentScore_Value.ToString();

        if (highScore_Value < currentScore_Value)
            PlayerPrefs.SetInt("highScore_Value", currentScore_Value);
    }
}
