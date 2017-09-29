using ClientConvertisseurV1.Models;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using ClientConvertisseurV1.Service;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ClientConvertisseurV1
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            ActionGetData();
        }

        private async void ActionGetData()
        {
            var result = await WSService.GetInstance().getAllDevisesAsync("devise");
            this.cbxDevise.DataContext = new List<Devise>(result);
        }

        private void Convertir_Click(object sender, RoutedEventArgs e)
        {
            int intMontantValue;
            double taux;
            intMontantValue = Convert.ToInt32(this.montantValue.Text);
            taux = ((Devise)this.cbxDevise.SelectedItem).Taux;

            this.resultConvertisseur.Text = (intMontantValue * taux).ToString();
        }
    }
}
