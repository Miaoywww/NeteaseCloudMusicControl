﻿using CommunityToolkit.Mvvm.ComponentModel;
using NonsPlayer.Core.Contracts.Adapters;

namespace NonsPlayer.Components.ViewModels;

[INotifyPropertyChanged]
public partial class AdapterCardViewModel
{
    [ObservableProperty] private string name;
    [ObservableProperty] private string platform;
    [ObservableProperty] private string author;
    [ObservableProperty] private string description;
    [ObservableProperty] private string version;
    [ObservableProperty] private string buildTime;
    [ObservableProperty] private Uri repository;
    [ObservableProperty] private AdapterMetadata metadata;

    partial void OnMetadataChanged(AdapterMetadata value)
    {
        Name = value.DisplayPlatform;
        Platform = value.Platform;
        Author = value.Author;
        Description = value.Description;
        Version = value.Version.ToString();
        BuildTime = value.UpdateTime.ToString("g");
        repository = value.Repository;
    }
}