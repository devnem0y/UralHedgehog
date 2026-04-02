using System;
using UnityEngine;

namespace UralHedgehog.Core
{
    public static class PauseManager
    {
        public static event Action<bool> onPauseChanged;

        public static bool IsGamePaused { get; private set; }

        public static void SetGamePaused(bool paused)
        {
            if (IsGamePaused == paused) return;

            IsGamePaused = paused;
            onPauseChanged?.Invoke(paused);

            Debug.Log($"<color=cyan>PauseManager: Game {(paused ? "PAUSED" : "RESUMED")}</color>");
        }
    }
}