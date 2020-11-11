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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SupermarcheWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GestionnaireBDD gstBdd;
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            gstBdd = new GestionnaireBDD();
        }

        private void btnFrmRayonsSecteurs_Click(object sender, RoutedEventArgs e)
        {
            FrmRayonsSecteurs frm = new FrmRayonsSecteurs(gstBdd);
            frm.Show();
        }

        private void btnNewEmploye_Click(object sender, RoutedEventArgs e)
        {
            FrmNewEmploye frm = new FrmNewEmploye(gstBdd);
            frm.Show();
        }

        private void btnGstHoraires_Click(object sender, RoutedEventArgs e)
        {
            FrmGestionnaireHoraires frm = new FrmGestionnaireHoraires(gstBdd);
            frm.Show();
        }
    }
}
