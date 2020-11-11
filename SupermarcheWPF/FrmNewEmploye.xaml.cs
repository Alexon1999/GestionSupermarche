using MetierBDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SupermarcheWPF
{
    /// <summary>
    /// Logique d'interaction pour FrmNewEmploye.xaml
    /// </summary>
    public partial class FrmNewEmploye : Window
    {
        GestionnaireBDD gstBdd;
        public FrmNewEmploye(GestionnaireBDD unGstBdd)
        {
            InitializeComponent();
            gstBdd = unGstBdd;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lstEmployes.ItemsSource = gstBdd.GetAllEmployes();
            txtNumeroEmploye.Text = gstBdd.GetLastNumEmployes().ToString();
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            if(txtNomEmploye.Text != "")
            {
                gstBdd.AjouterEmploye(Convert.ToInt16(txtNumeroEmploye.Text), txtNomEmploye.Text);

                //Rafraichir la listebox des employees
                lstEmployes.ItemsSource = null;
                lstEmployes.ItemsSource = gstBdd.GetAllEmployes();

                txtNumeroEmploye.Text = (Convert.ToInt16(txtNumeroEmploye.Text) + 1).ToString();
                txtNomEmploye.Text = "";
            }
            else
            {
                MessageBox.Show("saissez un nom", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
