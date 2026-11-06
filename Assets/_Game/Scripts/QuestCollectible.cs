using UnityEngine;

public class QuestCollectible : MonoBehaviour, IInteractable
{
    public bool CanInteract()
    {
        return true;
    }

    public void Interact()
    {
        if (ShroomQuest.Instance == null) return;

        if (!ShroomQuest.Instance.questStarted || ShroomQuest.Instance.questCompleted)
        return;

        ShroomQuest.Instance.CollectMushroom();
        gameObject.SetActive(false);
    }
}