using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FlashCardApplication.Domain.Entities;
using FlashCardApplication.MyApplication.Abstractions;
using FlashCardApplication.UI.Views;

namespace FlashCardApplication.UI.ViewModels
{
    [QueryProperty(nameof(Module), nameof(Module))]
    public partial class NewFlashCardViewModel : ObservableObject
    {
        IModuleService moduleService;

        [ObservableProperty]
        Module module;

        [ObservableProperty]
        bool doublePage = false;

        [ObservableProperty]
        string word;

        [ObservableProperty]
        string meaning;


        [RelayCommand]
        async void Cancel() => await GotoModulePage();


        [RelayCommand]
        async void Create() => await CreateNewFlashCard();

        [RelayCommand]
        async void AddImage() => await LoadImage();


        public NewFlashCardViewModel(IModuleService moduleService)
        {
            this.moduleService = moduleService;
        }

        public async Task CreateNewFlashCard()
        {
            if (!string.IsNullOrEmpty(Word) && !string.IsNullOrEmpty(Meaning))
            {
                FlashCard flashcard;
                if (DoublePage)
                {
                    flashcard = new FlashCard()
                    {
                        FrontSide = new Domain.Entities.Page()
                        {
                            Text1 = Word,
                            Text2 = string.Empty,
                        },
                        BackSide = new Domain.Entities.Page()
                        {
                            Text1 = Meaning,
                            Text2 = string.Empty,
                        }
                    };
                }
                else
                {
                    flashcard = new FlashCard()
                    {
                        FrontSide = new Domain.Entities.Page()
                        {
                            Text1 = Word,
                            Text2 = Meaning,
                        },
                        BackSide = null,
                    };
                }

                await moduleService.AddFlashCardAsync(module.Id, flashcard);
                await Shell.Current.GoToAsync("///" + nameof(HomePage));
            }
        }

        public async Task LoadImage()
        {

        }
        public async Task GotoModulePage()
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "Module", module }
            };
            await Shell.Current.GoToAsync(nameof(ModulePage), parameters);
        }
    }
}
