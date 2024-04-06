using ControllerUI.Data;
using ControllerUI.Entities;
using ControllerUI.Services.Classes;
using ControllerUI.Services.Interfaces;
using SharpDX.XInput;
using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
        private readonly IGameService _gameService;
        public XControllerSingleton(IGameService gameService)
        {
            _gameService = gameService;
        }

        private static List<GameEntity> _gameList;
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
                        _xControllerInstance = new XControllerSingleton(new GameService());
                    }
                    return _xControllerInstance;
                }
            }
        }
        public async Task RunAppAsync(Dispatcher dispatcher, TextBlock txtKeysPressed)
        {
            try
            {
                _gameList = await _gameService.GetAllGamesAsync();
                _controller = new Controller(UserIndex.One);
                if (_controller.IsConnected)
                {
                    _task = Task.Run(async () =>
                    {
                        while (true)
                        {
                            var state = _controller.GetState();
                            var keyPressed = XKeyData
                                            .KeysStatusDictionary(state)
                                            .FirstOrDefault(x => x.Value.HasFlag is true);
                            if (!string.IsNullOrEmpty(keyPressed.Key))
                            {
                                var gameListName = _gameList
                                     .FirstOrDefault(x => x.Name
                                     .EndsWith(keyPressed.Key));
                                if (gameListName is not null)
                                {
                                    dispatcher.Invoke(() =>
                                    {
                                        txtKeysPressed.Text = keyPressed.Key;
                                    });
                                    keyPressed.Value.RunGame?.Invoke(gameListName.Name);
                                }
                            }
                            await Task.Delay(125);
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
