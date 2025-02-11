using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; 
    public int player1Score = 0;
    public int player2Score = 0;
    public TextMeshProUGUI player1Text;
    public TextMeshProUGUI player2Text;

        void Awake(){
        // Ensure only one instance exists
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddPointToPlayer1()
    {
        player1Score++;
        UpdateScoreUI();
    }

    public void AddPointToPlayer2()
    {
        player2Score++;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        player1Text.text = player1Score.ToString();
        player2Text.text = player2Score.ToString();
    }
}
