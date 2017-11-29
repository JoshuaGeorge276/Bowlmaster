using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour {

    public Text[] rollTexts, frameTexts;

	// Use this for initialization
	void Start () {

	}

    public void FillRolls(List<int> rolls) {
        string strings = FormatRolls(rolls);
        for(int i = 0; i < strings.Length; i++) {
            rollTexts[i].text = strings[i].ToString();
        }
    }

    public void FillFrames(List<int> frames) {
        for(int i = 0; i < frames.Count; i++) {
            frameTexts[i].text = frames[i].ToString();
        }
    }

    public static string FormatRolls(List<int> rolls) {
        string output = "";
        for(int i = 0; i < rolls.Count; i++) {
            int box = output.Length + 1;
            if (rolls[i] == 0) {
                output += "-";
            } else if ((box % 2 == 0 || box == 21) && rolls[i] + rolls[i - 1] == 10) {
                output += "/";
            } else if (box >= 19 && rolls[i] == 10) {
                output += "X";
            } else if (rolls[i] == 10) {
                output += "X ";
            }else {
                output += rolls[i].ToString();
            }
        }
        Debug.Log(output);
        return output;
    }
}
