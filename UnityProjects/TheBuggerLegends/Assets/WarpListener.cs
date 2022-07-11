using System.Collections.Generic;
using UnityEngine;

public class WarpListener : MonoBehaviour
{
    public static WarpListener instance;
    [SerializeField] private ParticleSystem _particleSystem;

    private List<string> warnings = new List<string>
    {
        "Are you sure you are going to the right place?",
        "I believed you are lost",
        "All the assets of the game are free, just in case",
        "I guess you can't find the true path",
        "Hope you can find the true result before the dojo ends",
        $"Did you try this app on {AntagonistPlatform}?",
        $"You should learn how to debug on {AntagonistPlatform} too",
        "Subscribe to my patreon",
        "I should be working but instead I'm doing this game, don't tell Norber",
        "Dami is a tipazo",
        "If something happens to me, take care of Mati",
        "Mati is a bad influence, take care"
    };

    private static string AntagonistPlatform => Application.platform == RuntimePlatform.Android ? "iOS" : "Android";
    
    [SerializeField] private GamePath gamePath = null;

    private int currentIndex = 0;

    private void Awake()
    {
        instance = this;
    }

    public GamePath.Path GetNextPath() => gamePath.pathToArrive[currentIndex];

    public bool Arrived => currentIndex == gamePath.pathToArrive.Count;

    public void Listen(GamePath.Path path)
    {
        if(Arrived) return;

        bool isCorrect = gamePath.pathToArrive[currentIndex] == path;
        if (isCorrect)
        {
            currentIndex++;
            Debug.LogWarning(warnings[UnityEngine.Random.Range(0, warnings.Count)]);
        }
        else
        {
            currentIndex = 0;
            Debug.LogError("Oh this time you really f*cked up!");
        }

        if (Arrived)
        {
            _particleSystem.Play();
        }
        
    }
}
