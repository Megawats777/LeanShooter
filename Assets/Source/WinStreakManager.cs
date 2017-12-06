using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class WinStreakManager : MonoBehaviour
{
    // Variables
    private static int winStreak = 0;

    public static int getWinStreak()
    {
        return winStreak;
    }

    public static void setWinStreak(int value)
    {
        winStreak = value; 
    }
}