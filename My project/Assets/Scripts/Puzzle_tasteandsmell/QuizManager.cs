using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public GameObject quizPanel;
    public TextMeshProUGUI question1Text;
    public TextMeshProUGUI question2Text;
    public TextMeshProUGUI question3Text;

    public TMP_InputField answer1Input;
    public TMP_InputField answer2Input;
    public TMP_InputField answer3Input;

    public TextMeshProUGUI feedbackText;
    public Button submitButton;

    
    private string[] questions = {
        "First food",
        "Second Food",
        "Third Food"
    };

    private string[] correctAnswers = {
        "Apple",
        "Ice Cream",
        "Bread"
    };

    void Start()
    {
        
        question1Text.text = questions[0];
        question2Text.text = questions[1];
        question3Text.text = questions[2];

        
        submitButton.onClick.AddListener(CheckAnswers);

        
        quizPanel.SetActive(false);
    }

    void Update()
    {
        
        if (quizPanel.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            CloseQuizPanel();
        }
    }

    public void OpenQuizPanel()
    {
        quizPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void CloseQuizPanel()
    {
        quizPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void CheckAnswers()
    {
        
        string answer1 = answer1Input.text.Trim();
        string answer2 = answer2Input.text.Trim();
        string answer3 = answer3Input.text.Trim();

        
        bool isCorrect1 = answer1.Equals(correctAnswers[0], System.StringComparison.OrdinalIgnoreCase);
        bool isCorrect2 = answer2.Equals(correctAnswers[1], System.StringComparison.OrdinalIgnoreCase);
        bool isCorrect3 = answer3.Equals(correctAnswers[2], System.StringComparison.OrdinalIgnoreCase);

        
        if (isCorrect1 && isCorrect2 && isCorrect3)
        {
            feedbackText.text = "You seem to be remembering what it felt like to feel... Your palate... Your sense of smell...";
        }
        else
        {
            feedbackText.text = "You don't have much time! Look for the fair, maybe reviewing the food will help you remember!";
        }
    }
}
