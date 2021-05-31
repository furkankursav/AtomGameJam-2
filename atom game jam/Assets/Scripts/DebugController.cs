using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugController : MonoBehaviour
{
    bool showConsole;
    bool showHelp;
    string input;

    public static DebugCommand SPEED_UP;
    public static DebugCommand JUMP_UP;
    public static DebugCommand HELP;
    public static DebugCommand<int> SET_SPEED;

    public List<object> commandList;

    private void Awake()
    {
        SPEED_UP = new DebugCommand("speed_up", "Oyuncuyu hızlandırır", "speed_up", () =>
        {
            FindObjectOfType<SideScrollerMovement>().SetPlayerSpeed();
        });

        JUMP_UP = new DebugCommand("jump_up", "Zıplama gücünün arttırır", "jump_up", () =>
        {
            FindObjectOfType<SideScrollerMovement>().SetPlayerJumpSpeed();
        });

        SET_SPEED = new DebugCommand<int>("set_speed", "Oyuncu hızını verilen değere ayarlar", "set_speed <new_speed>", (x) =>
        {
            //metodu çağır
        });

        HELP = new DebugCommand("help", "Komutları gösterir", "help", () =>
        {
            showHelp = true;
        });

        commandList = new List<object>
        {
            SPEED_UP,
            JUMP_UP,
            SET_SPEED,
            HELP
        };
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            showConsole = !showConsole;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (showConsole)
            {
                
                HandleInput();
                input = "";
            }
        }
    }

    void HandleInput()
    {

        string[] properties = input.Split(' ');


        for(int i = 0; i < commandList.Count; i++)
        {
            DebugCommandBase commandBase = commandList[i] as DebugCommandBase;
            if (input.Contains(commandBase.commandId))
            {
                if(commandList[i] as DebugCommand != null)
                {
                    (commandList[i] as DebugCommand).Invoke();
                }

                else if(commandList[i] as DebugCommand<int> != null)
                {
                    (commandList[i] as DebugCommand<int>).Invoke(int.Parse(properties[1]));
                }
            }
        }
    }


    Vector2 scroll;

    private void OnGUI()
    {
        if(!showConsole) { return; }

        float y = 0f;


        if (showHelp)
        {
            GUI.Box(new Rect(0, y, Screen.width, 100), "");
            Rect viewport = new Rect(0, 0, Screen.width - 30, 20 * commandList.Count);

            scroll = GUI.BeginScrollView(new Rect(0, y + 5f, Screen.width, 90), scroll, viewport);

            for(int i = 0; i < commandList.Count; i++)
            {
                DebugCommandBase command = commandList[i] as DebugCommandBase;

                string label = $"{command.commandFormat} - {command.commandDescription}";
                Rect labelRect = new Rect(5, 20 * i, viewport.width - 100, 20);
                GUI.Label(labelRect, label);
            }
            GUI.EndScrollView();
            y += 100;
        }

        GUI.Box(new Rect(0, y, Screen.width, 30), "");
        input = GUI.TextField(new Rect(10f, y + 5f, Screen.width - 20f, 20f), input);
    }
}
