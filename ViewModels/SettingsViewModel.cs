using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using ColorPicker.Models;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Beckjan.ViewModels;

public class SettingsViewModel : PageViewModel
{
    public SettingsViewModel(IScreen hostScreen) : base(hostScreen)
    {
        Theme = FromResource(nameof(Theme));
        Surface = FromResource(nameof(Surface));
        Text = FromResource(nameof(Text));
        DarkText = FromResource(nameof(DarkText));
        Accent = FromResource(nameof(Accent));
    }

    [Reactive]
    public ColorState Theme
    {
        get; set;
    }

    [Reactive]
    public ColorState Surface
    {
        get; set;
    }

    [Reactive]
    public ColorState Text
    {
        get; set;
    }

    [Reactive]
    public ColorState DarkText
    {
        get; set;
    }

    [Reactive]
    public ColorState Accent
    {
        get; set;
    }

    public void UpdateResources()
    {
        ToResource(nameof(Theme), Theme);
        ToResource(nameof(Surface), Surface);
        ToResource(nameof(Text), Text);
        ToResource(nameof(DarkText), DarkText);
        ToResource(nameof(Accent), Accent);
    }

    private static ColorState FromResource(string resource)
    {
        var color = ((SolidColorBrush)App.Current.Resources[resource]).Color;
        var colorState = new ColorState();
        colorState.SetARGB(color.A/255d, color.R/255d, color.G/255d, color.B / 255d);

        return colorState;
    }

    public static void ToResource(string resource, ColorState colorState)
    {
        var color = new Color()
        {
            A = FromFloatColorToByte(colorState.A),
            R = FromFloatColorToByte(colorState.RGB_R),
            G = FromFloatColorToByte(colorState.RGB_G),
            B = FromFloatColorToByte(colorState.RGB_B),
        };
        var brush = new SolidColorBrush(color);

        App.Current.Resources[resource] = brush;
    }

    public static byte FromFloatColorToByte(double value) => (byte)(value * 255);
}
