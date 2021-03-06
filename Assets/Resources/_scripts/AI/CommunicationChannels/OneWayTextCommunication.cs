﻿using System;
using UnityEngine;

/// <summary>
/// Text communication channel (one way). Same as parent class, but no input box and empty response.
/// </summary>
public class OneWayTextCommunication : TextCommunicationChannel {
    public override void StartCommunicationWithPlayer(Player player, GameAI ai, string message) {
        InitializeChannelFields(player, ai);

        //restrict players movements
        player.FreezePlayer();

        CreateTextBoxes(withPlayerWordBox: false);

        if (aiTextBox == null) {
            Debug.LogError("Could not find one of the text boxes for game AI to use.");
        }

        SplitMessageIntoLines(message);
        DisplayNextLine();
    }

    public override PlayerResponse GetResponse() {
        return new PlayerResponse(string.Empty);
    }
}

