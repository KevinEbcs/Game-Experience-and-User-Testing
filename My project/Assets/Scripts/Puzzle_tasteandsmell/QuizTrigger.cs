using UnityEngine;

public class QuizTrigger : MonoBehaviour
{
    public QuizManager quizManager;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            quizManager.OpenQuizPanel();
        }
    }
}
