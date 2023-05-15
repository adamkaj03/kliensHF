using proba;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;

namespace Dictionary.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public ObservableCollection<string> SourceLanguages { get; set; } = 
            new ObservableCollection<string>() {};


        public override async Task OnNavigatedToAsync(
        object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            var service = new DictionaryService();
            var languages = await service.GetLanguagesAsync();
            foreach (var language in languages)
            {
                SourceLanguages.Add(language);
            }

            await base.OnNavigatedToAsync(parameter, mode, state);
        }

    }
}
