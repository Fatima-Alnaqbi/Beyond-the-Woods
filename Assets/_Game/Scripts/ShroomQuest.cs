using UnityEngine;

public class ShroomQuest : MonoBehaviour
{
    public static ShroomQuest Instance { get; private set; }

    public int requiredMushrooms = 3;

    public int collectedMushrooms { get; private set; }
    public bool questStarted { get; private set; }
    public bool questCompleted { get; private set; }

    void Awake()
    {
        Instance = this;
    }

    public void StartQuest()
    {
        if (questStarted) return;

        questStarted = true;
    }

    public void CollectMushroom()
    {
        if (!questStarted || questCompleted) return;

        if (collectedMushrooms >= requiredMushrooms) return;

        collectedMushrooms++;

    }

    public void CompleteQuest()
    {
        if (!questStarted || questCompleted) return;
        if (collectedMushrooms < requiredMushrooms) return;

        questCompleted = true;
    }
}