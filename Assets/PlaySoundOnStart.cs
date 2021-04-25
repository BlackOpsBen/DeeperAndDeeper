using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnStart : MonoBehaviour
{
    [SerializeField] private int dialogCategoryIndex = 0;

    private void Start()
    {
        AudioManager.Instance.PlayDialog(dialogCategoryIndex);
    }
}
