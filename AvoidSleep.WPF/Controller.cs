using KitX.Contract.CSharp;
using KitX.Web.Rules;
using System.Collections.Generic;
using System.Windows;
using System;

namespace AvoidSleep.WPF;

internal class Controller : IController
{
    internal Action<Command>? sendCommandAction;

    public void Start()
    {
        var mainWin = new MainWindow();

        Application.Current.MainWindow = mainWin;

        mainWin.Show();
    }

    public void Pause() { }

    public void End()
    {
        Application.Current.MainWindow?.Close();
    }

    public void Execute(Command cmd) { }

    public List<Function> GetFunctions()
    {
        return new();
    }

    public void SetSendCommandAction(Action<Command> action) => sendCommandAction = action;

    public void SetRootPath(string path) { }

    public void SetWorkPath(string path) { }
}
