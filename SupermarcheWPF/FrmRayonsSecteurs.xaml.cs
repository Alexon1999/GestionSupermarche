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
    /// Logique d'interaction pour FrmRayonsSecteurs.xaml
    /// </summary>
    public partial class FrmRayonsSecteurs : Window
    {
        GestionnaireBDD gstBdd;
        public FrmRayonsSecteurs(GestionnaireBDD unGstBdd)
        {
            InitializeComponent();
            gstBdd = unGstBdd;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //cboSecteurs.ItemsSource = gstBdd.GetAllSecteurs();
            cboSecteurs.ItemsSource = gstBdd.GetAllNomsSecteurs();
        }

        private void cboSecteurs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cboSecteurs.SelectedItem != null)
            {
                //Secteur s = gstBdd.GetSecteurByNom(cboSecteurs.SelectedItem as string);
                lvRayons.ItemsSource = gstBdd.GetAllRayonsBySecteur(cboSecteurs.SelectedItem as string);
            }
        }

    }
}
