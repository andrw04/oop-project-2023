using CommunityToolkit.Mvvm.ComponentModel;
using FlashCardApplication.MyApplication.Abstractions;
using FlashCardApplication.Domain.Entities;
using CommunityToolkit.Mvvm.Input;
using FlashCardApplication.UI.Views;
using System.Collections.ObjectModel;

namespace FlashCardApplication.UI.ViewModels
{
    [QueryProperty(nameof(Module), nameof(Module))]
    public partial class ModuleViewModel : ObservableObject
    {
        private readonly IModuleService moduleService;

        public ObservableCollection<FlashCard> FlashCards { get; set; } = new();

        [ObservableProperty]
        Module module;

        [RelayCommand]
        async void GetBack() => await Shell.Current.GoToAsync("///" + nameof(HomePage));

        [RelayCommand]
        async void AddFlashCard() => await GotoNewFlashCard();

        [RelayCommand]
        async void UpdateFlashCardList() => await GetFlashCardList();

        [RelayCommand]
        async void Learn() => await GotoLearnPage();

        public ModuleViewModel(IModuleService moduleService)
        {
            this.moduleService = moduleService;
        }

        public async Task GetFlashCardList()
        {
            if (module != null)
            {
                var flashcards = await moduleService.GetAllModuleFlashCards(module.Id);
                await MainThread.InvokeOnMainThreadAsync(() =>
                {
                    FlashCards.Clear();
                    foreach (var flashcard in flashcards)
                    {
                        FlashCards.Add(flashcard);
                    }
                });
            }
        }

        public async Task GotoNewFlashCard()
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "Module", module }
            };
            await Shell.Current.GoToAsync(nameof(NewFlashCardPage), parameters);
        }

        public async Task GotoLearnPage()
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "Module", module }
            };
            await Shell.Current.GoToAsync(nameof(LearnPage), parameters);
        }
    }
}
