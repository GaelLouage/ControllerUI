using ControllerUI.Services.Interfaces;
using SharpDX.XInput;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ControllerUI.Data
{
    public class XKeyData
    {
        private const string ENSHROUDED = "enshrouded.exe";
        public static new Dictionary<string, (bool HasFlag, Action<string> RunGame)> KeysStatusDictionary(State state)
        {
            return new Dictionary<string, (bool HasFlag, Action<string> RunGame)>()
            {
               {ENSHROUDED,(HasFlag:state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.A), (gameToRun) => Process.Start(gameToRun))},
               //{"B", state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.B)},
               //{"X", state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.X)},
               //{"Y", state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Y)},
               //{"Back", state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Back)},
               //{"Start", state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.Start)},
               //{"RightThumb", state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.RightThumb)},
               //{"LeftThumb", state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.LeftThumb)},
               //{"LeftShoulder", state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.LeftShoulder)},
               //{"RightShoulder", state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.RightShoulder)},
               //{"DPadLeft", state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadLeft)},
               //{"DPadRight", state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadRight)},
               //{"DPadDown", state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadDown)},
               //{"DPadUp", state.Gamepad.Buttons.HasFlag(GamepadButtonFlags.DPadUp)}
            };
        }
    }
}
