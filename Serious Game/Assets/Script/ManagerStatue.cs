using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerStatue : MonoBehaviour
{
    public StatuaScript[] statuePuzzles;
    public Animator animator;

    private AudioSource audioSource;
    public AudioClip cassa;

    private int statuesSolvedCount = 0;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        foreach (var statuePuzzle in statuePuzzles)
        {
            statuePuzzle.SetPuzzleManager(this);
        }
    }

    public void NotifyStatueSolved()
    {
        statuesSolvedCount++;
        if (statuesSolvedCount >= statuePuzzles.Length)
        {
            StartAnimation();
            audioSource.PlayOneShot(cassa);
        }
    }

    private void StartAnimation()
    {
        if (animator != null)
        {
            animator.SetTrigger("Open");
        }
        else
        {
            Debug.LogWarning("Animator non assegnato al PuzzleManager.");
        }
    }
}
