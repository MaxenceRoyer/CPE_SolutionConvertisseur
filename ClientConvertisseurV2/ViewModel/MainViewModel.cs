using ClientConvertisseurV2.Models;
using GalaSoft.MvvmLight;
using System;
using System.Collections.ObjectModel;
using ClientConvertisseurV2.Service;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Net.Http;
using ClientConvertisseurV2.View;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;

namespace ClientConvertisseurV2.ViewModel
{
    /// <summary>
    /// MainViewModel - Hérite de ViewModelBase
    /// <para>
    /// Maxence Royer
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        public ICommand BtnSetConversion { get; private set; }

        public ICommand BtnSetConversionDevise { get; private set; }

        public ICommand BtnChangeConvertisseur { get; private set; }

        public Devise ComboBoxDeviseItem { get; set; }

        private string _montantEuros;

        public string MontantEuros
        {
            get { return _montantEuros; }
            set
            {
                _montantEuros = value;
                RaisePropertyChanged(); // Pour notifier de la modification de ses données
            }
        }

        private String _montantEurosInitial;

        public string MontantEurosInitial
        {
            get { return _montantEurosInitial; }
            set
            {
                _montantEurosInitial = value;
                RaisePropertyChanged(); // Pour notifier de la modification de ses données
            }
        }

        private ObservableCollection<Devise> _comboBoxDevises;

        public ObservableCollection<Devise> ComboBoxDevises
        {
            get { return _comboBoxDevises; }
            set
            {
                _comboBoxDevises = value;
                RaisePropertyChanged(); // Pour notifier de la modification de ses données
            }
        }

        public MainViewModel()
        {
            ActionGetData();
            BtnSetConversion = new RelayCommand(ActionSetConversionAsync);
            BtnSetConversionDevise = new RelayCommand(ActionSetConversionAsyncDeviseVersEuros);
            BtnChangeConvertisseur = new RelayCommand(ActionChangeConvertisseur);
        }

        /// <summary>
        /// Méthode permettant de convertir un montant en euros en devises
        /// </summary>
        private async void ActionSetConversionAsync()
        {
            if (this.MontantEurosInitial != null && this.ComboBoxDeviseItem != null)
            {
                try
                {
                    int intMontantValue;
                    double taux;
                    intMontantValue = Convert.ToInt32(this.MontantEurosInitial);
                    taux = this.ComboBoxDeviseItem.Taux;

                    this.MontantEuros = (intMontantValue * taux).ToString();
                }
                catch (FormatException formatException)
                {
                    var messageDialog = new Windows.UI.Popups.MessageDialog("Erreur de format d'un champs du formulaire : " + formatException);
                    await messageDialog.ShowAsync();
                }
            }
            else
            {
                var messageDialog = new Windows.UI.Popups.MessageDialog("Certains champs du formulaire sont vides...\nMerci de les compléter !");
                await messageDialog.ShowAsync();
            }
        }

        /// <summary>
        /// Méthode permettant de convertir un montant en devise en euros
        /// </summary>
        private async void ActionSetConversionAsyncDeviseVersEuros()
        {
            if (this.MontantEurosInitial != null && this.ComboBoxDeviseItem != null)
            {
                try
                {
                    int intMontantValue;
                    double taux;
                    intMontantValue = Convert.ToInt32(this.MontantEurosInitial);
                    taux = this.ComboBoxDeviseItem.Taux;

                    this.MontantEuros = (intMontantValue / taux).ToString();
                }
                catch (FormatException formatException)
                {
                    var messageDialog = new Windows.UI.Popups.MessageDialog("Erreur de format d'un champs du formulaire : " + formatException);
                    await messageDialog.ShowAsync();
                }
            }
            else
            {
                var messageDialog = new Windows.UI.Popups.MessageDialog("Certains champs du formulaire sont vides...\nMerci de les compléter !");
                await messageDialog.ShowAsync();
            }
        }

        /// <summary>
        /// Méthode permettant de récupérer la liste des Devise
        /// </summary>
        private async void ActionGetData()
        {
            try
            {
                var result = await WSService.GetInstance().getAllDevisesAsync("devise");
                ComboBoxDevises = new ObservableCollection<Devise>(result);
            }
            catch (HttpRequestException httpError)
            {
                var messageDialog = new Windows.UI.Popups.MessageDialog("Erreur lors de l'appel aux WS : " + httpError.Message);
                await messageDialog.ShowAsync();
            }
        }

        /// <summary>
        /// Méthode permettant de changer de convertisseur - Euro vers devise 
        /// </summary>
        private void ActionChangeConvertisseur()
        {
            RootPage r = (RootPage)Window.Current.Content;
            SplitView sv = (SplitView)(r.Content);
            (sv.Content as Frame).Navigate(typeof(MainPage));
        }
    }
}
