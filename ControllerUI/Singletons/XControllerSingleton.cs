using ControllerUI.Data;
using SharpDX.XInput;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace ControllerUI.Singletons
{
    public class XControllerSingleton
    {
        private static XControllerSingleton _xControllerInstance;
        private static readonly object _instanceLock = new object();
        private Controller _controller;
        private Task _task;
        public static XControllerSingleton XControllerInstance
        {
            get
            {
                lock (_instanceLock)
                {
                    if (_xControllerInstance == null)
                    {
                        return new XControllerSingleton();
                    }
                    return _xControllerInstance;
                }
            }
        }
        public bool ControllerIsConected => _controller.IsConnected;
        public async Task RunAppAsync(Dispatcher dispatcher, TextBlock txtKeysPressed)
        {
            try
            {
                _controller = new Controller(UserIndex.One);
                _task = Task.Run(async () =>
                {
                    while (true)
                    {
                        var state = _controller.GetState();
                        var keys = XKeyData.KeysStatusDictionary(state).Where(x => x.Value is true);

                        dispatcher?.Invoke(() =>
                        {
                            txtKeysPressed.Text = string.Join("\n", keys.Select(x => $"{x.Key} is pressed")); ;
                        });
                        await Task.Delay(125);
                    }
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message ,"Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
