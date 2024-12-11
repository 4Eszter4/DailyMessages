==============================================================
  Messages - 2024 Nov 28 - v1.0
==============================================================

Summary:
--------

Desktop mini app.

Generates new messages every day from the built-in json file, depending on the number of the actual day of the year.

Messages can be overwrite with a new json file from the build folder with proper naming: "messageDataJson".
The different categories can contain different number of messages.
3 types of messages are defined and can be used.

Application can run in the backgroud.

The more computation demanding parts, such as particle system or disturbing audio effect are switched off after loading and first impression.


Used sources:
----------------

- AudioToolkit: https://assetstore.unity.com/packages/tools/audio/audio-toolkit-free-version-2679

- Animated 2D treasure box: https://assetstore.unity.com/packages/tools/audio/audio-toolkit-free-version-2679

- Icons of the buttons: Selfmade .png files.


Quick Guide:
------------

Open the app.
Default message is always generated without command.
Select the wanted message type at the upper right corner of the window and the desired message will be loaded.
Clicking onto the treasure box re-initializes the scene and refreshes the messages if the day changed after the last run.
