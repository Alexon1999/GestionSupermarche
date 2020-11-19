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
    /// Logique d'interaction pour FrmGestionnaireHoraires.xaml
    /// </summary>
    public partial class FrmGestionnaireHoraires : Window
    {
        GestionnaireBDD gstBdd;
        public FrmGestionnaireHoraires(GestionnaireBDD unGstBdd)
        {
            InitializeComponent();
            gstBdd = unGstBdd;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cboEmployes.ItemsSource = gstBdd.GetAllEmployes();
            cboRayons.ItemsSource = gstBdd.GetAllRayons();

            txtValSld.Text = Convert.ToInt16(sldTempPasse.Value).ToString();
        }

        private void cboEmployes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cboEmployes.SelectedItem != null)
            {
                //MessageBox.Show((cboEmployes.SelectedItem as Employe).NumEmploye.ToString());
                lstTravailsRayons.ItemsSource = gstBdd.GetAllDetailsTravailDEmploye((cboEmployes.SelectedItem as Employe).NumEmploye);
            }
        }

        private void sldTempPasse_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //MessageBox.Show(sldTempPasse.Value.ToString());
            int sliderVal = (int)sldTempPasse.Value;
            txtValSld.Text = sliderVal.ToString();
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            if(cboEmployes.SelectedItem != null)
            {
                if(cboRayons.SelectedItem != null)
                {
                    Employe selectedEmploye = (cboEmployes.SelectedItem as Employe);
                    Rayon selectedRayon = (cboRayons.SelectedItem as Rayon);

                    //lstTravailsRayons.SelectedItem as Travailler).Date.ToString() 25/03/2016 12:00:51
                    //(lstTravailsRayons.SelectedItem as Travailler).Date.ToShortDateString() c'est de type DateTime , on convertit en short string 25/03/2016
                    //lstTravailsRayons.SelectedItem as Travailler).Date.ToString("yyyy-MM-dd")  la date à string avec un format
                    //MessageBox.Show((lstTravailsRayons.SelectedItem as Travailler).Date.ToString("yyyy-MM-dd")); 2016-03-25

                    // DateTime object
                    //DateTime test = new DateTime(2015, 01, 01);
                    //test.ToString("yyyy-MM-dd");

                    // Date aujourd'hui
                    // DateTime date = DateTime.Now; // Now propriété donne un objet de type Datetime avec la date d'aujourd'hui
                    //MessageBox.Show(date.ToString("yyyy-MM-dd")); // 2020-11-13
                    // gstBdd.ajouterTravailler(selectedEmploye, selectedRayon, date.ToString("yyyy-MM-dd"), Convert.ToInt16(txtValSld.Text));

                    // Datepicker
                    //MessageBox.Show(dpTravil.SelectedDate.ToString()); 25/03/2016 00:00:00
                    //MessageBox.Show(dpTravil.SelectedDate.Value.ToString("yyyy-MM-dd")); // format


                    // facultatif la datePicker
                    if (dpTravil.SelectedDate.HasValue)
                    {
                        gstBdd.ajouterTravailler(selectedEmploye, selectedRayon, dpTravil.SelectedDate.Value.ToString("yyyy-MM-dd"), Convert.ToInt16(txtValSld.Text));
                        lstTravailsRayons.ItemsSource = null;
                        lstTravailsRayons.ItemsSource = gstBdd.GetAllDetailsTravailDEmploye((cboEmployes.SelectedItem as Employe).NumEmploye);

                    }
                    else
                    {
                        MessageBox.Show("Veuillez choisir une date", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Veuillez choisir un rayon", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Veuillez choisir un employé", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
