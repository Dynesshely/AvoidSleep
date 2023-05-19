using KitX.Contract.CSharp;
using System;
using System.Collections.Generic;

namespace AvoidSleep.WPF;

public class IdentityEntry : IIdentityInterface
{
    public string GetName() => "AvoidSleep";

    public string GetVersion() => "v0.1.0";

    public Dictionary<string, string> GetDisplayName() => new()
        {
            { "zh-cn", "AvoidSleep" },
            { "zh-cnt", "AvoidSleep" },
            { "en-us", "AvoidSleep" },
        };

    public string GetAuthorName() => "Dynesshely";

    public string GetPublisherName() => "Crequency";

    public string GetAuthorLink() => "https://blog.catrol.cn";

    public string GetPublisherLink() => "https://catrol.cn";

    public Dictionary<string, string> GetSimpleDescription() => new()
        {
            { "zh-cn", "防锁屏、防睡眠、保持亮屏" },
            { "zh-cnt", "防鎖屏、防睡眠、保持亮屏" },
            { "en-us", "Anti-lock screen, anti-sleep, keep screen bright" },
        };

    public Dictionary<string, string> GetComplexDescription() => new()
        {
            { "zh-cn", "开启或关闭防止系统自动锁屏，自动睡眠的功能，通过定时向系统发送消息实现" },
            { "zh-cnt", "開啓或關閉防止系統自動鎖屏，自動睡眠的功能，通過定時向系統發送消息實現" },
            { "en-us", "Enable or disable the function of preventing the system from automatically locking the screen and sleeping automatically by sending messages to the system at regular intervals" },
        };

    public Dictionary<string, string> GetTotalDescriptionInMarkdown() => new()
        {
            { "zh-cn", "开启或关闭防止系统自动锁屏，自动睡眠的功能，通过定时向系统发送消息实现" },
            { "zh-cnt", "開啓或關閉防止系統自動鎖屏，自動睡眠的功能，通過定時向系統發送消息實現" },
            { "en-us", "Enable or disable the function of preventing the system from automatically locking the screen and sleeping automatically by sending messages to the system at regular intervals" },
        };

    public string GetIconInBase64() => "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";

    public DateTime GetPublishDate() => DateTime.Now;

    public DateTime GetLastUpdateDate() => DateTime.Now;

    public IController GetController() => new Controller();

    public bool IsMarketVersion() => false;

    public IMarketPluginContract GetMarketPluginContract() => null;

    public string GetRootStartupFileName() => "AvoidSleep.WPF.dll";
}
