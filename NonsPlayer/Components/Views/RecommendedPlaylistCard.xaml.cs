using System.Windows.Forms;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
using NonsPlayer.Components.ViewModels;
using NonsPlayer.Core.Contracts.Models.Music;
using NonsPlayer.Core.Models;
using NonsPlayer.Core.Services;
using NonsPlayer.Helpers;
using UserControl = Microsoft.UI.Xaml.Controls.UserControl;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace NonsPlayer.Components.Views;

[INotifyPropertyChanged]
public sealed partial class RecommendedPlaylistCard : UserControl
{
    public RecommendedPlaylistCard()
    {
        ViewModel = App.GetService<RecommendedPlaylistCardViewModel>();
        InitializeComponent();
    }

    public RecommendedPlaylistCardViewModel ViewModel { get; }

    public IMusic[] Music
    {
        set
        {
            BeginAnimation();
            AvatarAnimation.Completed += (sender, o) => { BeginAnimation(); };
            ViewModel.Init(value);
        }
    }

    private async void BeginAnimation()
    {
        AvatarAnimation.Children[0].SetValue(DoubleAnimation.FromProperty, AvatarTransform.Y);
        AvatarAnimation.Children[0].SetValue(DoubleAnimation.ToProperty, AvatarTransform.Y <= -300 ? 0 : -300);
        AvatarAnimation.Begin();
    }
}