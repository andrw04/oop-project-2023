using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FlashCardApplication.Domain.Entities;
using FlashCardApplication.MyApplication.Abstractions;
using FlashCardApplication.UI.Views;
using System.Collections.ObjectModel;

namespace FlashCardApplication.UI.ViewModels
{
    [QueryProperty(nameof(Module), nameof(Module))]
    public partial class LearnViewModel : ObservableObject
    {
        IModuleService moduleService;
        public ObservableCollection<FlashCard> FlashCards { get; set; } = new();

        int flashCardId = 0;

        [ObservableProperty]
        Module module;

        [ObservableProperty]
        string word = string.Empty;

        [ObservableProperty]
        string meaning = string.Empty;

        [RelayCommand]
        async void UpdateFlashCardList()
        {
            await GetFlashCardList();
            await GetFlashCard();

        }

        [RelayCommand]
        async void Cancel() => await GotoModulePage();

        [RelayCommand]
        async void Prev() => await GotoPrevFlashCard();

        [RelayCommand]
        async void Next() => await GotoNextFlashCard();

        [RelayCommand]
        async void Flip()
        {
            if (!(!string.IsNullOrEmpty(Word) && !string.IsNullOrEmpty(Meaning)))
            {
                if (Word == FlashCards[flashCardId].FrontSide.Text1)
                {
                    Word = FlashCards[flashCardId].BackSide.Text1;
                }
                else
                {
                    Word = FlashCards[flashCardId].FrontSide.Text1;
                }
            }
        }

        public LearnViewModel(IModuleService moduleService)
        {
            this.moduleService = moduleService;
        }

        public async Task GotoModulePage()
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "Module", module }
            };
            await Shell.Current.GoToAsync(nameof(ModulePage), parameters);
        }

        public async Task GotoNextFlashCard()
        {
            if (flashCardId < FlashCards.Count - 1)
            {
                flashCardId++;
                await GetFlashCard();
            }
        }

        public async Task GotoPrevFlashCard()
        {
            if (flashCardId > 0)
            {
                flashCardId--;
                await GetFlashCard();
            }
        }


        public async Task GetFlashCardList()
        {
            if (module != null)
            {
                var flashcards = await moduleService.GetAllModuleFlashCards(module.Id);
                if (flashcards.Count() == 0)
                {
                    await GotoModulePage();
                }
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

        public async Task GetFlashCard()
        {
            if (FlashCards != null && FlashCards.Count > flashCardId)
            {
                Word = FlashCards[flashCardId].FrontSide.Text1;
                if (!string.IsNullOrEmpty(FlashCards[flashCardId].FrontSide.Text2))
                {
                    Meaning = FlashCards[flashCardId].FrontSide.Text2;
                }
                else
                {
                    Meaning = string.Empty;
                }
            }
        }
    }
}
